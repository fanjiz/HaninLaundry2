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
            dgvPesanan = new DataGridView();
            btnSimpan = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPesanan).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 39);
            label1.Name = "label1";
            label1.Size = new Size(84, 21);
            label1.TabIndex = 0;
            label1.Text = "Nomor Hp";
            // 
            // tbNohp
            // 
            tbNohp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNohp.Location = new Point(186, 36);
            tbNohp.Name = "tbNohp";
            tbNohp.Size = new Size(184, 29);
            tbNohp.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 94);
            label2.Name = "label2";
            label2.Size = new Size(128, 21);
            label2.TabIndex = 2;
            label2.Text = "Nama Pelanggan";
            // 
            // tbNamaplg
            // 
            tbNamaplg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNamaplg.Location = new Point(186, 91);
            tbNamaplg.Name = "tbNamaplg";
            tbNamaplg.Size = new Size(184, 29);
            tbNamaplg.TabIndex = 3;
            tbNamaplg.TextChanged += tbNamaplg_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(35, 154);
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
            cbLayanan.Location = new Point(186, 156);
            cbLayanan.Name = "cbLayanan";
            cbLayanan.Size = new Size(184, 29);
            cbLayanan.TabIndex = 5;
            // 
            // tbJumlah
            // 
            tbJumlah.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbJumlah.Location = new Point(186, 217);
            tbJumlah.Name = "tbJumlah";
            tbJumlah.Size = new Size(184, 29);
            tbJumlah.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(35, 220);
            label4.Name = "label4";
            label4.Size = new Size(60, 21);
            label4.TabIndex = 7;
            label4.Text = "Jumlah";
            // 
            // dgvPesanan
            // 
            dgvPesanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPesanan.Location = new Point(410, 39);
            dgvPesanan.Margin = new Padding(2);
            dgvPesanan.Name = "dgvPesanan";
            dgvPesanan.RowHeadersWidth = 62;
            dgvPesanan.Size = new Size(729, 319);
            dgvPesanan.TabIndex = 8;
            // 
            // btnSimpan
            // 
            btnSimpan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSimpan.Location = new Point(35, 278);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(335, 31);
            btnSimpan.TabIndex = 9;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // FormTambahPesanan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 450);
            Controls.Add(btnSimpan);
            Controls.Add(dgvPesanan);
            Controls.Add(label4);
            Controls.Add(tbJumlah);
            Controls.Add(cbLayanan);
            Controls.Add(label3);
            Controls.Add(tbNamaplg);
            Controls.Add(label2);
            Controls.Add(tbNohp);
            Controls.Add(label1);
            Name = "FormTambahPesanan";
            Text = "FormTambahPesanan";
            ((System.ComponentModel.ISupportInitialize)dgvPesanan).EndInit();
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
        private Button btnSimpan;
    }
}