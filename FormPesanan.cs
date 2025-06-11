using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace HaninLaundry
{

    public partial class FormPesanan : Form
    {
        int pageSize = 10;             // jumlah data per halaman
        int currentPage = 1;           // halaman saat ini
        int totalPages = 1;            // total halaman
        int totalRecords = 0;          // jumlah total data

        bool isFiltered = false;

        private int selectedIdPesanan = -1;
        private DataGridViewRow selectedRow = null;

        public FormPesanan()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();

                    // Hitung total data
                    string countQuery = "SELECT COUNT(*) FROM pesanan";
                    MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    int offset = (currentPage - 1) * pageSize;

                    string query = @"
                SELECT 
                    ps.id_pesanan,
                    u.nama AS petugas,
                    p.nama_plg AS nama_pelanggan,
                    p.no_hp_plg AS no_hp_pelanggan,
                    l.nama_layanan,
                    l.harga,
                    ps.jumlah,
                    (l.harga * ps.jumlah) AS total_harga,
                    ps.tgl_masuk,
                    ps.status_pengerjaan,
                    ps.pembayaran
                FROM pesanan ps
                JOIN user u ON ps.id_user = u.id_user
                JOIN pelanggan p ON ps.id_plg = p.id_plg
                JOIN layanan l ON ps.id_layanan = l.id_layanan
                ORDER BY ps.tgl_masuk DESC, ps.id_pesanan DESC
                LIMIT @limit OFFSET @offset";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@limit", pageSize);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPesanan.DataSource = dt;

                    dgvPesanan.Columns["id_pesanan"].Visible = false;

                    dgvPesanan.Columns["petugas"].HeaderText = "Petugas";
                    dgvPesanan.Columns["nama_pelanggan"].HeaderText = "Nama Pelanggan";
                    dgvPesanan.Columns["no_hp_pelanggan"].HeaderText = "No. HP";
                    dgvPesanan.Columns["nama_layanan"].HeaderText = "Layanan";
                    dgvPesanan.Columns["harga"].HeaderText = "Harga";
                    dgvPesanan.Columns["jumlah"].HeaderText = "Jumlah";
                    dgvPesanan.Columns["total_harga"].HeaderText = "Total Harga";
                    dgvPesanan.Columns["tgl_masuk"].HeaderText = "Tanggal Masuk";
                    dgvPesanan.Columns["status_pengerjaan"].HeaderText = "Status";
                    dgvPesanan.Columns["pembayaran"].HeaderText = "Pembayaran";

                    // Update info halaman
                    lblPageInfo.Text = $"Halaman {currentPage} dari {totalPages}";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error load data: " + ex.Message);
                }
            }
        }

        private void btnBayarPesanan_Click_1(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                MessageBox.Show("Silakan pilih pesanan yang ingin dibayar.");
                return;
            }

            object idObj = selectedRow.Cells["id_pesanan"].Value;
            if (idObj == null || idObj == DBNull.Value)
            {
                MessageBox.Show("ID pesanan tidak valid.");
                return;
            }

            int idPesanan = Convert.ToInt32(idObj);

            string statusPembayaran = selectedRow.Cells["pembayaran"].Value?.ToString();
            if (!string.IsNullOrEmpty(statusPembayaran) && statusPembayaran.ToLower() == "sudah bayar")
            {
                MessageBox.Show("Pesanan ini sudah dibayar sebelumnya.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FormBayarPesanan form = new FormBayarPesanan(idPesanan);
            form.ShowDialog();

            LoadData();
            selectedRow = null;
        }

        private void btnTambahPesanan_Click(object sender, EventArgs e)
        {
            new FormTambahPesanan().ShowDialog();
            this.Show();
            LoadData();
        }

        private void dgvPesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                object valueSelectedId = dgvPesanan.Rows[e.RowIndex].Cells["id_pesanan"].Value;
                selectedIdPesanan = (valueSelectedId != null && valueSelectedId != DBNull.Value)
                    ? Convert.ToInt32(valueSelectedId)
                    : -1;

                string status = dgvPesanan.Rows[e.RowIndex].Cells["status_pengerjaan"].Value?.ToString() ?? "";
                cbStatusPengerjaan.SelectedItem = status;

                selectedRow = dgvPesanan.Rows[e.RowIndex];
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (selectedIdPesanan == -1)
            {
                MessageBox.Show("Silakan pilih pesanan terlebih dahulu.");
                return;
            }

            string statusBaru = cbStatusPengerjaan.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(statusBaru))
            {
                MessageBox.Show("Silakan pilih status pengerjaan.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE pesanan SET status_pengerjaan = @status WHERE id_pesanan = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", statusBaru);
                    cmd.Parameters.AddWithValue("@id", selectedIdPesanan);

                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Status pesanan berhasil diperbarui!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal update status: " + ex.Message);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedIdPesanan == -1)
            {
                MessageBox.Show("Silakan pilih data pesanan yang ingin dihapus.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Yakin ingin menghapus data pesanan ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM pesanan WHERE id_pesanan = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedIdPesanan);
                    cmd.ExecuteNonQuery();

                    LoadData();
                    MessageBox.Show("Data pesanan berhasil dihapus.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal hapus: " + ex.Message);
                }
            }
        }

        private void btnRiwayatBayar_Click(object sender, EventArgs e)
        {
            FormPembayaran form = new FormPembayaran();
            form.ShowDialog();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            isFiltered = true;
            TampilkanDataFiltered();
        }

        private void TampilkanDataFiltered()
        {
            string keyword = tbCari.Text.Trim(); // inputan dari TextBox
            string likeClause = $@"
        (u.nama LIKE @keyword OR 
         p.nama_plg LIKE @keyword OR 
         p.no_hp_plg LIKE @keyword OR 
         l.nama_layanan LIKE @keyword OR 
         ps.jumlah LIKE @keyword OR 
         ps.total_harga LIKE @keyword OR 
         ps.tgl_masuk LIKE @keyword OR
         ps.status_pengerjaan LIKE @keyword OR
         ps.pembayaran LIKE @keyword)";

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                conn.Open();

                // Hitung total record hasil pencarian
                string countQuery = $@"
            SELECT COUNT(*) FROM pesanan ps
            JOIN user u ON ps.id_user = u.id_user
            JOIN pelanggan p ON ps.id_plg = p.id_plg
            JOIN layanan l ON ps.id_layanan = l.id_layanan
            WHERE {likeClause}";

                MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                countCmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                if (currentPage > totalPages) currentPage = totalPages;
                if (currentPage < 1) currentPage = 1;

                int offset = (currentPage - 1) * pageSize;

                string query = $@"
            SELECT 
                ps.id_pesanan,
                u.nama AS petugas,
                p.nama_plg AS nama_pelanggan,
                p.no_hp_plg AS no_hp_pelanggan,
                l.nama_layanan,
                l.harga,
                ps.jumlah,
                (l.harga * ps.jumlah) AS total_harga,
                ps.tgl_masuk,
                ps.status_pengerjaan,
                ps.pembayaran
            FROM pesanan ps
            JOIN user u ON ps.id_user = u.id_user
            JOIN pelanggan p ON ps.id_plg = p.id_plg
            JOIN layanan l ON ps.id_layanan = l.id_layanan
            WHERE {likeClause}
            ORDER BY ps.tgl_masuk DESC, ps.id_pesanan DESC
            LIMIT @limit OFFSET @offset";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                cmd.Parameters.AddWithValue("@limit", pageSize);
                cmd.Parameters.AddWithValue("@offset", offset);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPesanan.DataSource = dt;

                dgvPesanan.Columns["id_pesanan"].Visible = false;

                lblPageInfo.Text = $"Halaman {currentPage} dari {totalPages}";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                if (isFiltered)
                    TampilkanDataFiltered();
                else
                    LoadData();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                if (isFiltered)
                    TampilkanDataFiltered();
                else
                    LoadData();
            }
        }

    }
}
