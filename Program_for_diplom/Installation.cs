using System;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;

namespace Program_for_diplom
{
    class Installation
    {
        private SerialPort _comport;
        private string _com_port;
        private string path;
        private byte[] _writeBuffer = new byte[3];
        private byte[] _readBuffer = new byte[3];
        private bool _readFlag, _connectionFlag = false;
        public Installation()
        {
            //_com_port = COM;
        }

        private void Create_folder()
        {
            DateTime date = DateTime.Now;
            path = AppDomain.CurrentDomain.BaseDirectory + date.ToString("dd.MM.yyyy_HH_mm");
            DirectoryInfo folder = new DirectoryInfo(path);
            if (!folder.Exists)
            {
                folder.Create();
            }
        }

        /*private void Start_python()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            start.Arguments = "Image.py";
            start.UseShellExecute = true;
            start.RedirectStandardOutput = false;
            start.CreateNoWindow = true;
            Process process = Process.Start(start);
        }*/

        public void Connect()
        {
            _comport = new SerialPort(_com_port, 38400, Parity.None, 8, StopBits.One);
            _comport.ReadTimeout = 500;
            _comport.WriteTimeout = 500;
            //rtbLogger.AppendText("Параметры порта:\r\nСкорость передачи:" + _comport.BaudRate.ToString() + "\r\n");
            //rtbLogger.AppendText("Длина данных:" + _comport.DataBits.ToString() + "\r\n");
            //rtbLogger.AppendText("Параметры порта: отсутсвует\r\nКоличество stop-битов: 1\r\n");
            //rtbLogger.AppendText("Таймаут: 2с\r\nСоединение...\r\n");
            try
            {
                _comport.Open();
                if (_comport.IsOpen == true)
                {
                    //rtbLogger.AppendText("Порт открыт. Отправка запроса устройству:\r\n");
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
                        //rtbLogger.AppendText("Подключено неизвестное устройство. Переподключите еще раз или выберите другой порт.\r\n");
                        _comport.Close();
                    }
                }
                else
                {
                    //rtbLogger.AppendText("Ошибка открытия порта. Попробуйте открыть порт еще раз.\r\n");
                    _comport.Close();
                }
            }
            catch (Exception ex)
            {
                //rtbLogger.AppendText("Ошибка:" + ex.ToString() + "\r\n");
                _comport.Close();
            }
        }

        private void tryToConnect(int i)
        {
            //rtbLogger.AppendText("Попытка:" + i.ToString() + "\r\n");
            Write_uart(Convert.ToByte('G'), Convert.ToByte('Y'), Convert.ToByte('B'));
            Thread.Sleep(100);
            readCommand(3);
            //rtbLogger.AppendText(Data);
            /*if ((_readBuffer[0] == 65) && (_readBuffer[1] == 86) && (_readBuffer[2] == 69))
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
            }*/
        }

        private void Managment(string action)
        {
            Write_uart(Convert.ToByte('I'), Convert.ToByte('I'), Convert.ToByte('I'));
            Thread.Sleep(500);
            switch (action)
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
            /*if (_readBuffer[0] == 85)
            {
                if ((_readBuffer[2] & 0b10000000) == 0b10000000)
                {
                    lb_Modeinst.Text = "остановлен";
                    lb_Modeinst.ForeColor = Color.Red;
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
                }
            }
            else
            {
                lb_Modeinst.Text = "неизвестно";
                lb_Modeinst.ForeColor = Color.Red;
            }*/
        }

        private void Write_uart(byte comand, byte data1, byte data2)
        {
            _comport.DiscardInBuffer();
            _comport.DiscardOutBuffer();
            _writeBuffer[0] = comand;
            _writeBuffer[1] = data1;
            _writeBuffer[2] = data2;
            //rtbLogger.AppendText("Отправление команды на устройство:\r\n");
            //rtbLogger.AppendText(comand.ToString() + " " + data1.ToString() + " " + data2.ToString() + "\r\n");
            _comport.Write(_writeBuffer, 0, 3);
        }

        private void readCommand(int bufferSize)
        {
            //Data = "";
            for (int i = 0; i < bufferSize; i++)
            {
                _readBuffer[i] = (byte)_comport.ReadByte();
                //Data += $"{_readBuffer[i]} ";
            }
            //Data += "\r\n";
            _readFlag = true;
        }

        private void bufferSizeError()
        {
            //Data = "Ошибка чтения буфера: количество байтов не совпадает с необходимым.\r\n";
            _readBuffer[0] = Convert.ToByte('!');
            _readBuffer[1] = Convert.ToByte('!');
            _readBuffer[2] = Convert.ToByte('!');
            _readFlag = true;
        }

        private void timeOutError()
        {
            //Data = $"Ошибка чтения буфера: Время ожидания истекло\r\n";
            _readBuffer[0] = Convert.ToByte('!');
            _readBuffer[1] = Convert.ToByte('!');
            _readBuffer[2] = Convert.ToByte('!');
            _readFlag = true;
        }
    }
}
