using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_for_diplom
{
    class Presenter
    {
        private readonly IForm1 _form;
        private object _install;
        private bool _connectionFlag = false;

        public Presenter(IForm1 form, object install)
        {
            _form = form;
            _install = install;
            _form.Bt_con += _form_Bt_con;
        }

        private void _form_Bt_con(object sender, EventArgs e)
        {
            if (_connectionFlag == false)
            {
                //rtbLogger.AppendText("Выбран порт: " + portName + "\r\n");
                //Connect(_form.portName);
            }
            else if (_connectionFlag == true)
            {
                //btConnect.Text = "Соединение";
                _form.status_connect = "Не подключено";
                //lbStatus.ForeColor = Color.Red;
                //_connectionFlag = false;
                //_comport.Close();
                //bt_izmer.Enabled = false;
                _form.status_installation = "";
                //Clear_res();
            }
        }

    }
}
