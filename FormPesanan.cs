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
                    u.nama AS petugas,
                    p.nama_plg AS nama_pelanggan,
                    p.no_hp_plg AS no_hp_pelanggan,
                    l.nama_layanan,
                    l.harga,
                    ps.jumlah,
                    (l.harga * ps.jumlah) AS total_harga,
                    ps.tgl_masuk
                FROM pesanan ps
                JOIN user u ON ps.id_user = u.id_user
                JOIN pelanggan p ON ps.id_plg = p.id_plg
                JOIN layanan l ON ps.id_layanan = l.id_layanan
            ";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPesanan.DataSource = dt;

                    // Optional: Ganti header kolom agar lebih user-friendly
                    dgvPesanan.Columns["petugas"].HeaderText = "Petugas";
                    dgvPesanan.Columns["nama_pelanggan"].HeaderText = "Nama Pelanggan";
                    dgvPesanan.Columns["no_hp_pelanggan"].HeaderText = "No. HP";
                    dgvPesanan.Columns["nama_layanan"].HeaderText = "Layanan";
                    dgvPesanan.Columns["harga"].HeaderText = "Harga";
                    dgvPesanan.Columns["jumlah"].HeaderText = "Jumlah";
                    dgvPesanan.Columns["total_harga"].HeaderText = "Total Harga";
                    dgvPesanan.Columns["tgl_masuk"].HeaderText = "Tanggal Masuk";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error load data: " + ex.Message);
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnbayarpesanan_Click(object sender, EventArgs e)
        {

        }
    }
}
