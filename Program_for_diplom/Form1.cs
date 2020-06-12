using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;


// Ну-ка, дети, встаньте в ряд - запинаем-ка Гурят
namespace Program_for_diplom {
    public partial class Form1 : Form {
        string _data = "0";

        SerialPort comport = new SerialPort();
        byte[] com_port_write = new byte[3];
        byte[] com_port_read = new byte[3];
        bool Read, Con, but_click = false;
        public Form1() {
            string[] name_ports = SerialPort.GetPortNames();
            InitializeComponent();
            comboPort.Items.Clear();
            comboPort.Items.AddRange(name_ports);
            lab_statuscon.Text = "не подключено";
            lab_statuscon.ForeColor = Color.Red;
        }

        private void comboPort_SelectedIndexChanged(object sender, EventArgs e) {
            Button_con.Enabled = Enabled;
        }

        private void Button_con_Click(object sender, EventArgs e) {
            if (but_click == false) {
                string com_name = comboPort.SelectedItem.ToString();
                Box_log.AppendText("Выбран порт: " + com_name + "\r\n");
                Connect(com_name);
            } else if (but_click == true) {
                Button_con.Text = "Соединение";
                lab_statuscon.Text = "не подключено";
                lab_statuscon.ForeColor = Color.Red;
                Con = false;
                comport.Close();
                but_click = false;
            }
        }

        private void Connect(string name) {
            comport.PortName = name;
            comport.BaudRate = 38400;
            comport.DataBits = 8;
            comport.Parity = Parity.None;
            comport.StopBits = StopBits.One;
            comport.ReadTimeout = 2;
            comport.WriteTimeout = 2;
            comport.DataReceived += Comport_DataReceived;
            Box_log.AppendText("Параметры порта:\r\nСкорость передачи:" + comport.BaudRate.ToString() + "\r\n");
            Box_log.AppendText("Длина данных:" + comport.DataBits.ToString() + "\r\n");
            Box_log.AppendText("Параметры порта: отсутсвует\r\nКоличество stop-битов: 1\r\n");
            Box_log.AppendText("Таймаут: 2с\r\nСоединение...\r\n");
            try {
                comport.Open();
                if (comport.IsOpen == true) {
                    Box_log.AppendText("Порт открыт. Отправка запроса устройству:\r\n");
                    for (int i = 1; i < 4; i++) {
                        Box_log.AppendText("Попытка:" + i.ToString() + "\r\n");
                        Write_uart(Convert.ToByte('G'), Convert.ToByte('Y'), Convert.ToByte('B'));
                        while (true) {
                            if (Read == true) {
                                Read = false;
                                break;
                            }
                        }
                        Box_log.AppendText(_data);
                        if ((com_port_read[0] == (byte)65) && (com_port_read[1] == (byte)86) && (com_port_read[2] == (byte)69)) {
                            Box_log.AppendText("Соединение установлено.\r\n");
                            Con = true;
                            Button_con.Text = "Разорвать";
                            lab_statuscon.Text = "соединено";
                            lab_statuscon.ForeColor = Color.Green;
                            break;
                        } else {
                            Box_log.AppendText("Отказ.\r\n");
                        }
                    }
                    if (Con == false) {
                        Box_log.AppendText("Подключено неизвестное устройство. Переподключите еще раз или выберите другой порт.\r\n");
                        comport.Close();
                    }
                } else {
                    Box_log.AppendText("Ошибка открытия порта. Попробуйте открыть порт еще раз.\r\n");
                    comport.Close();
                }
            } catch (Exception ex) {
                Box_log.AppendText("Ошибка:" + ex.ToString() + "\r\n");
                comport.Close();
            }
        }

        private void Write_uart(byte comand, byte data1, byte data2) {
            com_port_write[0] = comand;
            com_port_write[1] = data1;
            com_port_write[2] = data2;
            comport.DiscardInBuffer();
            comport.DiscardOutBuffer();
            Box_log.AppendText("Отправление команды на устройство:\r\n");
            Box_log.AppendText(comand.ToString() + " " + data1.ToString() + " " + data2.ToString() + "\r\n");
            comport.Write(com_port_write, 0, 3);
        }

        private void Comport_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            try {
                _data = "Чтение ответа:\r\n";
                int sizebuf = comport.BytesToRead;
                if (sizebuf == 4) // тут 4 потому что у меня терминал в конце ставит /n, у тебя может быть по-другому
                {
                    _data = "";
                    for (int i = 0; i < sizebuf - 1; i++) {
                        com_port_read[i] = (byte)comport.ReadByte();
                        _data += $"{com_port_read[i]} ";
                    }
                    _data += "\r\n";
                    Read = true;
                } else {
                    _data = "Ошибка чтения буфера: количество байтов не совпадает с необходимым.\r\n";
                    com_port_read[0] = Convert.ToByte('!');
                    com_port_read[1] = Convert.ToByte('!');
                    com_port_read[2] = Convert.ToByte('!');
                    Read = true;
                }
            } catch (TimeoutException exc) {
                _data = $"Ошибка чтения буфера: {exc.ToString()}\r\n";
                com_port_read[0] = Convert.ToByte('!');
                com_port_read[1] = Convert.ToByte('!');
                com_port_read[2] = Convert.ToByte('!');
                Read = true;
            }
        }
    }
}
