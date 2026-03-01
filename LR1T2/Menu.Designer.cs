namespace LR1T2
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            LabWork1_Button = new Button();
            LabWork2_Button = new Button();
            LabWork3_Button = new Button();
            LabWork4_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(261, 30);
            label1.TabIndex = 0;
            label1.Text = "Компьютерная графика";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(3, 48);
            label2.Name = "label2";
            label2.Size = new Size(255, 15);
            label2.TabIndex = 1;
            label2.Text = "Работу выполнили студенты 514-1 группы:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 63);
            label3.Name = "label3";
            label3.Size = new Size(91, 60);
            label3.TabIndex = 2;
            label3.Text = "Байдин И. В.\r\nВоропаев К. И.\r\nДудник Е. Ю.\r\nМировнов А. Е.";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 144);
            label4.Name = "label4";
            label4.Size = new Size(108, 30);
            label4.TabIndex = 3;
            label4.Text = "Доцент каф. КСУП\r\nХабибулина Н. Ю.\r\n";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(3, 129);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 4;
            label5.Text = "Преподаватель:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.tusur;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(518, 105);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(12, 123);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 207);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(LabWork4_Button);
            panel2.Controls.Add(LabWork3_Button);
            panel2.Controls.Add(LabWork2_Button);
            panel2.Controls.Add(LabWork1_Button);
            panel2.Location = new Point(298, 123);
            panel2.Name = "panel2";
            panel2.Size = new Size(232, 207);
            panel2.TabIndex = 7;
            // 
            // LabWork1_Button
            // 
            LabWork1_Button.Location = new Point(3, 16);
            LabWork1_Button.Name = "LabWork1_Button";
            LabWork1_Button.Size = new Size(226, 32);
            LabWork1_Button.TabIndex = 0;
            LabWork1_Button.Text = "Лабораторная работа 1";
            LabWork1_Button.UseVisualStyleBackColor = true;
            LabWork1_Button.Click += LabWork1_Button_Click;
            // 
            // LabWork2_Button
            // 
            LabWork2_Button.Location = new Point(3, 54);
            LabWork2_Button.Name = "LabWork2_Button";
            LabWork2_Button.Size = new Size(226, 32);
            LabWork2_Button.TabIndex = 1;
            LabWork2_Button.Text = "Лабораторная работа 2";
            LabWork2_Button.UseVisualStyleBackColor = true;
            LabWork2_Button.Click += LabWork2_Button_Click;
            // 
            // LabWork3_Button
            // 
            LabWork3_Button.Location = new Point(3, 92);
            LabWork3_Button.Name = "LabWork3_Button";
            LabWork3_Button.Size = new Size(226, 32);
            LabWork3_Button.TabIndex = 2;
            LabWork3_Button.Text = "Лабораторная работа 3";
            LabWork3_Button.UseVisualStyleBackColor = true;
            LabWork3_Button.Click += LabWork3_Button_Click;
            // 
            // LabWork4_Button
            // 
            LabWork4_Button.Location = new Point(3, 130);
            LabWork4_Button.Name = "LabWork4_Button";
            LabWork4_Button.Size = new Size(226, 32);
            LabWork4_Button.TabIndex = 3;
            LabWork4_Button.Text = "Лабораторная работа 4";
            LabWork4_Button.UseVisualStyleBackColor = true;
            LabWork4_Button.Click += LabWork4_Button_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(542, 342);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "Menu";
            Text = "Компьютерная графика";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private Button LabWork4_Button;
        private Button LabWork3_Button;
        private Button LabWork2_Button;
        private Button LabWork1_Button;
    }
}