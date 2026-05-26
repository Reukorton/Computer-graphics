namespace LR1T2
{
    partial class Form6
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
            comboBoxFigure = new ComboBox();
            btnReset = new Button();
            btnAutoRotate = new Button();
            btnAutoMove = new Button();
            btnDirection = new Button();
            btnSpeedMinus = new Button();
            btnSpeedPlus = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            comboBoxAction = new ComboBox();
            comboBoxAxis = new ComboBox();
            btnMinus = new Button();
            btnPlus = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(9, 9);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(515, 506);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // comboBoxFigure
            // 
            comboBoxFigure.FormattingEnabled = true;
            comboBoxFigure.Location = new Point(536, 12);
            comboBoxFigure.Name = "comboBoxFigure";
            comboBoxFigure.Size = new Size(143, 23);
            comboBoxFigure.TabIndex = 3;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(536, 488);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(90, 23);
            btnReset.TabIndex = 4;
            btnReset.Text = "Сброс";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnAutoRotate
            // 
            btnAutoRotate.Location = new Point(536, 114);
            btnAutoRotate.Name = "btnAutoRotate";
            btnAutoRotate.Size = new Size(107, 23);
            btnAutoRotate.TabIndex = 8;
            btnAutoRotate.Text = "Авто вращение";
            btnAutoRotate.UseVisualStyleBackColor = true;
            // 
            // btnAutoMove
            // 
            btnAutoMove.Location = new Point(536, 85);
            btnAutoMove.Name = "btnAutoMove";
            btnAutoMove.Size = new Size(107, 23);
            btnAutoMove.TabIndex = 9;
            btnAutoMove.Text = "Авто движение";
            btnAutoMove.UseVisualStyleBackColor = true;
            // 
            // btnDirection
            // 
            btnDirection.Location = new Point(536, 143);
            btnDirection.Name = "btnDirection";
            btnDirection.Size = new Size(107, 23);
            btnDirection.TabIndex = 10;
            btnDirection.Text = "Направление";
            btnDirection.UseVisualStyleBackColor = true;
            // 
            // btnSpeedMinus
            // 
            btnSpeedMinus.Location = new Point(649, 85);
            btnSpeedMinus.Name = "btnSpeedMinus";
            btnSpeedMinus.Size = new Size(90, 23);
            btnSpeedMinus.TabIndex = 11;
            btnSpeedMinus.Text = "Скорость -";
            btnSpeedMinus.UseVisualStyleBackColor = true;
            // 
            // btnSpeedPlus
            // 
            btnSpeedPlus.Location = new Point(649, 114);
            btnSpeedPlus.Name = "btnSpeedPlus";
            btnSpeedPlus.Size = new Size(90, 23);
            btnSpeedPlus.TabIndex = 12;
            btnSpeedPlus.Text = "Скорость +";
            btnSpeedPlus.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            timer1.Tick += Timer_Tick;
            // 
            // comboBoxAction
            // 
            comboBoxAction.FormattingEnabled = true;
            comboBoxAction.Location = new Point(536, 56);
            comboBoxAction.Name = "comboBoxAction";
            comboBoxAction.Size = new Size(143, 23);
            comboBoxAction.TabIndex = 13;
            // 
            // comboBoxAxis
            // 
            comboBoxAxis.FormattingEnabled = true;
            comboBoxAxis.Location = new Point(536, 230);
            comboBoxAxis.Name = "comboBoxAxis";
            comboBoxAxis.Size = new Size(121, 23);
            comboBoxAxis.TabIndex = 14;
            // 
            // btnMinus
            // 
            btnMinus.Location = new Point(536, 172);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(164, 23);
            btnMinus.TabIndex = 16;
            btnMinus.Text = "выполнить в минус";
            btnMinus.UseVisualStyleBackColor = true;
            // 
            // btnPlus
            // 
            btnPlus.Location = new Point(536, 201);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(164, 23);
            btnPlus.TabIndex = 17;
            btnPlus.Text = "выполнить в плюс";
            btnPlus.UseVisualStyleBackColor = true;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 523);
            Controls.Add(btnPlus);
            Controls.Add(btnMinus);
            Controls.Add(comboBoxAxis);
            Controls.Add(comboBoxAction);
            Controls.Add(btnSpeedPlus);
            Controls.Add(btnSpeedMinus);
            Controls.Add(btnDirection);
            Controls.Add(btnAutoMove);
            Controls.Add(btnAutoRotate);
            Controls.Add(btnReset);
            Controls.Add(comboBoxFigure);
            Controls.Add(pictureBox1);
            Name = "Form6";
            Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBoxFigure;
        private Button btnReset;
        private Button btnAutoRotate;
        private Button btnAutoMove;
        private Button btnDirection;
        private Button btnSpeedMinus;
        private Button btnSpeedPlus;
        private System.Windows.Forms.Timer timer1;
        private ComboBox comboBoxAction;
        private ComboBox comboBoxAxis;
        private Button btnMinus;
        private Button btnPlus;
    }
}