using MySql.Data.MySqlClient;

namespace HaninLaundry
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Pusatkan wrapper ke tengah layar
            panelWrapper.Left = (this.ClientSize.Width - panelWrapper.Width) / 2;
            panelWrapper.Top = (this.ClientSize.Height - panelWrapper.Height) / 2;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panelWrapper.Left = (this.ClientSize.Width - panelWrapper.Width) / 2;
            panelWrapper.Top = (this.ClientSize.Height - panelWrapper.Height) / 2;
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("email dan Password harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT password FROM user WHERE email = @email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string hashedPassword = result.ToString();

                            if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                            {
                                MessageBox.Show("Login berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                new FormPesanan().ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Password salah!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("email tidak ditemukan!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
