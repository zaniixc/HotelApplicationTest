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
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace HotelApplication.Forms.Dashboard
{
    public partial class FrmMainDashboard : RoundedCorners
    {
        public FrmMainDashboard()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboardPage = new Dashboard();
            ShowViewInPanel(dashboardPage);
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            Admin adminPage = new Admin();
            ShowViewInPanel(adminPage);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settingsPage = new Settings();
            ShowViewInPanel(settingsPage);
        }
        private void ShowViewInPanel(UserControl view)
        {
            pnlTest.Controls.Clear();
            view.Dock = DockStyle.Fill;
            pnlTest.Controls.Add(view);
        }
    }
}
