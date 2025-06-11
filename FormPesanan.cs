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
                    ";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPesanan.DataSource = dt;

                    dgvPesanan.Columns["id_pesanan"].Visible = false;

                    // Header kolom agar lebih rapi
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

            LoadData(); // Refresh setelah transaksi
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
    }
}
