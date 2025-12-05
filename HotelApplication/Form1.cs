using HotelApp.UI.Helpers;
using HotelApplication.Components;
using HotelApplication.Forms.Dashboard;
using HotelApplication.Forms.Auth;
using HotelApplication.Helpers;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace HotelApplication
{
    public partial class LoginFrm : RoundedCorners
    {
        public LoginFrm()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.AcceptButton = loginBtn;
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = userTextBox.Text.Trim();
            string password = passTxtBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserData user = MockDataManager.GetUser(username);

            if (user != null && user.Password == password)
            {
                SessionManager.Login(user);

                FrmMainDashboard dashboard = new FrmMainDashboard();

                dashboard.FormClosed += (s, args) => this.Show();

                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void forgotBtn_Click(object sender, EventArgs e)
        {
            ForgotPasswordFrm forgotForm = new ForgotPasswordFrm();
            forgotForm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterFrm registerForm = new RegisterFrm();
            registerForm.Show();
            this.Hide();
        }
    }
}
