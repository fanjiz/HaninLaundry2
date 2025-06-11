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
        private int _idPesanan;

        public FormBayarPesanan(int idPesanan)
        {
            InitializeComponent();
            _idPesanan = idPesanan;
            LoadPesananFromDatabase();
        }

        private void LoadPesananFromDatabase()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
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
                WHERE ps.id_pesanan = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", _idPesanan);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
            DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            TampilkanDetailVertikal(dt.Rows[0]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data pesanan: " + ex.Message);
                }
            }
        }


        private void TampilkanDetailVertikal(DataRow row)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Field");
            dt.Columns.Add("Value");

            dt.Rows.Add("Petugas", row["petugas"]);
            dt.Rows.Add("Nama Pelanggan", row["nama_pelanggan"]);
            dt.Rows.Add("No. HP Pelanggan", row["no_hp_pelanggan"]);
            dt.Rows.Add("Layanan", row["nama_layanan"]);
            dt.Rows.Add("Harga", row["harga"]);
            dt.Rows.Add("Jumlah", row["jumlah"]);
            dt.Rows.Add("Total Harga", row["total_harga"]);
            DateTime tglMasuk = Convert.ToDateTime(row["tgl_masuk"]);
            dt.Rows.Add("Tanggal Masuk", tglMasuk.ToString("dd/MM/yyyy"));
            dt.Rows.Add("Status", row["status_pengerjaan"]);
            dt.Rows.Add("Pembayaran", row["pembayaran"]);

            dgvPesanan.DataSource = dt;

            // Optional: atur lebar kolom
            dgvPesanan.Columns[0].Width = 150;
            dgvPesanan.Columns[1].Width = 250;
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(tbUangDiterima.Text.Trim(), out decimal uangDiterima))
            {
                MessageBox.Show("Masukkan nominal uang yang valid.");
                tbUangDiterima.Focus();
                return;
            }

            decimal totalHarga = 0;

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();

                    // 1. Ambil total harga dari database berdasarkan _idPesanan
                    string getTotalQuery = "SELECT total_harga FROM pesanan WHERE id_pesanan = @id";
                    using (MySqlCommand cmd = new MySqlCommand(getTotalQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _idPesanan);
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
            {
                            MessageBox.Show("Data pesanan tidak ditemukan.");
                return;
            }

                        totalHarga = Convert.ToDecimal(result);
                    }

            if (uangDiterima < totalHarga)
            {
                MessageBox.Show("Uang yang diterima kurang dari total pembayaran.");
                return;
            }

                    // 2. Update status pembayaran
                    string updateQuery = "UPDATE pesanan SET pembayaran = 'Sudah bayar' WHERE id_pesanan = @id";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@id", _idPesanan);
                        updateCmd.ExecuteNonQuery();
                    }

                    // 3. Hitung dan tampilkan kembalian
            decimal kembalian = uangDiterima - totalHarga;
                    MessageBox.Show($"Pembayaran berhasil.\nKembalian: Rp {kembalian:N0}", "Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat pembayaran: " + ex.Message);
                }
            }

            // 5. Tampilkan pesan dan tutup form
            MessageBox.Show($"Pembayaran berhasil.\nKembalian: Rp {kembalian:N0}", "Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
