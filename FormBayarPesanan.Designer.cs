namespace HaninLaundry
{
    partial class FormBayarPesanan
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
            tbUangDiterima = new TextBox();
            label1 = new Label();
            btnBayar = new Button();
            dgvPesanan = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPesanan).BeginInit();
            SuspendLayout();
            // 
            // tbUangDiterima
            // 
            tbUangDiterima.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUangDiterima.Location = new Point(29, 410);
            tbUangDiterima.Name = "tbUangDiterima";
            tbUangDiterima.Size = new Size(184, 29);
            tbUangDiterima.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 386);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 3;
            label1.Text = "Uang Diterima";
            // 
            // btnBayar
            // 
            btnBayar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBayar.Location = new Point(243, 391);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(150, 48);
            btnBayar.TabIndex = 10;
            btnBayar.Text = "Bayar";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // dgvPesanan
            // 
            dgvPesanan.AllowUserToAddRows = false;
            dgvPesanan.AllowUserToDeleteRows = false;
            dgvPesanan.AllowUserToOrderColumns = true;
            dgvPesanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPesanan.Location = new Point(31, 39);
            dgvPesanan.Name = "dgvPesanan";
            dgvPesanan.ReadOnly = true;
            dgvPesanan.Size = new Size(362, 302);
            dgvPesanan.TabIndex = 11;
            // 
            // FormBayarPesanan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 466);
            Controls.Add(dgvPesanan);
            Controls.Add(btnBayar);
            Controls.Add(label1);
            Controls.Add(tbUangDiterima);
            Name = "FormBayarPesanan";
            Text = "Bayar Pesanan";
            ((System.ComponentModel.ISupportInitialize)dgvPesanan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUangDiterima;
        private Label label1;
        private Button btnBayar;
        private DataGridView dgvPesanan;
    }
}