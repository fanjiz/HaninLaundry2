namespace HaninLaundry
{
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
