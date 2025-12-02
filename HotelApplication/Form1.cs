using HotelApp.UI.Helpers;
using HotelApplication.Components;
using HotelApplication.Forms.Dashboard;
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
            // --- CRITICAL FIX ---
            // This line forces the button to listen to the click event.
            // Often the Designer "forgets" this link when copying code.
            this.loginBtn.Click += new EventHandler(loginBtn_Click);

            // Usability Bonus: Pressing 'Enter' key will trigger the login button
            this.AcceptButton = loginBtn;
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // Debugging Check: Uncomment if you still suspect issues
            // MessageBox.Show("Button Clicked!"); 

            string username = userTextBox.Text.Trim();
            string password = passTxtBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserData user = MockDataManager.GetUser(username);

            // Verify Password
            if (user != null && user.Password == password)
            {
                // 1. Save Session
                SessionManager.Login(user);

                // 2. Open Dashboard
                FrmMainDashboard dashboard = new FrmMainDashboard();
                dashboard.Show();

                // 3. Hide this form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Window Controls ---
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
           // MessageBox.Show("Please contact Admin to reset password.", "Forgot Password");
        }

        // Placeholder events
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}
