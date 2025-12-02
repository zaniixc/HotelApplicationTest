using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelApp.UI.Helpers;
using HotelApplication.Components;
using HotelApplication.Helpers;
using static HotelApplication.Components.RoundedCorners;

namespace HotelApplication.Forms.Dashboard
{
    public partial class FrmMainDashboard : RoundedCorners
    { // Only declare NEW items here. 
      // DO NOT declare 'leftPanel', 'contentPanel', 'btnLogout' etc. 
      // They are already in the Designer file.

        private Panel pnlNavButtons; // We create this one dynamically
        private Label lblLogo;       // We create this one dynamically
        private CustomerUC activeCustomerPanel;

        public FrmMainDashboard()
        {
            InitializeComponent();

            // --- DEV MODE FIX ---
            if (SessionManager.CurrentUser == null)
            {
                var debugUser = MockDataManager.GetUser("customer2");
                SessionManager.Login(debugUser);
            }

            SetupDynamicUI();
        }

        private void FrmMainDashboard_Load(object sender, EventArgs e)
        {
            string role = SessionManager.CurrentUser?.Role ?? "Guest";
            SetupSidebarButtons(role);

            if (role == "Customer")
            {
                activeCustomerPanel = new CustomerUC();
                ShowView(activeCustomerPanel);
            }
            else if (role == "Admin")
            {
                ShowView(new Admin());
            }
            else
            {
                MessageBox.Show("Welcome Staff");
            }
        }

        // --- DYNAMIC UI SETUP ---
        private void SetupDynamicUI()
        {
            // 1. Logo
            lblLogo = new Label();
            lblLogo.Text = "GRAND\nHORIZON";
            lblLogo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblLogo.ForeColor = HotelPalette.Accent;
            lblLogo.Location = new Point(20, 20);
            lblLogo.AutoSize = true;

            // We use 'this.leftPanel' which comes from the Designer
            this.leftPanel.Controls.Add(lblLogo);

            // 2. Nav Button Container
            pnlNavButtons = new Panel();
            pnlNavButtons.Location = new Point(0, 100);
            pnlNavButtons.Size = new Size(160, 400);
            pnlNavButtons.BackColor = Color.Transparent;
            this.leftPanel.Controls.Add(pnlNavButtons);
            pnlNavButtons.BringToFront();
        }

        private void SetupSidebarButtons(string role)
        {
            pnlNavButtons.Controls.Clear();
            int buttonY = 10;

            if (role == "Customer")
            {
                AddSidebarButton("Browse Rooms", (s, e) => activeCustomerPanel?.LoadAvailableRooms(), ref buttonY);
                AddSidebarButton("Room Service", (s, e) => activeCustomerPanel?.LoadRoomServices(), ref buttonY);
                AddSidebarButton("My History", (s, e) => activeCustomerPanel?.LoadHistory(), ref buttonY);
            }
            else if (role == "Admin")
            {
                AddSidebarButton("User Management", (s, e) => ShowView(new Admin()), ref buttonY);
                AddSidebarButton("Room Settings", (s, e) => MessageBox.Show("Room Settings View"), ref buttonY);
                AddSidebarButton("System Logs", (s, e) => MessageBox.Show("Logs View"), ref buttonY);
            }
        }

        private void AddSidebarButton(string text, EventHandler onClick, ref int yPos)
        {
            RoundedButton btn = new RoundedButton();
            btn.Text = text;
            btn.BackColor = Color.FromArgb(64, 64, 64);
            btn.ForeColor = Color.White;
            btn.Size = new Size(140, 40);
            btn.Location = new Point(20, yPos);
            btn.BorderRadius = 8;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(10, 0, 0, 0);
            btn.Click += (s, e) =>
            {
                foreach (Control c in pnlNavButtons.Controls)
                    if (c is RoundedButton b) b.BackColor = Color.FromArgb(64, 64, 64);

                ((RoundedButton)s).BackColor = HotelPalette.Accent;
                onClick?.Invoke(s, e);
            };

            pnlNavButtons.Controls.Add(btn);
            yPos += 50;
        }

        private void ShowView(UserControl view)
        {
            this.contentPanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(view);
        }

        // --- EVENTS LINKED TO DESIGNER ---
        // Ensure the button in Designer has Click event set to 'btnLogout_Click'
        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            LoginFrm login = new LoginFrm();
            login.Show();
            this.Close();
        }
    }
}
