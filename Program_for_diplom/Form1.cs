using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Program_for_diplom
{
    public partial class Form1 : Form
    {
        SerialPort comport = new SerialPort();
        byte[] com_port_write = new byte[3];
        byte[] com_port_read = new byte[3];
        bool Read, Con, but_click = false;
        public Form1()
        {
            string[] name_ports = SerialPort.GetPortNames();
            InitializeComponent();
            comboPort.Items.Clear();
            comboPort.Items.AddRange(name_ports);
            lab_statuscon.Text = "не подключено";
            lab_statuscon.ForeColor = Color.Red;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_con.Enabled = Enabled;
        }

        private void Button_con_Click(object sender, EventArgs e)
        {
            if (but_click == false)
            {
                string com_name = comboPort.SelectedItem.ToString();
                Box_log.AppendText("Выбран порт: " + com_name + "\r\n");
                Connect(com_name);
            }
            else if (but_click == true)
            {
                Button_con.Text = "Соединение";
                lab_statuscon.Text = "не подключено";
                lab_statuscon.ForeColor = Color.Red;
                Con = false;
                comport.Close();
                but_click = false;
            }
        }

        private void Connect(string name)
        {
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
            try
            {
                comport.Open();
                if (comport.IsOpen == true)
                {
                    Box_log.AppendText("Порт открыт. Отправка запроса устройству:\r\n");
                    for (int i = 1; i < 4; i++)
                    {
                        Box_log.AppendText("Попытка:" + i.ToString() + "\r\n");
                        Write_uart(Convert.ToByte('G'), Convert.ToByte('Y'), Convert.ToByte('B'));
                        while (true)
                        {
                            if (Read == true)
                            {
                                Read = false;
                                break;
                            }
                        }
                        if ((com_port_read[0] == 65) && (com_port_read[1] == 89) && (com_port_read[2] == 69))
                        {
                            Box_log.AppendText("Соединение установлено.\r\n");
                            Con = true;
                            Button_con.Text = "Разорвать";
                            lab_statuscon.Text = "соединено";
                            lab_statuscon.ForeColor = Color.Green;
                            break;
                        }
                        else
                        {
                            Box_log.AppendText("Отказ.\r\n");
                        }
                    }
                    if(Con == false)
                    {
                        Box_log.AppendText("Подключено неизвестное устройство. Переподключите еще раз или выберите другой порт.\r\n");
                        comport.Close();
                    }
                }
                else
                {
                    Box_log.AppendText("Ошибка открытия порта. Попробуйте открыть порт еще раз.\r\n");
                    comport.Close();
                }
            }
            catch(Exception ex)
            {
                Box_log.AppendText("Ошибка:" + ex.ToString() + "\r\n");
                comport.Close();
            }
        }

        private void Write_uart(byte comand, byte data1, byte data2)
        {
            com_port_write[0] = comand;
            com_port_write[1] = data1;
            com_port_write[2] = data2;
            comport.DiscardInBuffer();
            comport.DiscardOutBuffer();
            Box_log.AppendText("Отправление команды на устройство:\r\n");
            Box_log.AppendText(comand.ToString() + " " + data1.ToString() + " " + data2.ToString() + "\r\n");
            comport.Write(com_port_write, 0, 3);
        }

        private void Comport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Box_log.AppendText("Чтение ответа:\r\n");
                int sizebuf = comport.BytesToRead;
                if (sizebuf == 3) // проеверяем скок пришло, если больше или меньше, то тут что-то не так
                {
                    for (int i = 0; i < sizebuf; i++)
                    {
                        com_port_read[i] = (byte)comport.ReadByte();
                        Box_log.AppendText(com_port_read.ToString() + " ");
                    }
                    Box_log.AppendText("\r\n");
                    Read = true;
                }
                else
                {
                    Box_log.AppendText("Ошибка чтения буфера: количество байтов не совпадает с необходимым.\r\n");
                    com_port_read[0] = Convert.ToByte('!');
                    com_port_read[1] = Convert.ToByte('!');
                    com_port_read[2] = Convert.ToByte('!');
                    Read = true;
                }
            }
            catch(TimeoutException exc)
            {
                Box_log.AppendText("Ошибка чтения буфера:" + exc.ToString() + "\r\n");
                com_port_read[0] = Convert.ToByte('!');
                com_port_read[1] = Convert.ToByte('!');
                com_port_read[2] = Convert.ToByte('!');
                Read = true;
            }
        }
    }
}
