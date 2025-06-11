namespace HaninLaundry
{
    partial class FormTambahPesanan
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
            tbNohp = new TextBox();
            label2 = new Label();
            tbNamaplg = new TextBox();
            label3 = new Label();
            cbLayanan = new ComboBox();
            tbJumlah = new TextBox();
            label4 = new Label();
            btnSimpanPesanan = new Button();
            btnBayar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 75);
            label1.Name = "label1";
            label1.Size = new Size(84, 21);
            label1.TabIndex = 0;
            label1.Text = "Nomor Hp";
            // 
            // tbNohp
            // 
            tbNohp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNohp.Location = new Point(174, 72);
            tbNohp.Name = "tbNohp";
            tbNohp.Size = new Size(184, 29);
            tbNohp.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 130);
            label2.Name = "label2";
            label2.Size = new Size(128, 21);
            label2.TabIndex = 2;
            label2.Text = "Nama Pelanggan";
            // 
            // tbNamaplg
            // 
            tbNamaplg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNamaplg.Location = new Point(174, 127);
            tbNamaplg.Name = "tbNamaplg";
            tbNamaplg.Size = new Size(184, 29);
            tbNamaplg.TabIndex = 3;
            tbNamaplg.TextChanged += tbNamaplg_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 190);
            label3.Name = "label3";
            label3.Size = new Size(114, 21);
            label3.TabIndex = 4;
            label3.Text = "Nama Layanan";
            // 
            // cbLayanan
            // 
            cbLayanan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbLayanan.FormattingEnabled = true;
            cbLayanan.Items.AddRange(new object[] { "Cuci + Setrika (kg)", "Cuci + Lipat (kg)" });
            cbLayanan.Location = new Point(174, 192);
            cbLayanan.Name = "cbLayanan";
            cbLayanan.Size = new Size(184, 29);
            cbLayanan.TabIndex = 5;
            // 
            // tbJumlah
            // 
            tbJumlah.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbJumlah.Location = new Point(174, 253);
            tbJumlah.Name = "tbJumlah";
            tbJumlah.Size = new Size(184, 29);
            tbJumlah.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 256);
            label4.Name = "label4";
            label4.Size = new Size(60, 21);
            label4.TabIndex = 7;
            label4.Text = "Jumlah";
            // 
            // btnSimpanPesanan
            // 
            btnSimpanPesanan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSimpanPesanan.Location = new Point(23, 314);
            btnSimpanPesanan.Name = "btnSimpanPesanan";
            btnSimpanPesanan.Size = new Size(150, 48);
            btnSimpanPesanan.TabIndex = 9;
            btnSimpanPesanan.Text = "Simpan Pesanan";
            btnSimpanPesanan.UseVisualStyleBackColor = true;
            btnSimpanPesanan.Click += btnSimpan_Click;
            // 
            // btnBayar
            // 
            btnBayar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBayar.Location = new Point(208, 314);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(150, 48);
            btnBayar.TabIndex = 10;
            btnBayar.Text = "Bayar Sekarang";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // FormTambahPesanan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 413);
            Controls.Add(btnBayar);
            Controls.Add(btnSimpanPesanan);
            Controls.Add(label4);
            Controls.Add(tbJumlah);
            Controls.Add(cbLayanan);
            Controls.Add(label3);
            Controls.Add(tbNamaplg);
            Controls.Add(label2);
            Controls.Add(tbNohp);
            Controls.Add(label1);
            Name = "FormTambahPesanan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tambah Pesanan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbNohp;
        private Label label2;
        private TextBox tbNamaplg;
        private Label label3;
        private ComboBox cbLayanan;
        private TextBox tbJumlah;
        private Label label4;
        private DataGridView dgvPesanan;
        private Button btnSimpanPesanan;
        private Button btnBayar;
    }
}