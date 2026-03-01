namespace LR1T2
{
    partial class Form2
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
            OK_Button = new Button();
            SuspendLayout();
            // 
            // OK_Button
            // 
            OK_Button.DialogResult = DialogResult.OK;
            OK_Button.Location = new Point(12, 12);
            OK_Button.Name = "OK_Button";
            OK_Button.Size = new Size(94, 29);
            OK_Button.TabIndex = 0;
            OK_Button.Text = "OK";
            OK_Button.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 453);
            Controls.Add(OK_Button);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        public Button OK_Button;
    }
}