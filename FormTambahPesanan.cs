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
    public partial class FormTambahPesanan : Form
    {

        public FormTambahPesanan()
        {
            InitializeComponent();
            LoadLayananToComboBox();
        }

        private void ClearForm()
        {
            tbNamaplg.Clear();
            tbNohp.Clear();
            tbJumlah.Clear();
            cbLayanan.SelectedIndex = -1;
        }

        private void tbNamaplg_TextChanged(object sender, EventArgs e)
        {

        }

        private Dictionary<int, decimal> layananHargaMap = new Dictionary<int, decimal>();

        private void LoadLayananToComboBox()
        {
            cbLayanan.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                conn.Open();
                string query = "SELECT id_layanan, nama_layanan, harga FROM layanan";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LayananItem item = new LayananItem
                        {
                            Id = reader.GetInt32("id_layanan"),
                            Nama = reader.GetString("nama_layanan"),
                            Harga = reader.GetInt32("harga")
                        };

                        cbLayanan.Items.Add(item); // ⬅ Tambahkan OBJEK, bukan string!
                    }
                }
            }
        }

        private void cbLayanan_SelectedIndexChanged(object sender, EventArgs e)
        {
            HitungTotal();
        }

        private void tbJumlah_TextChanged(object sender, EventArgs e)
        {
            HitungTotal();
        }

        private void HitungTotal()
        {
            if (cbLayanan.SelectedIndex >= 0 && int.TryParse(tbJumlah.Text, out int jumlah))
            {
                string namaDipilih = cbLayanan.SelectedItem.ToString();
                int idLayanan = layananHargaMap.FirstOrDefault(x => cbLayanan.Items[x.Key - 1].ToString() == namaDipilih).Key;
                decimal harga = layananHargaMap[idLayanan];
                decimal total = jumlah * harga;

                //// Optional: tampilkan total di Label atau tbHarga
                //lblTotalHarga.Text = total.ToString("C0"); // Format currency
            }
        }

        private bool ValidasiInput()
        {
            // Validasi Nama
            string nama = tbNamaplg.Text.Trim();
            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama pelanggan wajib diisi.");
                tbNamaplg.Focus();
                return false;
            }
            if (nama.Length < 3 || !System.Text.RegularExpressions.Regex.IsMatch(nama, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama harus minimal 3 huruf dan hanya mengandung huruf dan spasi.");
                tbNamaplg.Focus();
                return false;
            }

            // Validasi Nomor HP
            string nohp = tbNohp.Text.Trim();
            if (string.IsNullOrWhiteSpace(nohp))
            {
                MessageBox.Show("Nomor HP wajib diisi.");
                tbNohp.Focus();
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(nohp, @"^(08|62)[0-9]{8,12}$"))
            {
                MessageBox.Show("Nomor HP tidak valid. Gunakan format 08xxxxxxxxxx atau 62xxxxxxxxxx (10-14 digit).");
                tbNohp.Focus();
                return false;
            }

            // Validasi Layanan
            if (cbLayanan.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih layanan terlebih dahulu.");
                cbLayanan.Focus();
                return false;
            }

            // Validasi Jumlah
            if (!int.TryParse(tbJumlah.Text.Trim(), out int jumlah) || jumlah <= 0)
            {
                MessageBox.Show("Jumlah harus berupa angka dan lebih dari 0.");
                tbJumlah.Focus();
                return false;
            }

            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();

                    // 1. Cek apakah pelanggan sudah ada berdasarkan no_hp
                    int idPelanggan;
                    string cekPelanggan = "SELECT id_plg FROM pelanggan WHERE no_hp_plg = @hp";
                    using (MySqlCommand cekCmd = new MySqlCommand(cekPelanggan, conn))
                    {
                        cekCmd.Parameters.AddWithValue("@hp", tbNohp.Text.Trim());
                        object result = cekCmd.ExecuteScalar();

                        if (result != null)
                        {
                            idPelanggan = Convert.ToInt32(result);
                        }
                        else
                        {
                            string insert = "INSERT INTO pelanggan (nama_plg, no_hp_plg) VALUES (@nama, @hp)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insert, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@nama", tbNamaplg.Text.Trim());
                                insertCmd.Parameters.AddWithValue("@hp", tbNohp.Text.Trim());
                                insertCmd.ExecuteNonQuery();
                                idPelanggan = (int)insertCmd.LastInsertedId;
                            }
                        }
                    }

                    // 2. Ambil layanan yang dipilih
                    LayananItem layananDipilih = cbLayanan.SelectedItem as LayananItem;
                    if (layananDipilih == null)
                    {
                        MessageBox.Show("Silakan pilih layanan terlebih dahulu.");
                        return;
                    }

                    int idLayanan = layananDipilih.Id;
                    decimal harga = layananDipilih.Harga;

                    // 3. Hitung total
                    int jumlah = int.Parse(tbJumlah.Text);
                    decimal total = jumlah * harga;

                    // 4. Simpan pesanan
                    string insertPesanan = @"INSERT INTO pesanan 
                (id_user, id_plg, id_layanan, jumlah, tgl_masuk, total_harga)
                VALUES 
                (@iduser, @idplg, @idlayanan, @jumlah, @tgl_masuk, @total)";
                    MySqlCommand cmd = new MySqlCommand(insertPesanan, conn);
                    cmd.Parameters.AddWithValue("@iduser", SessionUser.IdUser);
                    cmd.Parameters.AddWithValue("@idplg", idPelanggan);
                    cmd.Parameters.AddWithValue("@idlayanan", idLayanan);
                    cmd.Parameters.AddWithValue("@jumlah", jumlah);
                    cmd.Parameters.AddWithValue("@tgl_masuk", DateTime.Now);
                    cmd.Parameters.AddWithValue("@total", total);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pesanan berhasil disimpan!");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal simpan pesanan: " + ex.Message);
                }
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();

                    // 1. Cek apakah pelanggan sudah ada berdasarkan no_hp
                    int idPelanggan;
                    string cekPelanggan = "SELECT id_plg FROM pelanggan WHERE no_hp_plg = @hp";
                    using (MySqlCommand cekCmd = new MySqlCommand(cekPelanggan, conn))
                    {
                        cekCmd.Parameters.AddWithValue("@hp", tbNohp.Text.Trim());
                        object result = cekCmd.ExecuteScalar();

                        if (result != null)
                        {
                            idPelanggan = Convert.ToInt32(result);
                        }
                        else
                        {
                            string insert = "INSERT INTO pelanggan (nama_plg, no_hp_plg) VALUES (@nama, @hp)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insert, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@nama", tbNamaplg.Text.Trim());
                                insertCmd.Parameters.AddWithValue("@hp", tbNohp.Text.Trim());
                                insertCmd.ExecuteNonQuery();
                                idPelanggan = (int)insertCmd.LastInsertedId;
                            }
                        }
                    }

                    // 2. Ambil layanan yang dipilih
                    LayananItem layananDipilih = cbLayanan.SelectedItem as LayananItem;
                    if (layananDipilih == null)
                    {
                        MessageBox.Show("Silakan pilih layanan terlebih dahulu.");
                        return;
                    }

                    int idLayanan = layananDipilih.Id;
                    decimal harga = layananDipilih.Harga;

                    // 3. Hitung total
                    int jumlah = int.Parse(tbJumlah.Text);
                    decimal total = jumlah * harga;

                    // 4. Simpan pesanan dengan status default
                    string insertPesanan = @"INSERT INTO pesanan 
                (id_user, id_plg, id_layanan, jumlah, tgl_masuk, total_harga, pembayaran, status_pengerjaan)
                VALUES 
                (@iduser, @idplg, @idlayanan, @jumlah, @tgl_masuk, @total, 'Belum bayar', 'Menunggu')";
                    MySqlCommand cmd = new MySqlCommand(insertPesanan, conn);
                    cmd.Parameters.AddWithValue("@iduser", SessionUser.IdUser);
                    cmd.Parameters.AddWithValue("@idplg", idPelanggan);
                    cmd.Parameters.AddWithValue("@idlayanan", idLayanan);
                    cmd.Parameters.AddWithValue("@jumlah", jumlah);
                    cmd.Parameters.AddWithValue("@tgl_masuk", DateTime.Now);
                    cmd.Parameters.AddWithValue("@total", total);

                    cmd.ExecuteNonQuery();

                    int lastInsertedId = (int)cmd.LastInsertedId;

                    // 5. Tampilkan FormBayarPesanan berdasarkan ID terakhir
                    FormBayarPesanan frm = new FormBayarPesanan(lastInsertedId);
                    frm.ShowDialog();

                    this.Close(); // Tutup form tambah
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal simpan & proses pembayaran: " + ex.Message);
                }
            }
        }

    }
}
