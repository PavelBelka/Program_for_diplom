using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
//ЫЫЫЫЫЫЫЫЫЫЫЫЫ
namespace Program_for_diplom {
    public partial class Form1 : Form {
        private SerialPort _comport = new SerialPort();
        private byte[] _writeBuffer = new byte[3];
        private byte[] _readBuffer = new byte[3];
        private bool _readFlag, _connectionFlag, _buttonClickFlag = false;

        public string Data { get; set; } = "0";

        public Form1() {
            string[] portNames = SerialPort.GetPortNames();
            InitializeComponent();
            cbPortsName.Items.Clear();
            cbPortsName.Items.AddRange(portNames);
            lbStatus.ForeColor = Color.Red;
            lbStatus.Text = "Не подключено";
        }

        private void comboPort_SelectedIndexChanged(object sender, EventArgs e) {
            btConnect.Enabled = Enabled;
        }

        private void Button_con_Click(object sender, EventArgs e) {
            if (_connectionFlag == false) {
                string portName = cbPortsName.SelectedItem.ToString();
                rtbLogger.AppendText("Выбран порт: " + portName + "\r\n");
                Connect(portName);
            } else if (_connectionFlag == true) {
                btConnect.Text = "Соединение";
                lbStatus.Text = "Не подключено";
                lbStatus.ForeColor = Color.Red;
                _connectionFlag = false;
                _comport.Close();
            }
        }

        private void Connect(string name) {
            _comport.PortName = name;
            _comport.BaudRate = 38400;
            _comport.DataBits = 8;
            _comport.Parity = Parity.None;
            _comport.StopBits = StopBits.One;
            _comport.ReadTimeout = 500;
            _comport.WriteTimeout = 500;
            _comport.DataReceived += Comport_DataReceived;
            rtbLogger.AppendText("Параметры порта:\r\nСкорость передачи:" + _comport.BaudRate.ToString() + "\r\n");
            rtbLogger.AppendText("Длина данных:" + _comport.DataBits.ToString() + "\r\n");
            rtbLogger.AppendText("Параметры порта: отсутсвует\r\nКоличество stop-битов: 1\r\n");
            rtbLogger.AppendText("Таймаут: 2с\r\nСоединение...\r\n");
            try {
                _comport.Open();
                if (_comport.IsOpen == true) {
                    rtbLogger.AppendText("Порт открыт. Отправка запроса устройству:\r\n");
                    for (int i = 1; i < 4; i++) {
                        tryToConnect(i);
                        if (_connectionFlag) {
                            break;
                        }
                    }
                    if (!_connectionFlag) {
                        rtbLogger.AppendText("Подключено неизвестное устройство. Переподключите еще раз или выберите другой порт.\r\n");
                        _comport.Close();
                    }
                } else {
                    rtbLogger.AppendText("Ошибка открытия порта. Попробуйте открыть порт еще раз.\r\n");
                    _comport.Close();
                }
            } catch (Exception ex) {
                rtbLogger.AppendText("Ошибка:" + ex.ToString() + "\r\n");
                _comport.Close();
            }
        }

        private void tryToConnect(int i) {
            rtbLogger.AppendText("Попытка:" + i.ToString() + "\r\n");
            Write_uart(Convert.ToByte('G'), Convert.ToByte('Y'), Convert.ToByte('B'));
            /*while (true) { короч тут нихуа не работает
                if (_readFlag) {
                    _readFlag = false;
                    break;
                }
            }*/
            Thread.Sleep(10);
            readCommand(3);
            rtbLogger.AppendText(Data);
            if ((_readBuffer[0] == 65) && (_readBuffer[1] == 86) && (_readBuffer[2] == 69)) {
                rtbLogger.AppendText("Соединение установлено.\r\n");
                _connectionFlag = true;
                btConnect.Text = "Разорвать";
                lbStatus.ForeColor = Color.Green;
                lbStatus.Text = "Соединено";
            } else {
                rtbLogger.AppendText("Отказ.\r\n");
            }
        }

        private void Write_uart(byte comand, byte data1, byte data2) {
            _writeBuffer[0] = comand;
            _writeBuffer[1] = data1;
            _writeBuffer[2] = data2;
            _comport.DiscardInBuffer();
            _comport.DiscardOutBuffer();
            rtbLogger.AppendText("Отправление команды на устройство:\r\n");
            rtbLogger.AppendText(comand.ToString() + " " + data1.ToString() + " " + data2.ToString() + "\r\n");
            _comport.Write(_writeBuffer, 0, 3);
        }

        private void Comport_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            try {
                Data = "Чтение ответа:\r\n";
                int bufferSize = _comport.BytesToRead;
                if (bufferSize == 3) 
                {
                    readCommand(bufferSize);
                } else {
                    bufferSizeError();
                }
            } catch (TimeoutException) {
                timeOutError();
            }
        }

        private void readCommand(int bufferSize) {
            Data = "";
            for (int i = 0; i < bufferSize; i++) {
                _readBuffer[i] = (byte)_comport.ReadByte();
                Data += $"{_readBuffer[i]} ";
            }
            Data += "\r\n";
            _readFlag = true;
        }

        private void bufferSizeError() {
            Data = "Ошибка чтения буфера: количество байтов не совпадает с необходимым.\r\n";
            _readBuffer[0] = Convert.ToByte('!');
            _readBuffer[1] = Convert.ToByte('!');
            _readBuffer[2] = Convert.ToByte('!');
            _readFlag = true;
        }

        private void timeOutError() {
            Data = $"Ошибка чтения буфера: Время ожидания истекло\r\n";
            _readBuffer[0] = Convert.ToByte('!');
            _readBuffer[1] = Convert.ToByte('!');
            _readBuffer[2] = Convert.ToByte('!');
            _readFlag = true;
        }
    }
}
