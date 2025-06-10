namespace HaninLaundry
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            btnLogin = new Button();
            lblUsername = new Label();
            lblPassword = new Label();
            tbEmail = new TextBox();
            tbPassword = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            panelWrapper = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelWrapper.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.MenuHighlight;
            btnLogin.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(140, 221);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(78, 30);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Masuk";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = SystemColors.ButtonHighlight;
            lblUsername.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(153, 95);
            lblUsername.Margin = new Padding(2, 0, 2, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(41, 17);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = SystemColors.ButtonHighlight;
            lblPassword.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(140, 153);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 17);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // tbEmail
            // 
            tbEmail.BackColor = SystemColors.HighlightText;
            tbEmail.Location = new Point(95, 114);
            tbEmail.Margin = new Padding(2);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(155, 23);
            tbEmail.TabIndex = 5;
            tbEmail.TextChanged += tbEmail_TextChanged;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(95, 169);
            tbPassword.Margin = new Padding(2);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(155, 23);
            tbPassword.TabIndex = 6;
            tbPassword.TextChanged += tbPassword_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(tbEmail);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(lblPassword);
            panel1.ForeColor = SystemColors.InactiveCaptionText;
            panel1.Location = new Point(20, 59);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(1);
            panel1.Size = new Size(348, 292);
            panel1.TabIndex = 8;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(-1, -1);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(348, 49);
            panel2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.MenuHighlight;
            label2.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(143, 17);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 22);
            label2.TabIndex = 7;
            label2.Text = "Masuk";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(41, 17);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(1);
            panel3.Size = new Size(318, 38);
            panel3.TabIndex = 9;
            panel3.Paint += panel3_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(66, 2);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(209, 35);
            label3.TabIndex = 1;
            label3.Text = "Hanin Laundry";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.BackgroundImage = Properties.Resources.laundry_51722662;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(10, 2);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 34);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelWrapper
            // 
            panelWrapper.BackColor = Color.Transparent;
            panelWrapper.Controls.Add(panel3);
            panelWrapper.Controls.Add(panel1);
            panelWrapper.Location = new Point(182, 50);
            panelWrapper.Name = "panelWrapper";
            panelWrapper.Size = new Size(396, 374);
            panelWrapper.TabIndex = 10;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.login;
            ClientSize = new Size(800, 450);
            Controls.Add(panelWrapper);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLogin";
            Text = "LoginForm";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelWrapper.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnLogin;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox tbEmail;
        private TextBox tbPassword;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label label3;
        private Panel panelWrapper;
    }
}
