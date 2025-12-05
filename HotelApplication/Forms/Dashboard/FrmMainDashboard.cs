using HotelApp.UI.Helpers;
using HotelApplication.Components;
using HotelApplication.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApplication.Forms.Dashboard
{
    public partial class FrmMainDashboard : RoundedCorners
    {
        // Only declare NEW items here. 
        // DO NOT declare 'leftPanel', 'contentPanel', 'btnLogout' etc. 
        // They are already in the Designer file.
        private Panel pnlNavButtons; // We create this one dynamically
        private Label lblLogo; // We create this one dynamically
        private CustomerUC activeCustomerPanel;
        private Admin adminView;
        private RoomSettings roomSettingsView;
        private SystemLogs systemLogsView;

        public FrmMainDashboard()
        {
            InitializeComponent();
            SetupDynamicUI();

            // DEV MODE: Auto-login if null (Optional)
            if (SessionManager.CurrentUser == null)
            {
                var debugUser = MockDataManager.GetUser("customer1");
                SessionManager.Login(debugUser);
            }
        }

        private void FrmMainDashboard_Load(object sender, EventArgs e)
        {
            string role = SessionManager.CurrentUser?.Role ?? "Guest";
            SetupSidebarButtons(role);

            // Load Default View based on Role
            if (role == "Customer")
            {
                if (activeCustomerPanel == null) activeCustomerPanel = new CustomerUC();
                ShowView(activeCustomerPanel);
            }
            else if (role == "Admin")
            {
                if (adminView == null) adminView = new Admin();
                ShowView(adminView);
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
            this.leftPanel.Controls.Add(lblLogo);

            // 2. Nav Button Container
            pnlNavButtons = new Panel();
            pnlNavButtons.Location = new Point(0, 100);
            pnlNavButtons.Size = new Size(183, 500);
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
                // 1. User Management
                AddSidebarButton("Staff Directory", (s, e) =>
                {
                    if (adminView == null) adminView = new Admin();
                    ShowView(adminView);
                }, ref buttonY);

                // 2. Room Settings
                AddSidebarButton("Room Settings", (s, e) =>
                {
                    if (roomSettingsView == null) roomSettingsView = new RoomSettings();
                    ShowView(roomSettingsView);
                }, ref buttonY);

                // 3. System Logs
                AddSidebarButton("System Logs", (s, e) =>
                {
                    if (systemLogsView == null) systemLogsView = new SystemLogs();
                    ShowView(systemLogsView);
                }, ref buttonY);
            }
        }

        private void AddSidebarButton(string text, EventHandler onClick, ref int yPos)
        {
            RoundedButton btn = new RoundedButton();
            btn.Text = text;
            btn.BackColor = Color.FromArgb(64, 64, 64);
            btn.ForeColor = Color.White;
            btn.Size = new Size(160, 45);
            btn.Location = new Point(12, yPos);
            btn.BorderRadius = 10;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 0, 0, 0);
            btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;

            btn.Click += (s, e) =>
            {
                foreach (Control c in pnlNavButtons.Controls)
                {
                    if (c is RoundedButton b)
                    {
                        b.BackColor = Color.FromArgb(64, 64, 64);
                        b.ForeColor = Color.White;
                    }
                }

                ((RoundedButton)s).BackColor = HotelPalette.Accent;
                ((RoundedButton)s).ForeColor = Color.White;

                onClick?.Invoke(s, e);
            };

            pnlNavButtons.Controls.Add(btn);
            yPos += 55;
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
