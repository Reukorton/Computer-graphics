namespace LR1T2
{
    partial class Form4
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            Start_Button = new Button();
            Draw_axes_Button = new Button();
            panel1 = new Panel();
            groupBox4 = new GroupBox();
            Continuous_Scale_Up_Button = new Button();
            Continuous_Rotate_Button = new Button();
            Continuous_Shift_Button = new Button();
            Rotate_Left_Button = new Button();
            Rotate_Right_Button = new Button();
            Reflect_OX_Button = new Button();
            Reflect_OY_Button = new Button();
            Scale_Down_Button = new Button();
            Scale_Up_Button = new Button();
            groupBox3 = new GroupBox();
            Variant3_Button = new Button();
            Variant4_Button = new Button();
            Variant13_Button = new Button();
            Variant11_Button = new Button();
            groupBox1 = new GroupBox();
            Сlear = new Button();
            groupBox2 = new GroupBox();
            Shift_Right_Button = new Button();
            Shift_Left_Button = new Button();
            Shift_Up_Button = new Button();
            Shift_Down_Button = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            Continuous_Scale_Down_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(9, 9);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(515, 506);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Start_Button
            // 
            Start_Button.FlatStyle = FlatStyle.Popup;
            Start_Button.Location = new Point(6, 84);
            Start_Button.Name = "Start_Button";
            Start_Button.Size = new Size(124, 23);
            Start_Button.TabIndex = 2;
            Start_Button.Text = "Старт";
            Start_Button.UseVisualStyleBackColor = true;
            Start_Button.Click += Start_Button_Click;
            // 
            // Draw_axes_Button
            // 
            Draw_axes_Button.FlatStyle = FlatStyle.Popup;
            Draw_axes_Button.Location = new Point(6, 22);
            Draw_axes_Button.Name = "Draw_axes_Button";
            Draw_axes_Button.Size = new Size(124, 27);
            Draw_axes_Button.TabIndex = 3;
            Draw_axes_Button.Text = "Нарисовать оси";
            Draw_axes_Button.UseVisualStyleBackColor = true;
            Draw_axes_Button.Click += Draw_axes_Button_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(groupBox2);
            panel1.Location = new Point(527, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(390, 503);
            panel1.TabIndex = 2;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(Continuous_Scale_Down_Button);
            groupBox4.Controls.Add(Continuous_Scale_Up_Button);
            groupBox4.Controls.Add(Continuous_Rotate_Button);
            groupBox4.Controls.Add(Continuous_Shift_Button);
            groupBox4.Controls.Add(Rotate_Left_Button);
            groupBox4.Controls.Add(Rotate_Right_Button);
            groupBox4.Controls.Add(Reflect_OX_Button);
            groupBox4.Controls.Add(Reflect_OY_Button);
            groupBox4.Controls.Add(Scale_Down_Button);
            groupBox4.Controls.Add(Scale_Up_Button);
            groupBox4.Location = new Point(3, 116);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(136, 341);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "преобразования";
            // 
            // Continuous_Scale_Up_Button
            // 
            Continuous_Scale_Up_Button.FlatStyle = FlatStyle.Popup;
            Continuous_Scale_Up_Button.Location = new Point(6, 273);
            Continuous_Scale_Up_Button.Name = "Continuous_Scale_Up_Button";
            Continuous_Scale_Up_Button.Size = new Size(124, 27);
            Continuous_Scale_Up_Button.TabIndex = 8;
            Continuous_Scale_Up_Button.Text = "Неп Увеличить";
            Continuous_Scale_Up_Button.UseVisualStyleBackColor = true;
            Continuous_Scale_Up_Button.Click += Continuous_Scale_Up_Button_Click;
            // 
            // Continuous_Rotate_Button
            // 
            Continuous_Rotate_Button.FlatStyle = FlatStyle.Popup;
            Continuous_Rotate_Button.Location = new Point(6, 240);
            Continuous_Rotate_Button.Name = "Continuous_Rotate_Button";
            Continuous_Rotate_Button.Size = new Size(124, 27);
            Continuous_Rotate_Button.TabIndex = 7;
            Continuous_Rotate_Button.Text = "Неп Поворот";
            Continuous_Rotate_Button.UseVisualStyleBackColor = true;
            Continuous_Rotate_Button.Click += Continuous_Rotate_Button_Click;
            // 
            // Continuous_Shift_Button
            // 
            Continuous_Shift_Button.FlatStyle = FlatStyle.Popup;
            Continuous_Shift_Button.Location = new Point(6, 207);
            Continuous_Shift_Button.Name = "Continuous_Shift_Button";
            Continuous_Shift_Button.Size = new Size(124, 27);
            Continuous_Shift_Button.TabIndex = 6;
            Continuous_Shift_Button.Text = "Неп Сдвиг";
            Continuous_Shift_Button.UseVisualStyleBackColor = true;
            Continuous_Shift_Button.Click += Continuous_Shift_Button_Click;
            // 
            // Rotate_Left_Button
            // 
            Rotate_Left_Button.FlatStyle = FlatStyle.Popup;
            Rotate_Left_Button.Location = new Point(6, 176);
            Rotate_Left_Button.Name = "Rotate_Left_Button";
            Rotate_Left_Button.Size = new Size(124, 25);
            Rotate_Left_Button.TabIndex = 11;
            Rotate_Left_Button.Text = "Поворот влево";
            Rotate_Left_Button.UseVisualStyleBackColor = true;
            Rotate_Left_Button.Click += Rotate_Left_Button_Click;
            // 
            // Rotate_Right_Button
            // 
            Rotate_Right_Button.FlatStyle = FlatStyle.Popup;
            Rotate_Right_Button.Location = new Point(6, 145);
            Rotate_Right_Button.Name = "Rotate_Right_Button";
            Rotate_Right_Button.Size = new Size(124, 25);
            Rotate_Right_Button.TabIndex = 10;
            Rotate_Right_Button.Text = "Поворот вправо";
            Rotate_Right_Button.UseVisualStyleBackColor = true;
            Rotate_Right_Button.Click += Rotate_Right_Button_Click;
            // 
            // Reflect_OX_Button
            // 
            Reflect_OX_Button.FlatStyle = FlatStyle.Popup;
            Reflect_OX_Button.Location = new Point(6, 22);
            Reflect_OX_Button.Name = "Reflect_OX_Button";
            Reflect_OX_Button.Size = new Size(124, 27);
            Reflect_OX_Button.TabIndex = 6;
            Reflect_OX_Button.Text = "Отразить OX";
            Reflect_OX_Button.UseVisualStyleBackColor = true;
            Reflect_OX_Button.Click += Reflect_OX_Button_Click;
            // 
            // Reflect_OY_Button
            // 
            Reflect_OY_Button.FlatStyle = FlatStyle.Popup;
            Reflect_OY_Button.Location = new Point(6, 55);
            Reflect_OY_Button.Name = "Reflect_OY_Button";
            Reflect_OY_Button.Size = new Size(124, 27);
            Reflect_OY_Button.TabIndex = 7;
            Reflect_OY_Button.Text = "Отразить OY";
            Reflect_OY_Button.UseVisualStyleBackColor = true;
            Reflect_OY_Button.Click += Reflect_OY_Button_Click;
            // 
            // Scale_Down_Button
            // 
            Scale_Down_Button.FlatStyle = FlatStyle.Popup;
            Scale_Down_Button.Location = new Point(6, 114);
            Scale_Down_Button.Name = "Scale_Down_Button";
            Scale_Down_Button.Size = new Size(124, 25);
            Scale_Down_Button.TabIndex = 9;
            Scale_Down_Button.Text = "Уменьшить";
            Scale_Down_Button.UseVisualStyleBackColor = true;
            Scale_Down_Button.Click += Scale_Down_Button_Click;
            // 
            // Scale_Up_Button
            // 
            Scale_Up_Button.FlatStyle = FlatStyle.Popup;
            Scale_Up_Button.Location = new Point(6, 87);
            Scale_Up_Button.Name = "Scale_Up_Button";
            Scale_Up_Button.Size = new Size(124, 23);
            Scale_Up_Button.TabIndex = 8;
            Scale_Up_Button.Text = "Увеличить";
            Scale_Up_Button.UseVisualStyleBackColor = true;
            Scale_Up_Button.Click += Scale_Up_Button_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(Variant3_Button);
            groupBox3.Controls.Add(Variant4_Button);
            groupBox3.Controls.Add(Variant13_Button);
            groupBox3.Controls.Add(Variant11_Button);
            groupBox3.Location = new Point(145, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(94, 145);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Фигуры";
            // 
            // Variant3_Button
            // 
            Variant3_Button.FlatStyle = FlatStyle.Popup;
            Variant3_Button.Location = new Point(6, 22);
            Variant3_Button.Name = "Variant3_Button";
            Variant3_Button.Size = new Size(82, 27);
            Variant3_Button.TabIndex = 6;
            Variant3_Button.Text = "Вариант 3";
            Variant3_Button.UseVisualStyleBackColor = true;
            Variant3_Button.Click += Variant3_Button_Click;
            // 
            // Variant4_Button
            // 
            Variant4_Button.FlatStyle = FlatStyle.Popup;
            Variant4_Button.Location = new Point(6, 55);
            Variant4_Button.Name = "Variant4_Button";
            Variant4_Button.Size = new Size(82, 23);
            Variant4_Button.TabIndex = 7;
            Variant4_Button.Text = "Вариант 4";
            Variant4_Button.UseVisualStyleBackColor = true;
            Variant4_Button.Click += Variant4_Button_Click;
            // 
            // Variant13_Button
            // 
            Variant13_Button.FlatStyle = FlatStyle.Popup;
            Variant13_Button.Location = new Point(6, 113);
            Variant13_Button.Name = "Variant13_Button";
            Variant13_Button.Size = new Size(82, 26);
            Variant13_Button.TabIndex = 9;
            Variant13_Button.Text = "Вариант 13";
            Variant13_Button.UseVisualStyleBackColor = true;
            Variant13_Button.Click += Variant13_Button_Click;
            // 
            // Variant11_Button
            // 
            Variant11_Button.FlatStyle = FlatStyle.Popup;
            Variant11_Button.Location = new Point(6, 84);
            Variant11_Button.Name = "Variant11_Button";
            Variant11_Button.Size = new Size(82, 23);
            Variant11_Button.TabIndex = 8;
            Variant11_Button.Text = "Вариант 11";
            Variant11_Button.UseVisualStyleBackColor = true;
            Variant11_Button.Click += Variant11_Button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Draw_axes_Button);
            groupBox1.Controls.Add(Сlear);
            groupBox1.Controls.Add(Start_Button);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(136, 114);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // Сlear
            // 
            Сlear.FlatStyle = FlatStyle.Popup;
            Сlear.Location = new Point(6, 55);
            Сlear.Name = "Сlear";
            Сlear.Size = new Size(124, 23);
            Сlear.TabIndex = 11;
            Сlear.Text = "Очистить";
            Сlear.UseVisualStyleBackColor = true;
            Сlear.Click += Сlear_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Shift_Right_Button);
            groupBox2.Controls.Add(Shift_Left_Button);
            groupBox2.Controls.Add(Shift_Up_Button);
            groupBox2.Controls.Add(Shift_Down_Button);
            groupBox2.Location = new Point(245, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(136, 145);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Сдвиг";
            // 
            // Shift_Right_Button
            // 
            Shift_Right_Button.FlatStyle = FlatStyle.Popup;
            Shift_Right_Button.Location = new Point(6, 22);
            Shift_Right_Button.Name = "Shift_Right_Button";
            Shift_Right_Button.Size = new Size(124, 27);
            Shift_Right_Button.TabIndex = 6;
            Shift_Right_Button.Text = "По оси OX вправо";
            Shift_Right_Button.UseVisualStyleBackColor = true;
            Shift_Right_Button.Click += Shift_Right_Button_Click;
            // 
            // Shift_Left_Button
            // 
            Shift_Left_Button.FlatStyle = FlatStyle.Popup;
            Shift_Left_Button.Location = new Point(6, 55);
            Shift_Left_Button.Name = "Shift_Left_Button";
            Shift_Left_Button.Size = new Size(124, 27);
            Shift_Left_Button.TabIndex = 7;
            Shift_Left_Button.Text = "По оси OX влево";
            Shift_Left_Button.UseVisualStyleBackColor = true;
            Shift_Left_Button.Click += Shift_Left_Button_Click;
            // 
            // Shift_Up_Button
            // 
            Shift_Up_Button.FlatStyle = FlatStyle.Popup;
            Shift_Up_Button.Location = new Point(6, 114);
            Shift_Up_Button.Name = "Shift_Up_Button";
            Shift_Up_Button.Size = new Size(124, 25);
            Shift_Up_Button.TabIndex = 9;
            Shift_Up_Button.Text = "По оси OY вверх";
            Shift_Up_Button.UseVisualStyleBackColor = true;
            Shift_Up_Button.Click += Shift_Up_Button_Click;
            // 
            // Shift_Down_Button
            // 
            Shift_Down_Button.FlatStyle = FlatStyle.Popup;
            Shift_Down_Button.Location = new Point(6, 87);
            Shift_Down_Button.Name = "Shift_Down_Button";
            Shift_Down_Button.Size = new Size(124, 23);
            Shift_Down_Button.TabIndex = 8;
            Shift_Down_Button.Text = "По оси OY вниз";
            Shift_Down_Button.UseVisualStyleBackColor = true;
            Shift_Down_Button.Click += Shift_Down_Button_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Continuous_Scale_Down_Button
            // 
            Continuous_Scale_Down_Button.FlatStyle = FlatStyle.Popup;
            Continuous_Scale_Down_Button.Location = new Point(6, 306);
            Continuous_Scale_Down_Button.Name = "Continuous_Scale_Down_Button";
            Continuous_Scale_Down_Button.Size = new Size(124, 27);
            Continuous_Scale_Down_Button.TabIndex = 12;
            Continuous_Scale_Down_Button.Text = "Неп Уменьшить";
            Continuous_Scale_Down_Button.UseVisualStyleBackColor = true;
            Continuous_Scale_Down_Button.Click += Continuous_Scale_Down_Button_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 524);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "Form4";
            Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button Start_Button;
        private Button Draw_axes_Button;
        private Panel panel1;
        private Button Shift_Up_Button;
        private Button Shift_Down_Button;
        private Button Shift_Left_Button;
        private Button Shift_Right_Button;
        private System.Windows.Forms.Timer timer1;
        private Button Сlear;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Button Variant3_Button;
        private Button Variant4_Button;
        private Button Variant13_Button;
        private Button Variant11_Button;
        private GroupBox groupBox4;
        private Button Reflect_OX_Button;
        private Button Reflect_OY_Button;
        private Button Scale_Down_Button;
        private Button Scale_Up_Button;
        private Button Rotate_Left_Button;
        private Button Rotate_Right_Button;
        private Button Continuous_Shift_Button;
        private Button Continuous_Rotate_Button;
        private Button Continuous_Scale_Up_Button;
        private Button Continuous_Scale_Down_Button;
    }
}