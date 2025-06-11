using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaninLaundry
{
    public partial class FormBayarPesanan : Form
    {
        private DataGridViewRow selectedRow = null;

        public FormBayarPesanan(DataGridViewRow pesanan)
        {
            InitializeComponent();
            selectedRow = pesanan;
            TampilkanDetailVertikal(pesanan);
        }

        private void TampilkanDetailVertikal(DataGridViewRow selectedRow)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Field");
            dt.Columns.Add("Value");

            dt.Rows.Add("Petugas", selectedRow.Cells["petugas"].Value?.ToString());
            dt.Rows.Add("Nama Pelanggan", selectedRow.Cells["nama_pelanggan"].Value?.ToString());
            dt.Rows.Add("No. HP Pelanggan", selectedRow.Cells["no_hp_pelanggan"].Value?.ToString());
            dt.Rows.Add("Layanan", selectedRow.Cells["nama_layanan"].Value?.ToString());
            dt.Rows.Add("Harga", selectedRow.Cells["harga"].Value?.ToString());
            dt.Rows.Add("Jumlah", selectedRow.Cells["jumlah"].Value?.ToString());
            dt.Rows.Add("Total Harga", selectedRow.Cells["total_harga"].Value?.ToString());
            dt.Rows.Add("Tanggal Masuk", selectedRow.Cells["tgl_masuk"].Value?.ToString());
            dt.Rows.Add("Status", selectedRow.Cells["status_pengerjaan"].Value?.ToString());

            dgvPesanan.DataSource = dt;

            // Optional: atur lebar kolom
            dgvPesanan.Columns[0].Width = 150;
            dgvPesanan.Columns[1].Width = 250;
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                MessageBox.Show("Data pesanan tidak tersedia.");
                return;
            }

            // 1. Ambil total harga dari baris yang diklik
            decimal totalHarga = Convert.ToDecimal(selectedRow.Cells["total_harga"].Value);

            // 2. Validasi input uang diterima
            if (!decimal.TryParse(tbUangDiterima.Text.Trim(), out decimal uangDiterima))
            {
                MessageBox.Show("Masukkan nominal uang yang valid.");
                tbUangDiterima.Focus();
                return;
            }

            if (uangDiterima < totalHarga)
            {
                MessageBox.Show("Uang yang diterima kurang dari total pembayaran.");
                return;
            }

            // 3. Hitung kembalian
            decimal kembalian = uangDiterima - totalHarga;

            // 4. Update status pembayaran di database
            int idPesanan = Convert.ToInt32(selectedRow.Cells["id_pesanan"].Value);

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE pesanan SET pembayaran = 'Sudah bayar' WHERE id_pesanan = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idPesanan);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal update status pembayaran: " + ex.Message);
                    return;
                }
            }

            // 5. Tampilkan pesan dan tutup form
            MessageBox.Show($"Pembayaran berhasil.\nKembalian: Rp {kembalian:N0}", "Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
