using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLDAPMM
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ConfigureComponents();
        }

        private void InitializeLabels()
        {
            lblTitle = new Label
            {
                Text = "PHÒNG TÀI NGUYÊN MÔI TRƯỜNG HUYỆN ĐỨC TRỌNG",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 71, 160),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(50, 30),
                Size = new Size(500, 50),
                AutoSize = false
            };

            lblUsername = new Label
            {
                Text = "Tên đăng nhập:",
                Location = new Point(150, 120),
                Size = new Size(100, 20)
            };

            lblPassword = new Label
            {
                Text = "Mật khẩu:",
                Location = new Point(150, 160),
                Size = new Size(100, 20)
            };
        }

        private void InitializeTextBoxes()
        {
            txtUsername = new TextBox
            {
                Location = new Point(250, 120),
                Size = new Size(200, 20)
            };

            txtPassword = new TextBox
            {
                Location = new Point(250, 160),
                Size = new Size(200, 20),
                PasswordChar = '*'
            };
        }

        private void InitializeButtons()
        {
            btnLogin = new Button
            {
                Text = "Đăng nhập",
                Location = new Point(250, 200),
                Size = new Size(90, 30),
                BackColor = Color.FromArgb(0, 71, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLogin.Click += BtnLogin_Click;

            btnExit = new Button
            {
                Text = "Thoát",
                Location = new Point(360, 200),
                Size = new Size(90, 30),
                BackColor = Color.FromArgb(192, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnExit.Click += BtnExit_Click;
        }

        private void ConfigureComponents()
        {
            panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 244, 247)
            };

            InitializeLabels();
            InitializeTextBoxes();
            InitializeButtons();

            panel.Controls.AddRange(new Control[] {
                lblTitle, lblUsername, lblPassword,
                txtUsername, txtPassword, btnLogin, btnExit
            });

            this.Controls.Add(panel);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateLogin()
        {
            return txtUsername.Text == "Admin" && txtPassword.Text == "123456";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}