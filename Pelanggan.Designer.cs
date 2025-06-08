namespace HaninLaundry
{
    partial class Pelanggan
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
            idpelanggan = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            namapelanggan = new TextBox();
            nohppelanggan = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // idpelanggan
            // 
            idpelanggan.Location = new Point(122, 180);
            idpelanggan.Name = "idpelanggan";
            idpelanggan.Size = new Size(213, 31);
            idpelanggan.TabIndex = 0;
            idpelanggan.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(nohppelanggan);
            panel1.Controls.Add(namapelanggan);
            panel1.Controls.Add(idpelanggan);
            panel1.Location = new Point(423, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(446, 480);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(423, 125);
            panel2.Name = "panel2";
            panel2.Size = new Size(446, 86);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(155, 26);
            label1.Name = "label1";
            label1.Size = new Size(158, 36);
            label1.TabIndex = 0;
            label1.Text = "Pelanggan";
            // 
            // namapelanggan
            // 
            namapelanggan.Location = new Point(122, 298);
            namapelanggan.Name = "namapelanggan";
            namapelanggan.Size = new Size(213, 31);
            namapelanggan.TabIndex = 1;
            // 
            // nohppelanggan
            // 
            nohppelanggan.Location = new Point(122, 412);
            nohppelanggan.Name = "nohppelanggan";
            nohppelanggan.Size = new Size(213, 31);
            nohppelanggan.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(167, 152);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 3;
            label2.Text = "Id Pelanggan";
            // 
            // Pelanggan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.login;
            ClientSize = new Size(1307, 663);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Pelanggan";
            Text = "Pelanggan";
            Load += Pelanggan_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox idpelanggan;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private TextBox nohppelanggan;
        private TextBox namapelanggan;
    }
}