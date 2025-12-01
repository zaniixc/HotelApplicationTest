using HotelApplication.Components;
using HotelApplication.Forms.Auth;

namespace HotelApplication
{
    public partial class LoginFrm : RoundedCorners
    {
        public LoginFrm()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void LoginFrm_Load(object sender, EventArgs e)
        {

        }
        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterFrm registerFrm = new RegisterFrm();
            registerFrm.Show();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void forgotBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
