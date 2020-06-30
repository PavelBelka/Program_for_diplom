using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_for_diplom
{
    class Measurement
    {
        private short distance, temperature, temperature_current, distance_current = 0;
        public Measurement(){

        }

        private void Preparation_for_measurement()
        {
            /*temperature = Convert.ToInt16(Bx_temp.Text);
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
            step_measurement = 1;*/
        }

        private void Measurement2()
        {
           /* Update_status();
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
            Result(index);*/
        }

        private void Result(int ind)
        {
            /*lb_izmer.Text = "";
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
            Write_uart(Convert.ToByte('K'), Convert.ToByte('K'), Convert.ToByte('K'));*/
        }

        private void Distance()
        {
            /*Managment("distance");
            readCommand(3);
            if (_readBuffer[0] == 88)
            {
                distance = (short)((_readBuffer[1] << 8) | _readBuffer[2]);
            }
            else
            {
                distance = 0;
            }*/
        }

        private void Clear_res()
        {
            /*lb_deep.Text = "";
            lb_distance.Text = "";
            lb_flame_height.Text = "";
            lb_flame_square.Text = "";
            lb_flame_weight.Text = "";
            lb_izmer.Text = "";
            lb_temp.Text = "";*/
        }
    }
}
