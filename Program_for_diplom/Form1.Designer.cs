namespace Program_for_diplom
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbPortsName = new System.Windows.Forms.ComboBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lab_statusinst = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Box_temp = new System.Windows.Forms.TextBox();
            this.lab_temp = new System.Windows.Forms.Label();
            this.lab_izm = new System.Windows.Forms.Label();
            this.button_izm = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lab_deep = new System.Windows.Forms.Label();
            this.lab_flame_height = new System.Windows.Forms.Label();
            this.lab_flame_weight = new System.Windows.Forms.Label();
            this.lab_flame_square = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Box_dist = new System.Windows.Forms.TextBox();
            this.lab_dist = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Box_time = new System.Windows.Forms.TextBox();
            this.lab_time = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbLogger = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboPort
            // 
            this.cbPortsName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPortsName.FormattingEnabled = true;
            this.cbPortsName.ItemHeight = 19;
            this.cbPortsName.Location = new System.Drawing.Point(11, 48);
            this.cbPortsName.Margin = new System.Windows.Forms.Padding(4);
            this.cbPortsName.Name = "comboPort";
            this.cbPortsName.Size = new System.Drawing.Size(99, 27);
            this.cbPortsName.TabIndex = 0;
            this.cbPortsName.SelectedIndexChanged += new System.EventHandler(this.comboPort_SelectedIndexChanged);
            // 
            // Button_con
            // 
            this.btConnect.Enabled = false;
            this.btConnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btConnect.Location = new System.Drawing.Point(118, 48);
            this.btConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btConnect.Name = "Button_con";
            this.btConnect.Size = new System.Drawing.Size(105, 29);
            this.btConnect.TabIndex = 1;
            this.btConnect.Text = "Соединение";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.Button_con_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порт для соединения:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Статус соединения:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Статус установки:";
            // 
            // lab_statuscon
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatus.Location = new System.Drawing.Point(145, 80);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(2, 0, 4, 0);
            this.lbStatus.Name = "lab_statuscon";
            this.lbStatus.Size = new System.Drawing.Size(0, 19);
            this.lbStatus.TabIndex = 7;
            // 
            // lab_statusinst
            // 
            this.lab_statusinst.AutoSize = true;
            this.lab_statusinst.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_statusinst.Location = new System.Drawing.Point(135, 100);
            this.lab_statusinst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_statusinst.Name = "lab_statusinst";
            this.lab_statusinst.Size = new System.Drawing.Size(0, 19);
            this.lab_statusinst.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(7, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "Температура:";
            // 
            // Box_temp
            // 
            this.Box_temp.Enabled = false;
            this.Box_temp.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Box_temp.Location = new System.Drawing.Point(110, 27);
            this.Box_temp.Margin = new System.Windows.Forms.Padding(2, 4, 4, 4);
            this.Box_temp.Name = "Box_temp";
            this.Box_temp.Size = new System.Drawing.Size(110, 22);
            this.Box_temp.TabIndex = 13;
            // 
            // lab_temp
            // 
            this.lab_temp.AutoSize = true;
            this.lab_temp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_temp.Location = new System.Drawing.Point(228, 30);
            this.lab_temp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_temp.Name = "lab_temp";
            this.lab_temp.Size = new System.Drawing.Size(42, 19);
            this.lab_temp.TabIndex = 15;
            this.lab_temp.Text = "темп";
            // 
            // lab_izm
            // 
            this.lab_izm.AutoSize = true;
            this.lab_izm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_izm.Location = new System.Drawing.Point(7, 120);
            this.lab_izm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_izm.Name = "lab_izm";
            this.lab_izm.Size = new System.Drawing.Size(51, 19);
            this.lab_izm.TabIndex = 18;
            this.lab_izm.Text = "сообщ";
            // 
            // button_izm
            // 
            this.button_izm.Enabled = false;
            this.button_izm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_izm.Location = new System.Drawing.Point(7, 145);
            this.button_izm.Margin = new System.Windows.Forms.Padding(4);
            this.button_izm.Name = "button_izm";
            this.button_izm.Size = new System.Drawing.Size(145, 34);
            this.button_izm.TabIndex = 19;
            this.button_izm.Text = "Начать измерение";
            this.button_izm.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(7, 25);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(145, 19);
            this.label16.TabIndex = 21;
            this.label16.Text = "Глубина вхождения:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(7, 44);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 19);
            this.label17.TabIndex = 22;
            this.label17.Text = "Высота пламени:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(7, 63);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(132, 19);
            this.label18.TabIndex = 23;
            this.label18.Text = "Ширина пламени:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(7, 82);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(135, 19);
            this.label19.TabIndex = 24;
            this.label19.Text = "Площадь пламени:";
            // 
            // lab_deep
            // 
            this.lab_deep.AutoSize = true;
            this.lab_deep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_deep.Location = new System.Drawing.Point(150, 25);
            this.lab_deep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_deep.Name = "lab_deep";
            this.lab_deep.Size = new System.Drawing.Size(30, 19);
            this.lab_deep.TabIndex = 25;
            this.lab_deep.Text = "ога";
            // 
            // lab_flame_height
            // 
            this.lab_flame_height.AutoSize = true;
            this.lab_flame_height.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_flame_height.Location = new System.Drawing.Point(150, 44);
            this.lab_flame_height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_flame_height.Name = "lab_flame_height";
            this.lab_flame_height.Size = new System.Drawing.Size(30, 19);
            this.lab_flame_height.TabIndex = 26;
            this.lab_flame_height.Text = "ога";
            // 
            // lab_flame_weight
            // 
            this.lab_flame_weight.AutoSize = true;
            this.lab_flame_weight.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_flame_weight.Location = new System.Drawing.Point(150, 63);
            this.lab_flame_weight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_flame_weight.Name = "lab_flame_weight";
            this.lab_flame_weight.Size = new System.Drawing.Size(30, 19);
            this.lab_flame_weight.TabIndex = 27;
            this.lab_flame_weight.Text = "ога";
            // 
            // lab_flame_square
            // 
            this.lab_flame_square.AutoSize = true;
            this.lab_flame_square.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_flame_square.Location = new System.Drawing.Point(150, 82);
            this.lab_flame_square.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_flame_square.Name = "lab_flame_square";
            this.lab_flame_square.Size = new System.Drawing.Size(30, 19);
            this.lab_flame_square.TabIndex = 28;
            this.lab_flame_square.Text = "ога";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPortsName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btConnect);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lab_statusinst);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(338, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 140);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Соединение с устройством";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.Box_dist);
            this.groupBox2.Controls.Add(this.lab_dist);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Box_time);
            this.groupBox2.Controls.Add(this.lab_time);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Box_temp);
            this.groupBox2.Controls.Add(this.lab_temp);
            this.groupBox2.Controls.Add(this.lab_izm);
            this.groupBox2.Controls.Add(this.button_izm);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(338, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 200);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры эксперимента";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(7, 90);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "Расстояние:";
            // 
            // Box_dist
            // 
            this.Box_dist.Enabled = false;
            this.Box_dist.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Box_dist.Location = new System.Drawing.Point(110, 87);
            this.Box_dist.Margin = new System.Windows.Forms.Padding(2, 4, 4, 4);
            this.Box_dist.Name = "Box_dist";
            this.Box_dist.ReadOnly = true;
            this.Box_dist.Size = new System.Drawing.Size(110, 22);
            this.Box_dist.TabIndex = 20;
            // 
            // lab_dist
            // 
            this.lab_dist.AutoSize = true;
            this.lab_dist.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_dist.Location = new System.Drawing.Point(228, 90);
            this.lab_dist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_dist.Name = "lab_dist";
            this.lab_dist.Size = new System.Drawing.Size(45, 19);
            this.lab_dist.TabIndex = 21;
            this.lab_dist.Text = "расст";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Время:";
            // 
            // Box_time
            // 
            this.Box_time.Enabled = false;
            this.Box_time.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Box_time.Location = new System.Drawing.Point(110, 57);
            this.Box_time.Margin = new System.Windows.Forms.Padding(2, 4, 4, 4);
            this.Box_time.Name = "Box_time";
            this.Box_time.Size = new System.Drawing.Size(110, 22);
            this.Box_time.TabIndex = 17;
            // 
            // lab_time
            // 
            this.lab_time.AutoSize = true;
            this.lab_time.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_time.Location = new System.Drawing.Point(228, 60);
            this.lab_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(49, 19);
            this.lab_time.TabIndex = 18;
            this.lab_time.Text = "время";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.lab_flame_square);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.lab_flame_weight);
            this.groupBox3.Controls.Add(this.lab_deep);
            this.groupBox3.Controls.Add(this.lab_flame_height);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 346);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Результаты:";
            // 
            // Box_log
            // 
            this.rtbLogger.Location = new System.Drawing.Point(12, 365);
            this.rtbLogger.Multiline = true;
            this.rtbLogger.Name = "Box_log";
            this.rtbLogger.ReadOnly = true;
            this.rtbLogger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rtbLogger.Size = new System.Drawing.Size(646, 200);
            this.rtbLogger.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 571);
            this.Controls.Add(this.rtbLogger);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Управление установкой";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPortsName;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lab_statusinst;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Box_temp;
        private System.Windows.Forms.Label lab_temp;
        private System.Windows.Forms.Label lab_izm;
        private System.Windows.Forms.Button button_izm;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lab_deep;
        private System.Windows.Forms.Label lab_flame_height;
        private System.Windows.Forms.Label lab_flame_weight;
        private System.Windows.Forms.Label lab_flame_square;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Box_time;
        private System.Windows.Forms.Label lab_time;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Box_dist;
        private System.Windows.Forms.Label lab_dist;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox rtbLogger;
    }
}

