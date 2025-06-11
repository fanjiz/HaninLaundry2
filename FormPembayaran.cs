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
    public partial class FormPembayaran : Form
    {
        int pageSize = 10;
        int currentPage = 1;
        int totalPages = 1;
        int totalRecords = 0;

        bool isFiltered = false;

        public FormPembayaran()
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
                    string countQuery = "SELECT COUNT(*) FROM pembayaran";
                    MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                    // Hitung total halaman
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    int offset = (currentPage - 1) * pageSize;

                    string query = @"
                SELECT 
                    pb.id_pembayaran,
                    pb.id_pesanan,
                    pl.nama_plg AS nama_pelanggan,
                    us.nama AS nama_petugas,
                    ly.nama_layanan,
                    ly.harga,
                    pb.jumlah,
                    pb.total_harga,
                    pb.uang_diterima,
                    pb.uang_kembali,
                    pb.tgl_masuk,
                    pb.waktu_bayar
                FROM pembayaran pb
                JOIN pelanggan pl ON pb.id_plg = pl.id_plg
                JOIN user us ON pb.id_user = us.id_user
                JOIN layanan ly ON pb.id_layanan = ly.id_layanan
                ORDER BY pb.waktu_bayar DESC
                LIMIT @limit OFFSET @offset";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@limit", pageSize);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPembayaran.DataSource = dt;

                    // Header
                    dgvPembayaran.Columns["id_pembayaran"].HeaderText = "ID Pembayaran";
                    dgvPembayaran.Columns["id_pesanan"].HeaderText = "ID Pesanan";
                    dgvPembayaran.Columns["nama_pelanggan"].HeaderText = "Nama Pelanggan";
                    dgvPembayaran.Columns["nama_petugas"].HeaderText = "Petugas";
                    dgvPembayaran.Columns["nama_layanan"].HeaderText = "Layanan";
                    dgvPembayaran.Columns["harga"].HeaderText = "Harga";
                    dgvPembayaran.Columns["jumlah"].HeaderText = "Jumlah";
                    dgvPembayaran.Columns["total_harga"].HeaderText = "Total Harga";
                    dgvPembayaran.Columns["uang_diterima"].HeaderText = "Uang Diterima";
                    dgvPembayaran.Columns["uang_kembali"].HeaderText = "Uang Kembali";
                    dgvPembayaran.Columns["tgl_masuk"].HeaderText = "Tanggal Masuk";
                    dgvPembayaran.Columns["waktu_bayar"].HeaderText = "Waktu Bayar";

                    dgvPembayaran.Columns["tgl_masuk"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvPembayaran.Columns["waktu_bayar"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvPembayaran.Columns["harga"].DefaultCellStyle.Format =
                    dgvPembayaran.Columns["total_harga"].DefaultCellStyle.Format =
                    dgvPembayaran.Columns["uang_diterima"].DefaultCellStyle.Format =
                    dgvPembayaran.Columns["uang_kembali"].DefaultCellStyle.Format = "C0";

                    // Update info halaman
                    lblPageInfo.Text = $"Halaman {currentPage} dari {totalPages}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal load data pembayaran: " + ex.Message);
                }
            }
        }

        private void TampilkanDataFiltered()
        {
            string keyword = tbCari.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                conn.Open();

                string countQuery = @"
            SELECT COUNT(*) FROM pembayaran pb
            JOIN pelanggan pl ON pb.id_plg = pl.id_plg
            JOIN user us ON pb.id_user = us.id_user
            JOIN layanan ly ON pb.id_layanan = ly.id_layanan
            WHERE 
                pb.id_pembayaran LIKE @kw OR
                pb.id_pesanan LIKE @kw OR
                pl.nama_plg LIKE @kw OR
                us.nama LIKE @kw OR
                ly.nama_layanan LIKE @kw OR
                ly.harga LIKE @kw OR
                pb.jumlah LIKE @kw OR
                pb.total_harga LIKE @kw OR
                pb.uang_diterima LIKE @kw OR
                pb.uang_kembali LIKE @kw OR
                pb.tgl_masuk LIKE @kw OR
                pb.waktu_bayar LIKE @kw";

                MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                countCmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                if (currentPage > totalPages) currentPage = totalPages;
                if (currentPage < 1) currentPage = 1;

                int offset = (currentPage - 1) * pageSize;

                string query = @"
            SELECT 
                pb.id_pembayaran,
                pb.id_pesanan,
                pl.nama_plg AS nama_pelanggan,
                us.nama AS nama_petugas,
                ly.nama_layanan,
                ly.harga,
                pb.jumlah,
                pb.total_harga,
                pb.uang_diterima,
                pb.uang_kembali,
                pb.tgl_masuk,
                pb.waktu_bayar
            FROM pembayaran pb
            JOIN pelanggan pl ON pb.id_plg = pl.id_plg
            JOIN user us ON pb.id_user = us.id_user
            JOIN layanan ly ON pb.id_layanan = ly.id_layanan
            WHERE 
                pb.id_pembayaran LIKE @kw OR
                pb.id_pesanan LIKE @kw OR
                pl.nama_plg LIKE @kw OR
                us.nama LIKE @kw OR
                ly.nama_layanan LIKE @kw OR
                ly.harga LIKE @kw OR
                pb.jumlah LIKE @kw OR
                pb.total_harga LIKE @kw OR
                pb.uang_diterima LIKE @kw OR
                pb.uang_kembali LIKE @kw OR
                pb.tgl_masuk LIKE @kw OR
                pb.waktu_bayar LIKE @kw
            ORDER BY pb.waktu_bayar DESC
            LIMIT @limit OFFSET @offset";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                cmd.Parameters.AddWithValue("@limit", pageSize);
                cmd.Parameters.AddWithValue("@offset", offset);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPembayaran.DataSource = dt;

                dgvPembayaran.Columns["tgl_masuk"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                dgvPembayaran.Columns["waktu_bayar"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                dgvPembayaran.Columns["harga"].DefaultCellStyle.Format =
                dgvPembayaran.Columns["total_harga"].DefaultCellStyle.Format =
                dgvPembayaran.Columns["uang_diterima"].DefaultCellStyle.Format =
                dgvPembayaran.Columns["uang_kembali"].DefaultCellStyle.Format = "C0";

                lblPageInfo.Text = $"Halaman {currentPage} dari {totalPages}";
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

        private void btnCari_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            isFiltered = true;
            TampilkanDataFiltered();
        }


    }
}
