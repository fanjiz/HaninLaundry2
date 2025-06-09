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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_pesanan));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            button5 = new Button();
            button6 = new Button();
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
            // button2
            // 
            button2.Location = new Point(424, 12);
            button2.Name = "button2";
            button2.Size = new Size(232, 34);
            button2.TabIndex = 1;
            button2.Text = "Ubah Status Pengerjaan";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(680, 12);
            button3.Name = "button3";
            button3.Size = new Size(157, 34);
            button3.TabIndex = 2;
            button3.Text = "Edit Pesanan";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(865, 12);
            button4.Name = "button4";
            button4.Size = new Size(157, 34);
            button4.TabIndex = 3;
            button4.Text = "Hapus Pesanan";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1134, 14);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 4;
            // 
            // button5
            // 
            button5.Location = new Point(242, 88);
            button5.Name = "button5";
            button5.Size = new Size(157, 34);
            button5.TabIndex = 5;
            button5.Text = "Tambah Pesanan";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(459, 88);
            button6.Name = "button6";
            button6.Size = new Size(157, 34);
            button6.TabIndex = 6;
            button6.Text = "Segarkan";
            button6.UseVisualStyleBackColor = true;
            // 
            // Form_pesanan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1373, 781);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_pesanan";
            Text = "Form_pesanan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private Button button5;
        private Button button6;
    }
}