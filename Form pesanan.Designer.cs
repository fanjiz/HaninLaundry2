namespace HaninLaundry
{
    partial class Form_pesanan
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
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(242, 12);
            button1.Name = "button1";
            button1.Size = new Size(157, 34);
            button1.TabIndex = 0;
            button1.Text = "Bayar Pesanan";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form_pesanan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1373, 781);
            Controls.Add(button1);
            Name = "Form_pesanan";
            Text = "Form_pesanan";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}