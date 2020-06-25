using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace Program_for_diplom
{
    public interface IForm1
    { 
        string[] portNames { set; }
        string portName { get; }
        string temperature { get; }
        string time { get; }
        string distance { set; }
        string temperature_current { set; }
        string distance_current { set; }
        string measur_status { set; }
        string status_connect { set; }
        string status_installation { set; }
        string deep { set; }
        string flame_height { set; }
        string flame_width { set; }
        string flame_square { set; }
        event EventHandler Bt_con;
        event EventHandler Bt_izmer;
    }

    public partial class Form1 : Form, IForm1
    {
        private SerialPort _comport = new SerialPort();
        private byte[] _writeBuffer = new byte[3];
        private byte[] _readBuffer = new byte[3];
        private bool _readFlag, _connectionFlag = false;
        //short distance, temperature, temperature_current, distance_current = 0;
        int step_measurement = 0;
        string path = "";
        static string technical_Path = @"t_data.txt";
        List<Mat> frames;
        List<ImageProcessingResult> results;

        public string Data { get; set; } = "0";

        public Form1()
        {
            string[] portNames = SerialPort.GetPortNames();
            InitializeComponent();
            cbPortsName.Items.Clear();
            cbPortsName.Items.AddRange(portNames);
            lbStatus.ForeColor = Color.Red;
            lbStatus.Text = "Не подключено";
            if (!File.Exists(technical_Path))
            {
                File.Create(technical_Path).Close();
            }
        }

        public string[] portNames{
            set { cbPortsName.Items.AddRange(value); }
        }

        public string portName{
            get { return cbPortsName.SelectedItem.ToString(); }
        }

        public string temperature{
            get { return Bx_temp.Text; }
        }

        public string time{
            get { return Bx_time.Text; }
        }

        public string distance{
            set { Bx_distance.Text = value; }
        }

        public string temperature_current{
            set { lb_temp.Text = value; }
        }

        public string distance_current{
            set { lb_distance.Text = value; }
        }

        public string measur_status{
            set { lb_izmer.Text = value; }
        }

        public string status_connect{
            set { lbStatus.Text = value; }
        }

        public string status_installation{
            set { lb_Modeinst.Text = value; }
        }

        public string deep{
            set { lb_deep.Text = value; }
        }

        public string flame_height{
            set { lb_flame_height.Text = value; }
        }

        public string flame_width{
            set { lb_flame_weight.Text = value; }
        }

        public string flame_square{
            set { lb_flame_square.Text = value; }
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
            if (Bt_con != null) Bt_con(this, EventArgs.Empty);
        }

        private void bt_izmer_Click(object sender, EventArgs e)
        {
            if (Bt_izmer != null) Bt_izmer(this, EventArgs.Empty);
            if (step_measurement == 0)
            {
                Clear_res();
                lb_izmer.Text = "Выставьте\"0\" точку.";
                Managment("preparation_null");
                Thread.Sleep(125);
                Update_status();
                Preparation_for_measurement();
            }
            else
            {
                step_measurement = 0;
                Managment("measuring");
                Measurement();
            }
        }

        public event EventHandler Bt_con;
        public event EventHandler Bt_izmer;


        private void Preparation_for_measurement()
        {
            temperature = Convert.ToInt16(Bx_temp.Text);
            time = Convert.ToInt32(Bx_time.Text);
            rtbLogger.AppendText("Подготовка к измерению:\r\n");
            rtbLogger.AppendText("Создание папки.\r\n");
            Create_folder();
            File.Create(path + "/Result.txt").Close();
            StreamWriter sw = new StreamWriter(technical_Path, false, System.Text.Encoding.Default);
            sw.WriteLine(path + ", " + time.ToString());
            sw.Close();
            while (true)
            {
                Distance();
                Bx_distance.Text = distance.ToString();
                Write_uart(Convert.ToByte('H'), Convert.ToByte('H'), Convert.ToByte('H'));
                readCommand(3);
                if ((_readBuffer[0] == 85) && ((_readBuffer[2] & 0b01000000) == 0b01000000))
                {
                    break;
                }
                Thread.Sleep(125);
                Application.DoEvents();
            }
            Write_uart(Convert.ToByte('I'), Convert.ToByte('I'), Convert.ToByte('I'));
            lb_izmer.Text = "Разогрев проволоки.";
            rtbLogger.AppendText("Разогрев проволоки:\r\n");
            Write_uart(Convert.ToByte('C'), (byte)(temperature >> 8), (byte)(temperature & 0xFF));
            Thread.Sleep(100);
            Managment("pid");
            while (true)
            {
                Managment("temperature");
                readCommand(3);
                if (_readBuffer[0] == 87)
                {
                    temperature_current = (short)(((_readBuffer[1] << 8) | _readBuffer[2]) >> 4);
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
            lb_izmer.Text = "Проволока разогрета. Нажмите кнопку";
            bt_izmer.Text = "Измерение";
            step_measurement = 1;
        }

        private void Measurement()
        {
            Update_status();
            Stopwatch watch = new Stopwatch();
            lb_izmer.Text = "Проводится процесс измерения";
            bt_izmer.Enabled = false;
            int steps = (int)(time / 0.5);
            Start_python();
            for (int i = 0; i < steps; i++)
            {
                watch.Start();
                Managment("temperature");
                readCommand(3);
                if (_readBuffer[0] == 87)
                {
                    temperature_current = (short)(((_readBuffer[1] << 8) | _readBuffer[2]) >> 4);
                    lb_temp.Text = temperature_current.ToString();
                }
                Managment("distance");
                readCommand(3);
                if (_readBuffer[0] == 88)
                {
                    distance_current = (short)((_readBuffer[1] << 8) | _readBuffer[2]);
                }
                lb_distance.Text = distance_current.ToString();
                frames.Add(GetFrame(1, i));
                watch.Stop();
                if (i == 0)
                {
                    steps = (int)((time * 1000) / (int)watch.ElapsedMilliseconds);
                }
                else
                {
                    Thread.Sleep(1);
                }
                Application.DoEvents();
            }
            Managment("idle");
            lb_izmer.Text = "Ожидание обработки изображения";
            double max_height = 0;
            int index = 0;
            for (int i = 0; i < steps; i++)
            {
                results.Add(FrameAnalysis(frames[i], i, 0.125));
                if (results[i].Height > max_height)
                {
                    max_height = results[i].Height;
                    index = i;
                }
            }
            Result(index);
        }

        private void Result(int ind)
        {
            lb_izmer.Text = "";
            bt_izmer.Text = "Начать измерение";
            bt_izmer.Enabled = true;
            step_measurement = 0;
            short deep = (short)Math.Abs(distance - distance_current);
            Update_status();
            lb_deep.Text = deep.ToString();
            lb_flame_height.Text = results[ind].Height.ToString();
            lb_flame_weight.Text = results[ind].Width.ToString();
            lb_flame_square.Text = results[ind].Area.ToString();
            picture_result.Image = results[ind].Image.ToImage<Bgr, Byte>().ToBitmap();
            picture_result.SizeMode = PictureBoxSizeMode.Zoom;
            Write_uart(Convert.ToByte('K'), Convert.ToByte('K'), Convert.ToByte('K'));
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

        private void Clear_res()
        {
            lb_deep.Text = "";
            lb_distance.Text = "";
            lb_flame_height.Text = "";
            lb_flame_square.Text = "";
            lb_flame_weight.Text = "";
            lb_izmer.Text = "";
            lb_temp.Text = "";
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

        private void Start_python()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            start.Arguments = "Image.py";
            start.UseShellExecute = true;
            start.RedirectStandardOutput = false;
            start.CreateNoWindow = true;
            Process process = Process.Start(start);
        }

        private void Bt_izmer_Click(object sender, EventArgs e)
        {

        }

    }
}
