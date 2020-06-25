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
            this.lb_Modeinst = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Bx_temp = new System.Windows.Forms.TextBox();
            this.lb_temp = new System.Windows.Forms.Label();
            this.lb_izmer = new System.Windows.Forms.Label();
            this.bt_izmer = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lb_deep = new System.Windows.Forms.Label();
            this.lb_flame_height = new System.Windows.Forms.Label();
            this.lb_flame_weight = new System.Windows.Forms.Label();
            this.lb_flame_square = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Bx_distance = new System.Windows.Forms.TextBox();
            this.lb_distance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Bx_time = new System.Windows.Forms.TextBox();
            this.lb_time = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picture_result = new System.Windows.Forms.PictureBox();
            this.rtbLogger = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_result)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPortsName
            // 
            this.cbPortsName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPortsName.FormattingEnabled = true;
            this.cbPortsName.ItemHeight = 19;
            this.cbPortsName.Location = new System.Drawing.Point(11, 48);
            this.cbPortsName.Margin = new System.Windows.Forms.Padding(4);
            this.cbPortsName.Name = "cbPortsName";
            this.cbPortsName.Size = new System.Drawing.Size(99, 27);
            this.cbPortsName.TabIndex = 0;
            this.cbPortsName.SelectedIndexChanged += new System.EventHandler(this.comboPort_SelectedIndexChanged);
            // 
            // btConnect
            // 
            this.btConnect.Enabled = false;
            this.btConnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btConnect.Location = new System.Drawing.Point(118, 48);
            this.btConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btConnect.Name = "btConnect";
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
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatus.Location = new System.Drawing.Point(145, 80);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(2, 0, 4, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 19);
            this.lbStatus.TabIndex = 7;
            // 
            // lb_Modeinst
            // 
            this.lb_Modeinst.AutoSize = true;
            this.lb_Modeinst.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Modeinst.Location = new System.Drawing.Point(135, 100);
            this.lb_Modeinst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Modeinst.Name = "lb_Modeinst";
            this.lb_Modeinst.Size = new System.Drawing.Size(0, 19);
            this.lb_Modeinst.TabIndex = 8;
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
            // Bx_temp
            // 
            this.Bx_temp.Enabled = false;
            this.Bx_temp.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bx_temp.Location = new System.Drawing.Point(110, 27);
            this.Bx_temp.Margin = new System.Windows.Forms.Padding(2, 4, 4, 4);
            this.Bx_temp.Name = "Bx_temp";
            this.Bx_temp.Size = new System.Drawing.Size(110, 22);
            this.Bx_temp.TabIndex = 13;
            this.Bx_temp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_common);
            // 
            // lb_temp
            // 
            this.lb_temp.AutoSize = true;
            this.lb_temp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_temp.Location = new System.Drawing.Point(228, 30);
            this.lb_temp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_temp.Name = "lb_temp";
            this.lb_temp.Size = new System.Drawing.Size(0, 19);
            this.lb_temp.TabIndex = 15;
            // 
            // lb_izmer
            // 
            this.lb_izmer.AutoSize = true;
            this.lb_izmer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_izmer.Location = new System.Drawing.Point(7, 120);
            this.lb_izmer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_izmer.Name = "lb_izmer";
            this.lb_izmer.Size = new System.Drawing.Size(0, 19);
            this.lb_izmer.TabIndex = 18;
            // 
            // bt_izmer
            // 
            this.bt_izmer.Enabled = false;
            this.bt_izmer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_izmer.Location = new System.Drawing.Point(7, 145);
            this.bt_izmer.Margin = new System.Windows.Forms.Padding(4);
            this.bt_izmer.Name = "bt_izmer";
            this.bt_izmer.Size = new System.Drawing.Size(145, 34);
            this.bt_izmer.TabIndex = 19;
            this.bt_izmer.Text = "Начать измерение";
            this.bt_izmer.UseVisualStyleBackColor = true;
            this.bt_izmer.Click += new System.EventHandler(this.Bt_izmer_Click);
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
            // lb_deep
            // 
            this.lb_deep.AutoSize = true;
            this.lb_deep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_deep.Location = new System.Drawing.Point(150, 25);
            this.lb_deep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_deep.Name = "lb_deep";
            this.lb_deep.Size = new System.Drawing.Size(0, 19);
            this.lb_deep.TabIndex = 25;
            // 
            // lb_flame_height
            // 
            this.lb_flame_height.AutoSize = true;
            this.lb_flame_height.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_flame_height.Location = new System.Drawing.Point(150, 44);
            this.lb_flame_height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_flame_height.Name = "lb_flame_height";
            this.lb_flame_height.Size = new System.Drawing.Size(0, 19);
            this.lb_flame_height.TabIndex = 26;
            // 
            // lb_flame_weight
            // 
            this.lb_flame_weight.AutoSize = true;
            this.lb_flame_weight.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_flame_weight.Location = new System.Drawing.Point(150, 63);
            this.lb_flame_weight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_flame_weight.Name = "lb_flame_weight";
            this.lb_flame_weight.Size = new System.Drawing.Size(0, 19);
            this.lb_flame_weight.TabIndex = 27;
            // 
            // lb_flame_square
            // 
            this.lb_flame_square.AutoSize = true;
            this.lb_flame_square.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_flame_square.Location = new System.Drawing.Point(150, 82);
            this.lb_flame_square.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_flame_square.Name = "lb_flame_square";
            this.lb_flame_square.Size = new System.Drawing.Size(0, 19);
            this.lb_flame_square.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPortsName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btConnect);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lb_Modeinst);
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
            this.groupBox2.Controls.Add(this.Bx_distance);
            this.groupBox2.Controls.Add(this.lb_distance);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Bx_time);
            this.groupBox2.Controls.Add(this.lb_time);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Bx_temp);
            this.groupBox2.Controls.Add(this.lb_temp);
            this.groupBox2.Controls.Add(this.lb_izmer);
            this.groupBox2.Controls.Add(this.bt_izmer);
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
            // Bx_distance
            // 
            this.Bx_distance.Enabled = false;
            this.Bx_distance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bx_distance.Location = new System.Drawing.Point(110, 87);
            this.Bx_distance.Margin = new System.Windows.Forms.Padding(2, 4, 4, 4);
            this.Bx_distance.Name = "Bx_distance";
            this.Bx_distance.ReadOnly = true;
            this.Bx_distance.Size = new System.Drawing.Size(110, 22);
            this.Bx_distance.TabIndex = 20;
            // 
            // lb_distance
            // 
            this.lb_distance.AutoSize = true;
            this.lb_distance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_distance.Location = new System.Drawing.Point(228, 90);
            this.lb_distance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_distance.Name = "lb_distance";
            this.lb_distance.Size = new System.Drawing.Size(0, 19);
            this.lb_distance.TabIndex = 21;
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
            // Bx_time
            // 
            this.Bx_time.Enabled = false;
            this.Bx_time.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bx_time.Location = new System.Drawing.Point(110, 57);
            this.Bx_time.Margin = new System.Windows.Forms.Padding(2, 4, 4, 4);
            this.Bx_time.Name = "Bx_time";
            this.Bx_time.Size = new System.Drawing.Size(110, 22);
            this.Bx_time.TabIndex = 17;
            this.Bx_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_common);
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_time.Location = new System.Drawing.Point(228, 60);
            this.lb_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(0, 19);
            this.lb_time.TabIndex = 18;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picture_result);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.lb_flame_square);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.lb_flame_weight);
            this.groupBox3.Controls.Add(this.lb_deep);
            this.groupBox3.Controls.Add(this.lb_flame_height);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 346);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Результаты:";
            // 
            // picture_result
            // 
            this.picture_result.Location = new System.Drawing.Point(6, 104);
            this.picture_result.Name = "picture_result";
            this.picture_result.Size = new System.Drawing.Size(308, 236);
            this.picture_result.TabIndex = 29;
            this.picture_result.TabStop = false;
            // 
            // rtbLogger
            // 
            this.rtbLogger.Location = new System.Drawing.Point(12, 365);
            this.rtbLogger.Multiline = true;
            this.rtbLogger.Name = "rtbLogger";
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
            ((System.ComponentModel.ISupportInitialize)(this.picture_result)).EndInit();
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
        private System.Windows.Forms.Label lb_Modeinst;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Bx_temp;
        private System.Windows.Forms.Label lb_temp;
        private System.Windows.Forms.Label lb_izmer;
        private System.Windows.Forms.Button bt_izmer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lb_deep;
        private System.Windows.Forms.Label lb_flame_height;
        private System.Windows.Forms.Label lb_flame_weight;
        private System.Windows.Forms.Label lb_flame_square;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Bx_time;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Bx_distance;
        private System.Windows.Forms.Label lb_distance;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox rtbLogger;
        private System.Windows.Forms.PictureBox picture_result;
    }
}

