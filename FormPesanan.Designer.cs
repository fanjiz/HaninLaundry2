namespace HaninLaundry
{
    partial class FormPesanan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPesanan));
            dgvPesanan = new DataGridView();
            panel1 = new Panel();
            pictureBox5 = new PictureBox();
            btnTambahPesanan = new Button();
            btnBayarPesanan = new Button();
            btnHapus = new Button();
            cbStatusPengerjaan = new ComboBox();
            label1 = new Label();
            btnKaryawan = new Button();
            btnSimpan = new Button();
            btnRiwayatBayar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPesanan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // dgvPesanan
            // 
            dgvPesanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPesanan.Location = new Point(257, 97);
            dgvPesanan.Margin = new Padding(2);
            dgvPesanan.Name = "dgvPesanan";
            dgvPesanan.RowHeadersWidth = 62;
            dgvPesanan.Size = new Size(662, 285);
            dgvPesanan.TabIndex = 7;
            dgvPesanan.CellClick += dgvPesanan_CellClick;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.laundry_5172266;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Location = new Point(16, 8);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(48, 46);
            panel1.TabIndex = 8;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = SystemColors.MenuHighlight;
            pictureBox5.BackgroundImage = Properties.Resources.Desain_tanpa_judul_1;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(868, 11);
            pictureBox5.Margin = new Padding(2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(51, 50);
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // btnTambahPesanan
            // 
            btnTambahPesanan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTambahPesanan.Location = new Point(20, 97);
            btnTambahPesanan.Name = "btnTambahPesanan";
            btnTambahPesanan.Size = new Size(194, 49);
            btnTambahPesanan.TabIndex = 9;
            btnTambahPesanan.Text = "Tambah Pesanan";
            btnTambahPesanan.UseVisualStyleBackColor = true;
            btnTambahPesanan.Click += btnTambahPesanan_Click;
            // 
            // btnBayarPesanan
            // 
            btnBayarPesanan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBayarPesanan.Location = new Point(20, 163);
            btnBayarPesanan.Name = "btnBayarPesanan";
            btnBayarPesanan.Size = new Size(194, 49);
            btnBayarPesanan.TabIndex = 10;
            btnBayarPesanan.Text = "Bayar Pesanan";
            btnBayarPesanan.UseVisualStyleBackColor = true;
            btnBayarPesanan.Click += btnBayarPesanan_Click_1;
            // 
            // btnHapus
            // 
            btnHapus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHapus.Location = new Point(770, 457);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(149, 49);
            btnHapus.TabIndex = 11;
            btnHapus.Text = "Hapus Pesanan";
            btnHapus.UseVisualStyleBackColor = true;
            btnHapus.Click += btnHapus_Click;
            // 
            // cbStatusPengerjaan
            // 
            cbStatusPengerjaan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbStatusPengerjaan.FormattingEnabled = true;
            cbStatusPengerjaan.Items.AddRange(new object[] { "Diproses", "Selesai", "Diambil" });
            cbStatusPengerjaan.Location = new Point(258, 477);
            cbStatusPengerjaan.Name = "cbStatusPengerjaan";
            cbStatusPengerjaan.Size = new Size(194, 29);
            cbStatusPengerjaan.TabIndex = 12;
            cbStatusPengerjaan.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(254, 455);
            label1.Name = "label1";
            label1.Size = new Size(174, 21);
            label1.TabIndex = 13;
            label1.Text = "Ubah Status Pengerjaan";
            // 
            // btnKaryawan
            // 
            btnKaryawan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnKaryawan.Location = new Point(20, 333);
            btnKaryawan.Name = "btnKaryawan";
            btnKaryawan.Size = new Size(194, 49);
            btnKaryawan.TabIndex = 14;
            btnKaryawan.Text = "Karyawan";
            btnKaryawan.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            btnSimpan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSimpan.Location = new Point(486, 457);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(149, 49);
            btnSimpan.TabIndex = 15;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnRiwayatBayar
            // 
            btnRiwayatBayar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRiwayatBayar.Location = new Point(20, 268);
            btnRiwayatBayar.Name = "btnRiwayatBayar";
            btnRiwayatBayar.Size = new Size(194, 49);
            btnRiwayatBayar.TabIndex = 16;
            btnRiwayatBayar.Text = "Riwayat Pembayaran";
            btnRiwayatBayar.UseVisualStyleBackColor = true;
            // 
            // FormPesanan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 589);
            Controls.Add(btnRiwayatBayar);
            Controls.Add(btnSimpan);
            Controls.Add(btnKaryawan);
            Controls.Add(label1);
            Controls.Add(cbStatusPengerjaan);
            Controls.Add(btnHapus);
            Controls.Add(btnBayarPesanan);
            Controls.Add(btnTambahPesanan);
            Controls.Add(pictureBox5);
            Controls.Add(panel1);
            Controls.Add(dgvPesanan);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "FormPesanan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form_pesanan";
            ((System.ComponentModel.ISupportInitialize)dgvPesanan).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvPesanan;
        private Panel panel1;
        private PictureBox pictureBox5;
        private Button btnTambahPesanan;
        private Button btnBayarPesanan;
        private Button btnHapus;
        private ComboBox cbStatusPengerjaan;
        private Label label1;
        private Button btnKaryawan;
        private Button btnSimpan;
        private Button btnRiwayatBayar;
    }
}