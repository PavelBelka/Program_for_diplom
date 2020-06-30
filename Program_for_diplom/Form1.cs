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
        string log { set; }

        event EventHandler Bt_con;
        event EventHandler Bt_izmer;
    }

    public partial class Form1 : Form, IForm1
    {
        int step_measurement = 0;
        string path = "";
        static string technical_Path = @"t_data.txt";
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

        public string log{
            set { rtbLogger.AppendText(value); }
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

        private void Bt_izmer_Click(object sender, EventArgs e)
        {
            if (Bt_izmer != null) Bt_izmer(this, EventArgs.Empty);
            /*if (step_measurement == 0)
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
            }*/
        }

        public event EventHandler Bt_con;
        public event EventHandler Bt_izmer;
    }
}
