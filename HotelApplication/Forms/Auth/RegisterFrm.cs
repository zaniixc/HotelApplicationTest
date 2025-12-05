using HotelApp.UI.Helpers;
using HotelApplication.Components;
using HotelApplication.Forms.Dashboard;
using HotelApplication.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
