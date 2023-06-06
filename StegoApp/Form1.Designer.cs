namespace stego_app
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LoadContainer = new System.Windows.Forms.Button();
            this.ImgContainerPlus = new System.Windows.Forms.Button();
            this.ImgContainerMinus = new System.Windows.Forms.Button();
            this.LoadSecret = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.start_calc = new System.Windows.Forms.Button();
            this.save_file = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ImgSecretPlus = new System.Windows.Forms.Button();
            this.ImgSecretMinus = new System.Windows.Forms.Button();
            this.ImgComposeMinus = new System.Windows.Forms.Button();
            this.ImgComposePlus = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.задачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnalyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(117, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 442);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 442);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(922, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 442);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(472, 442);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // LoadContainer
            // 
            this.LoadContainer.Location = new System.Drawing.Point(287, 505);
            this.LoadContainer.Name = "LoadContainer";
            this.LoadContainer.Size = new System.Drawing.Size(128, 23);
            this.LoadContainer.TabIndex = 2;
            this.LoadContainer.Text = "Выбрать контейнер";
            this.LoadContainer.UseVisualStyleBackColor = true;
            this.LoadContainer.Click += new System.EventHandler(this.LoadContainerBtn_Click);
            // 
            // ImgContainerPlus
            // 
            this.ImgContainerPlus.Location = new System.Drawing.Point(609, 341);
            this.ImgContainerPlus.Name = "ImgContainerPlus";
            this.ImgContainerPlus.Size = new System.Drawing.Size(24, 23);
            this.ImgContainerPlus.TabIndex = 3;
            this.ImgContainerPlus.Text = "+";
            this.ImgContainerPlus.UseVisualStyleBackColor = true;
            this.ImgContainerPlus.Click += new System.EventHandler(this.ImgContainerPlus_Click);
            // 
            // ImgContainerMinus
            // 
            this.ImgContainerMinus.Location = new System.Drawing.Point(609, 371);
            this.ImgContainerMinus.Name = "ImgContainerMinus";
            this.ImgContainerMinus.Size = new System.Drawing.Size(24, 23);
            this.ImgContainerMinus.TabIndex = 4;
            this.ImgContainerMinus.Text = "-";
            this.ImgContainerMinus.UseVisualStyleBackColor = true;
            this.ImgContainerMinus.Click += new System.EventHandler(this.ImgContainerMinus_Click);
            // 
            // LoadSecret
            // 
            this.LoadSecret.Location = new System.Drawing.Point(1128, 505);
            this.LoadSecret.Name = "LoadSecret";
            this.LoadSecret.Size = new System.Drawing.Size(111, 23);
            this.LoadSecret.TabIndex = 5;
            this.LoadSecret.Text = "Выбрать секрет";
            this.LoadSecret.UseVisualStyleBackColor = true;
            this.LoadSecret.Click += new System.EventHandler(this.LoadSecret_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(667, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите метод";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 54);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(68, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "LSB 2 bit";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 77);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Gray";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "LSB 1 bit";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // start_calc
            // 
            this.start_calc.Location = new System.Drawing.Point(720, 317);
            this.start_calc.Name = "start_calc";
            this.start_calc.Size = new System.Drawing.Size(75, 23);
            this.start_calc.TabIndex = 9;
            this.start_calc.Text = "Встроить";
            this.start_calc.UseVisualStyleBackColor = true;
            this.start_calc.Click += new System.EventHandler(this.Start_calc_Click);
            // 
            // save_file
            // 
            this.save_file.Location = new System.Drawing.Point(685, 359);
            this.save_file.Name = "save_file";
            this.save_file.Size = new System.Drawing.Size(139, 23);
            this.save_file.TabIndex = 10;
            this.save_file.Text = "Сохранить  результат";
            this.save_file.UseVisualStyleBackColor = true;
            this.save_file.Click += new System.EventHandler(this.Save_file_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(520, 540);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 442);
            this.panel3.TabIndex = 11;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(472, 561);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(163, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Контейнер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(955, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Секрет";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(554, 513);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Контейнер с секретом";
            // 
            // ImgSecretPlus
            // 
            this.ImgSecretPlus.Location = new System.Drawing.Point(1414, 341);
            this.ImgSecretPlus.Name = "ImgSecretPlus";
            this.ImgSecretPlus.Size = new System.Drawing.Size(24, 23);
            this.ImgSecretPlus.TabIndex = 6;
            this.ImgSecretPlus.Text = "+";
            this.ImgSecretPlus.UseVisualStyleBackColor = true;
            this.ImgSecretPlus.Click += new System.EventHandler(this.ImgSecretPlus_Click);
            // 
            // ImgSecretMinus
            // 
            this.ImgSecretMinus.Location = new System.Drawing.Point(1414, 371);
            this.ImgSecretMinus.Name = "ImgSecretMinus";
            this.ImgSecretMinus.Size = new System.Drawing.Size(24, 23);
            this.ImgSecretMinus.TabIndex = 7;
            this.ImgSecretMinus.Text = "-";
            this.ImgSecretMinus.UseVisualStyleBackColor = true;
            this.ImgSecretMinus.Click += new System.EventHandler(this.ImgSecretMinus_Click);
            // 
            // ImgComposeMinus
            // 
            this.ImgComposeMinus.Location = new System.Drawing.Point(1015, 855);
            this.ImgComposeMinus.Name = "ImgComposeMinus";
            this.ImgComposeMinus.Size = new System.Drawing.Size(24, 23);
            this.ImgComposeMinus.TabIndex = 16;
            this.ImgComposeMinus.Text = "-";
            this.ImgComposeMinus.UseVisualStyleBackColor = true;
            this.ImgComposeMinus.Click += new System.EventHandler(this.ImgComposeMinus_Click);
            // 
            // ImgComposePlus
            // 
            this.ImgComposePlus.Location = new System.Drawing.Point(1015, 825);
            this.ImgComposePlus.Name = "ImgComposePlus";
            this.ImgComposePlus.Size = new System.Drawing.Size(24, 23);
            this.ImgComposePlus.TabIndex = 15;
            this.ImgComposePlus.Text = "+";
            this.ImgComposePlus.UseVisualStyleBackColor = true;
            this.ImgComposePlus.Click += new System.EventHandler(this.ImgComposePlus_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.задачиToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1516, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // задачиToolStripMenuItem
            // 
            this.задачиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CodingToolStripMenuItem,
            this.AnalyseToolStripMenuItem});
            this.задачиToolStripMenuItem.Name = "задачиToolStripMenuItem";
            this.задачиToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.задачиToolStripMenuItem.Text = "Задачи";
            // 
            // CodingToolStripMenuItem
            // 
            this.CodingToolStripMenuItem.Name = "CodingToolStripMenuItem";
            this.CodingToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.CodingToolStripMenuItem.Text = "Встраивание изображения";
            this.CodingToolStripMenuItem.Click += new System.EventHandler(this.CodingToolStripMenuItem_Click);
            // 
            // AnalyseToolStripMenuItem
            // 
            this.AnalyseToolStripMenuItem.Name = "AnalyseToolStripMenuItem";
            this.AnalyseToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.AnalyseToolStripMenuItem.Text = "Анализ изображения";
            this.AnalyseToolStripMenuItem.Click += new System.EventHandler(this.AnalyseToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1516, 1050);
            this.Controls.Add(this.ImgComposeMinus);
            this.Controls.Add(this.ImgComposePlus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.save_file);
            this.Controls.Add(this.start_calc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ImgSecretMinus);
            this.Controls.Add(this.ImgSecretPlus);
            this.Controls.Add(this.LoadSecret);
            this.Controls.Add(this.ImgContainerMinus);
            this.Controls.Add(this.ImgContainerPlus);
            this.Controls.Add(this.LoadContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Steganography Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button LoadContainer;
        private System.Windows.Forms.Button ImgContainerPlus;
        private System.Windows.Forms.Button ImgContainerMinus;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button LoadSecret;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button start_calc;
        private System.Windows.Forms.Button save_file;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ImgSecretPlus;
        private System.Windows.Forms.Button ImgSecretMinus;
        private System.Windows.Forms.Button ImgComposeMinus;
        private System.Windows.Forms.Button ImgComposePlus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem задачиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnalyseToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}

