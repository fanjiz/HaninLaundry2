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
            dt.Rows.Add("Tanggal Masuk", tglMasuk.ToString("dd/MM/yyyy HH:mm:ss"));
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

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();

                    // Ambil semua data pesanan
                    string getPesananQuery = @"SELECT id_plg, id_user, id_layanan, jumlah, total_harga, tgl_masuk
                                       FROM pesanan WHERE id_pesanan = @id";
                    int id_plg = 0, id_user = 0, id_layanan = 0, jumlah = 0;
                    decimal totalHarga = 0;
                    DateTime tglMasuk;

                    using (MySqlCommand cmd = new MySqlCommand(getPesananQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _idPesanan);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id_plg = Convert.ToInt32(reader["id_plg"]);
                                id_user = Convert.ToInt32(reader["id_user"]);
                                id_layanan = Convert.ToInt32(reader["id_layanan"]);
                                jumlah = Convert.ToInt32(reader["jumlah"]);
                                totalHarga = Convert.ToDecimal(reader["total_harga"]);
                                tglMasuk = Convert.ToDateTime(reader["tgl_masuk"]);
                            }
                            else
                            {
                                MessageBox.Show("Data pesanan tidak ditemukan.");
                                return;
                            }
                        }
                    }

                    // Validasi uang diterima
                    if (uangDiterima < totalHarga)
                    {
                        MessageBox.Show("Uang yang diterima kurang dari total pembayaran.");
                        return;
                    }

                    // Hitung kembalian
                    decimal uangKembali = uangDiterima - totalHarga;

                    // Update status pembayaran di pesanan
                    string updatePesanan = "UPDATE pesanan SET pembayaran = 'Sudah bayar' WHERE id_pesanan = @id";
                    using (MySqlCommand updateCmd = new MySqlCommand(updatePesanan, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@id", _idPesanan);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Insert ke tabel pembayaran
                    string insertPembayaran = @"
                    INSERT INTO pembayaran 
                    (id_pesanan, id_plg, id_user, id_layanan, jumlah, total_harga, uang_diterima, uang_kembali, tgl_masuk, waktu_bayar)
                    VALUES
                    (@idpesanan, @idplg, @iduser, @idlayanan, @jumlah, @total, @uang_diterima, @uang_kembali, @tglmasuk, @waktuBayar)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertPembayaran, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@idpesanan", _idPesanan);
                        insertCmd.Parameters.AddWithValue("@idplg", id_plg);
                        insertCmd.Parameters.AddWithValue("@iduser", id_user);
                        insertCmd.Parameters.AddWithValue("@idlayanan", id_layanan);
                        insertCmd.Parameters.AddWithValue("@jumlah", jumlah);
                        insertCmd.Parameters.AddWithValue("@total", totalHarga);
                        insertCmd.Parameters.AddWithValue("@uang_diterima", uangDiterima);
                        insertCmd.Parameters.AddWithValue("@uang_kembali", uangKembali);
                        insertCmd.Parameters.AddWithValue("@tglmasuk", tglMasuk);
                        insertCmd.Parameters.AddWithValue("@waktuBayar", DateTime.Now);

                        insertCmd.ExecuteNonQuery();
                    }

                    // Selesai
                    MessageBox.Show($"Pembayaran berhasil.\nKembalian: Rp {uangKembali:N0}", "Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat pembayaran: " + ex.Message);
                }
            }
        }
    }
}
