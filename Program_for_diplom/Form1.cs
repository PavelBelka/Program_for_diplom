using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Timer = System.Threading.Timer;

namespace Program_for_diplom
{
    public partial class Form1 : Form
    {
        private SerialPort _comport = new SerialPort();
        private byte[] _writeBuffer = new byte[3];
        private byte[] _readBuffer = new byte[3];
        private bool _readFlag, _connectionFlag, _buttonClickFlag = false;
        short distance,temperature, temperature_current, distance_current = 0;
        int time, step_measurement = 0;

        public string Data { get; set; } = "0";

        public Form1()
        {
            string[] portNames = SerialPort.GetPortNames();
            InitializeComponent();
            cbPortsName.Items.Clear();
            cbPortsName.Items.AddRange(portNames);
            lbStatus.ForeColor = Color.Red;
            lbStatus.Text = "Не подключено";
        }

        private void comboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            btConnect.Enabled = Enabled;
        }

        private void KeyPress_common(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void Button_con_Click(object sender, EventArgs e)
        {
            if (_connectionFlag == false)
            {
                string portName = cbPortsName.SelectedItem.ToString();
                rtbLogger.AppendText("Выбран порт: " + portName + "\r\n");
                Connect(portName);
            }
            else if (_connectionFlag == true)
            {
                btConnect.Text = "Соединение";
                lbStatus.Text = "Не подключено";
                lbStatus.ForeColor = Color.Red;
                _connectionFlag = false;
                _comport.Close();
            }
        }

        private void bt_izmer_Click(object sender, EventArgs e)
        {
            if (step_measurement == 0)
            {
                lb_izmer.Text = "Выставьте\"0\" точку.";
                Managment("preparation_null");
                Thread.Sleep(125);
                Update_status();
                Preparation_for_measurement();
            }
            else
            {
                step_measurement = 0;
                Measurement();
            }
        }

        private void Preparation_for_measurement()
        {
            while (true)
            {
                Distance();
                Bx_distance.Text = distance.ToString();
                Write_uart(Convert.ToByte('H'), Convert.ToByte('H'), Convert.ToByte('H'));
                readCommand(3);
                if ((_readBuffer[0] == 85) &&  ((_readBuffer[2] & 0b01000000) == 0b01000000))
                {
                    break;
                }
                Thread.Sleep(125);
                Application.DoEvents();
            }
            Write_uart(Convert.ToByte('I'), Convert.ToByte('I'), Convert.ToByte('I'));
            lb_izmer.Text = "Разогрев проволоки.";
            temperature = Convert.ToInt16(Bx_temp.Text);
            time = Convert.ToInt32(Bx_time.Text);
            Write_uart(Convert.ToByte('C'), (byte)(temperature >> 8), (byte)(temperature & 0xFF));
            Thread.Sleep(100);
            Managment("pid");
            while (true)
            {
                Managment("temperature");
                readCommand(3);
                if (_readBuffer[0] == 87)
                {
                    temperature_current = (short)((_readBuffer[1] << 8) | _readBuffer[2]);
                }
                else
                {
                    temperature_current = 0;
                }
                if (temperature_current == temperature)
                {
                    break;
                }
                lb_temp.Text = temperature_current.ToString();
                Thread.Sleep(125);
                Application.DoEvents();
            }
            lb_izmer.Text = "Проволока разогрета. Нажмите кнопку для начала измерения";
            bt_izmer.Text = "Измерение";
            step_measurement = 1;
        }

        private void Measurement()
        {
            Managment("temperature");
            readCommand(3);
            if (_readBuffer[0] == 87)
            {
                temperature_current = (short)((_readBuffer[1] << 8) | _readBuffer[2]);
                lb_temp.Text = temperature_current.ToString();
            }
            Managment("distance");
            readCommand(3);
            if (_readBuffer[0] == 88)
            {
                distance_current = (short)((_readBuffer[1] << 8) | _readBuffer[2]);
            }
            lb_distance.Text = distance_current.ToString();
        }

        private void Distance()
        {
            Managment("distance");
            readCommand(3);
            if (_readBuffer[0] == 88)
            {
                distance = (short)((_readBuffer[1] << 8) | _readBuffer[2]);
            }
            else
            {
                distance = 0;
            }
        }

        private void Connect(string name)
        {
            _comport.PortName = name;
            _comport.BaudRate = 38400;
            _comport.DataBits = 8;
            _comport.Parity = Parity.None;
            _comport.StopBits = StopBits.One;
            _comport.ReadTimeout = 5000;
            _comport.WriteTimeout = 500;
            rtbLogger.AppendText("Параметры порта:\r\nСкорость передачи:" + _comport.BaudRate.ToString() + "\r\n");
            rtbLogger.AppendText("Длина данных:" + _comport.DataBits.ToString() + "\r\n");
            rtbLogger.AppendText("Параметры порта: отсутсвует\r\nКоличество stop-битов: 1\r\n");
            rtbLogger.AppendText("Таймаут: 2с\r\nСоединение...\r\n");
            try
            {
                _comport.Open();
                if (_comport.IsOpen == true)
                {
                    rtbLogger.AppendText("Порт открыт. Отправка запроса устройству:\r\n");
                    for (int i = 1; i < 4; i++)
                    {
                        tryToConnect(i);
                        if (_connectionFlag)
                        {
                            break;
                        }
                    }
                    if (!_connectionFlag)
                    {
                        rtbLogger.AppendText("Подключено неизвестное устройство. Переподключите еще раз или выберите другой порт.\r\n");
                        _comport.Close();
                    }
                }
                else
                {
                    rtbLogger.AppendText("Ошибка открытия порта. Попробуйте открыть порт еще раз.\r\n");
                    _comport.Close();
                }
            }
            catch (Exception ex)
            {
                rtbLogger.AppendText("Ошибка:" + ex.ToString() + "\r\n");
                _comport.Close();
            }
        }

        private void tryToConnect(int i)
        {
            rtbLogger.AppendText("Попытка:" + i.ToString() + "\r\n");
            Write_uart(Convert.ToByte('G'), Convert.ToByte('Y'), Convert.ToByte('B'));
            Thread.Sleep(100);
            readCommand(3);
            rtbLogger.AppendText(Data);
            if ((_readBuffer[0] == 65) && (_readBuffer[1] == 86) && (_readBuffer[2] == 69))
            {
                rtbLogger.AppendText("Соединение установлено.\r\n");
                _connectionFlag = true;
                btConnect.Text = "Разорвать";
                lbStatus.ForeColor = Color.Green;
                lbStatus.Text = "Соединено";
                Bx_temp.Enabled = Enabled;
                Bx_time.Enabled = Enabled;
                bt_izmer.Enabled = Enabled;
                Update_status();
            }
            else
            {
                rtbLogger.AppendText("Отказ.\r\n");
            }
        }

        private void Managment(string action)
        {
            Write_uart(Convert.ToByte('I'), Convert.ToByte('I'), Convert.ToByte('I'));
            Thread.Sleep(500);
            switch(action)
            {
                case "preparation_null":
                    Write_uart(Convert.ToByte('A'), Convert.ToByte('A'), Convert.ToByte('e'));
                    break;
                case "idle":
                    Write_uart(Convert.ToByte('A'), Convert.ToByte('A'), Convert.ToByte('d'));
                    break;
                case "measuring":
                    Write_uart(Convert.ToByte('A'), Convert.ToByte('A'), Convert.ToByte('f'));
                    break;
                case "distance":
                    Write_uart(Convert.ToByte('D'), Convert.ToByte('D'), Convert.ToByte('D'));
                    break;
                case "pid":
                    Write_uart(Convert.ToByte('J'), Convert.ToByte('J'), Convert.ToByte('J'));
                    break;
                case "temperature":
                    Write_uart(Convert.ToByte('B'), Convert.ToByte('B'), Convert.ToByte('B'));
                    break;
            }
        }

        private void Update_status()
        {
            Write_uart(Convert.ToByte('H'), Convert.ToByte('H'), Convert.ToByte('H'));
            Thread.Sleep(10);
            readCommand(3);
            if (_readBuffer[0] == 85)
            {
                if ((_readBuffer[2] & 0b10000000) == 0b10000000)
                {
                    lb_Modeinst.Text = "остановлен";
                    lb_Modeinst.ForeColor = Color.Red;
                }
                if ((_readBuffer[2] & 0b01000000) == 0b01000000)
                {
                    //status = "Button_CONFIRM";
                }
                if ((_readBuffer[2] & 0b00100000) == 0b00100000)
                {
                    lb_Modeinst.Text = "без действия";
                    lb_Modeinst.ForeColor = Color.Green;
                }
                if ((_readBuffer[2] & 0b00010000) == 0b00010000)
                {
                    lb_Modeinst.Text = "подготовка к измерению";
                    lb_Modeinst.ForeColor = Color.Green;
                }
                if ((_readBuffer[2] & 0b00001000) == 0b00001000)
                {
                    lb_Modeinst.Text = "производится измерение";
                    lb_Modeinst.ForeColor = Color.Orange;
                }
                if ((_readBuffer[2] & 0b00000100) == 0b00000100)
                {
                    lb_Modeinst.Text = "авария";
                    lb_Modeinst.ForeColor = Color.Red;
                    //status = "Crash";
                }
            }
            else
            {
                lb_Modeinst.Text = "неизвестно";
                lb_Modeinst.ForeColor = Color.Red;
            }
        }

        private void Write_uart(byte comand, byte data1, byte data2)
        {
            _comport.DiscardInBuffer();
            _comport.DiscardOutBuffer();
            _writeBuffer[0] = comand;
            _writeBuffer[1] = data1;
            _writeBuffer[2] = data2;
            rtbLogger.AppendText("Отправление команды на устройство:\r\n");
            rtbLogger.AppendText(comand.ToString() + " " + data1.ToString() + " " + data2.ToString() + "\r\n");
            _comport.Write(_writeBuffer, 0, 3);
        }

        private void readCommand(int bufferSize)
        {
            Data = "";
            for (int i = 0; i < bufferSize; i++)
            {
                _readBuffer[i] = (byte)_comport.ReadByte();
                Data += $"{_readBuffer[i]} ";
            }
            Data += "\r\n";
            _readFlag = true;
        }

        private void bufferSizeError()
        {
            Data = "Ошибка чтения буфера: количество байтов не совпадает с необходимым.\r\n";
            _readBuffer[0] = Convert.ToByte('!');
            _readBuffer[1] = Convert.ToByte('!');
            _readBuffer[2] = Convert.ToByte('!');
            _readFlag = true;
        }

        private void timeOutError()
        {
            Data = $"Ошибка чтения буфера: Время ожидания истекло\r\n";
            _readBuffer[0] = Convert.ToByte('!');
            _readBuffer[1] = Convert.ToByte('!');
            _readBuffer[2] = Convert.ToByte('!');
            _readFlag = true;
        }
    }
}
