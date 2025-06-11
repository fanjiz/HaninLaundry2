namespace HaninLaundry
{
    partial class FormPembayaran
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
            dgvPembayaran = new DataGridView();
            btnSimpan = new Button();
            btnPrev = new Button();
            btnNext = new Button();
            lblPageInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPembayaran).BeginInit();
            SuspendLayout();
            // 
            // dgvPembayaran
            // 
            dgvPembayaran.AllowUserToAddRows = false;
            dgvPembayaran.AllowUserToDeleteRows = false;
            dgvPembayaran.AllowUserToOrderColumns = true;
            dgvPembayaran.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPembayaran.Location = new Point(30, 30);
            dgvPembayaran.Name = "dgvPembayaran";
            dgvPembayaran.ReadOnly = true;
            dgvPembayaran.Size = new Size(542, 285);
            dgvPembayaran.TabIndex = 0;
            // 
            // btnSimpan
            // 
            btnSimpan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSimpan.Location = new Point(30, 395);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(149, 49);
            btnSimpan.TabIndex = 16;
            btnSimpan.Text = "Cetak Laporan";
            btnSimpan.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            btnPrev.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrev.Location = new Point(30, 331);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(71, 39);
            btnPrev.TabIndex = 17;
            btnPrev.Text = "Prev";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(108, 331);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(71, 39);
            btnNext.TabIndex = 18;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPageInfo.Location = new Point(443, 340);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(129, 21);
            lblPageInfo.TabIndex = 19;
            lblPageInfo.Text = "Halaman 1 dari 2";
            // 
            // FormPembayaran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 484);
            Controls.Add(lblPageInfo);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(btnSimpan);
            Controls.Add(dgvPembayaran);
            Name = "FormPembayaran";
            Text = "Riwayat Pembayaran";
            ((System.ComponentModel.ISupportInitialize)dgvPembayaran).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPembayaran;
        private Button btnSimpan;
        private Button btnPrev;
        private Button btnNext;
        private Label lblPageInfo;
    }
}