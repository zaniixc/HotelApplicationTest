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
    public partial class ForgotPasswordFrm : RoundedCorners
    {
        public ForgotPasswordFrm()
        {
            InitializeComponent();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSendReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecoveryEmail.Text))
            {
                MessageBox.Show("Please enter your username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mock logic for password reset
            MessageBox.Show("If this account exists, a temporary password has been sent to the associated email.", "Recovery Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoginFrm login = new LoginFrm();
            login.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoginFrm login = new LoginFrm();
            login.Show();
            this.Close();
        }
    }
}
