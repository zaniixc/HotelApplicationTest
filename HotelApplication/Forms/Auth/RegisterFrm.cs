using HotelApplication.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApplication.Forms.Auth
{
    public partial class RegisterFrm : RoundedCorners
    {
        public RegisterFrm()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void btnRegister_Click(object sender, EventArgs e)
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
        private void returnToLogInLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginFrm loginFrm = new LoginFrm();
            loginFrm.Show();
        }
    }
}
