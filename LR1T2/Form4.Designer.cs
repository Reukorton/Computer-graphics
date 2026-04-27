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
            Сlear = new Button();
            label1 = new Label();
            Shift_Up_Button = new Button();
            Shift_Down_Button = new Button();
            Shift_Left_Button = new Button();
            Shift_Right_Button = new Button();
            Draw_figure_Button = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(9, 9);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(515, 444);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Start_Button
            // 
            Start_Button.FlatStyle = FlatStyle.Popup;
            Start_Button.Location = new Point(3, 414);
            Start_Button.Name = "Start_Button";
            Start_Button.Size = new Size(104, 23);
            Start_Button.TabIndex = 2;
            Start_Button.Text = "Старт";
            Start_Button.UseVisualStyleBackColor = true;
            Start_Button.Click += Start_Button_Click;
            // 
            // Draw_axes_Button
            // 
            Draw_axes_Button.FlatStyle = FlatStyle.Popup;
            Draw_axes_Button.Location = new Point(3, 3);
            Draw_axes_Button.Name = "Draw_axes_Button";
            Draw_axes_Button.Size = new Size(149, 27);
            Draw_axes_Button.TabIndex = 3;
            Draw_axes_Button.Text = "Нарисовать оси";
            Draw_axes_Button.UseVisualStyleBackColor = true;
            Draw_axes_Button.Click += Draw_axes_Button_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(Сlear);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Shift_Up_Button);
            panel1.Controls.Add(Shift_Down_Button);
            panel1.Controls.Add(Shift_Left_Button);
            panel1.Controls.Add(Shift_Right_Button);
            panel1.Controls.Add(Draw_figure_Button);
            panel1.Controls.Add(Draw_axes_Button);
            panel1.Controls.Add(Start_Button);
            panel1.Location = new Point(527, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(157, 442);
            panel1.TabIndex = 2;
            // 
            // Сlear
            // 
            Сlear.FlatStyle = FlatStyle.Popup;
            Сlear.Location = new Point(3, 69);
            Сlear.Name = "Сlear";
            Сlear.Size = new Size(149, 23);
            Сlear.TabIndex = 11;
            Сlear.Text = "Очистить";
            Сlear.UseVisualStyleBackColor = true;
            Сlear.Click += Сlear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(45, 95);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 10;
            label1.Text = "Сдвиг";
            // 
            // Shift_Up_Button
            // 
            Shift_Up_Button.FlatStyle = FlatStyle.Popup;
            Shift_Up_Button.Location = new Point(3, 222);
            Shift_Up_Button.Name = "Shift_Up_Button";
            Shift_Up_Button.Size = new Size(149, 27);
            Shift_Up_Button.TabIndex = 9;
            Shift_Up_Button.Text = "По оси OY вверх";
            Shift_Up_Button.UseVisualStyleBackColor = true;
            Shift_Up_Button.Click += Shift_Up_Button_Click;
            // 
            // Shift_Down_Button
            // 
            Shift_Down_Button.FlatStyle = FlatStyle.Popup;
            Shift_Down_Button.Location = new Point(3, 189);
            Shift_Down_Button.Name = "Shift_Down_Button";
            Shift_Down_Button.Size = new Size(149, 27);
            Shift_Down_Button.TabIndex = 8;
            Shift_Down_Button.Text = "По оси OY вниз";
            Shift_Down_Button.UseVisualStyleBackColor = true;
            Shift_Down_Button.Click += Shift_Down_Button_Click;
            // 
            // Shift_Left_Button
            // 
            Shift_Left_Button.FlatStyle = FlatStyle.Popup;
            Shift_Left_Button.Location = new Point(3, 156);
            Shift_Left_Button.Name = "Shift_Left_Button";
            Shift_Left_Button.Size = new Size(149, 27);
            Shift_Left_Button.TabIndex = 7;
            Shift_Left_Button.Text = "По оси OX влево";
            Shift_Left_Button.UseVisualStyleBackColor = true;
            Shift_Left_Button.Click += Shift_Left_Button_Click;
            // 
            // Shift_Right_Button
            // 
            Shift_Right_Button.FlatStyle = FlatStyle.Popup;
            Shift_Right_Button.Location = new Point(3, 123);
            Shift_Right_Button.Name = "Shift_Right_Button";
            Shift_Right_Button.Size = new Size(149, 27);
            Shift_Right_Button.TabIndex = 6;
            Shift_Right_Button.Text = "По оси OX вправо";
            Shift_Right_Button.UseVisualStyleBackColor = true;
            Shift_Right_Button.Click += Shift_Right_Button_Click;
            // 
            // Draw_figure_Button
            // 
            Draw_figure_Button.FlatStyle = FlatStyle.Popup;
            Draw_figure_Button.Location = new Point(3, 36);
            Draw_figure_Button.Name = "Draw_figure_Button";
            Draw_figure_Button.Size = new Size(149, 27);
            Draw_figure_Button.TabIndex = 5;
            Draw_figure_Button.Text = "Нарисовать фигуру";
            Draw_figure_Button.UseVisualStyleBackColor = true;
            Draw_figure_Button.Click += Draw_figure_Button_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 462);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "Form4";
            Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button Start_Button;
        private Button Draw_axes_Button;
        private Panel panel1;
        private Button Draw_figure_Button;
        private Label label1;
        private Button Shift_Up_Button;
        private Button Shift_Down_Button;
        private Button Shift_Left_Button;
        private Button Shift_Right_Button;
        private System.Windows.Forms.Timer timer1;
        private Button Сlear;
    }
}