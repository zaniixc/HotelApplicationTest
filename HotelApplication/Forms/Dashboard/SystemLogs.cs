using HotelApp.UI.Components;
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
using static HotelApplication.Components.RoundedCorners;

namespace HotelApplicationTest.Forms.Dashboard
{
    public partial class SystemLogs : UserControl
    {
        private DataGridView dgvLogs;

        public SystemLogs()
        {
            InitializeComponent();
            SetupStandardUI();
            LoadMockData();
        }

        private void SetupStandardUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = HotelPalette.MainBackground;

            // 1. Header
            Panel pnlHeader = new Panel { Height = 60, Dock = DockStyle.Top, BackColor = HotelPalette.MainBackground };

            Label lblTitle = new Label { Text = "System Activity Logs", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 15), AutoSize = true };

            pnlHeader.Controls.Add(lblTitle);

            // 2. Filter Bar
            Panel pnlFilterBar = new Panel { Height = 60, Dock = DockStyle.Top, BackColor = HotelPalette.MainBackground };

            int currentX = 20;
            int gap = 15;

            // Search Box
            UITextBox txtSearch = new UITextBox { PlaceholderText = "Search by user or action...", Size = new Size(300, 35), Location = new Point(currentX, 12), BorderRadius = 15, ForeColor = HotelPalette.TextPrimary };
            
            currentX += 300 + gap;

            RoundedButton btnExport = CreateButton("Export Logs", HotelPalette.Accent, ref currentX);
            RoundedButton btnClear = CreateButton("Clear All", Color.IndianRed, ref currentX);

            pnlFilterBar.Controls.AddRange(new Control[] { txtSearch, btnExport, btnClear });

            // 3. Content Area
            Panel pnlContentArea = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20), BackColor = HotelPalette.MainBackground };

            dgvLogs = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = HotelPalette.Surface, BorderStyle = BorderStyle.None, ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize, AllowUserToAddRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, EnableHeadersVisualStyles = false, GridColor = HotelPalette.Border, RowTemplate = { Height = 35 } };

            // Grid Styling
            dgvLogs.ColumnHeadersDefaultCellStyle.BackColor = HotelPalette.Surface;
            dgvLogs.ColumnHeadersDefaultCellStyle.ForeColor = HotelPalette.TextPrimary;
            dgvLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLogs.DefaultCellStyle.BackColor = HotelPalette.MainBackground;
            dgvLogs.DefaultCellStyle.ForeColor = HotelPalette.TextSecondary;
            dgvLogs.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            pnlContentArea.Controls.Add(dgvLogs);

            this.Controls.Add(pnlContentArea);
            this.Controls.Add(pnlFilterBar);
            this.Controls.Add(pnlHeader);
        }

        private RoundedButton CreateButton(string text, Color bg, ref int xPos)
        {
            int btnWidth = 130;
            RoundedButton btn = new RoundedButton
            {
                Text = text,
                BackColor = bg,
                ForeColor = Color.White,
                Size = new Size(btnWidth, 35),
                Location = new Point(xPos, 12),
                BorderRadius = 15,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            xPos += btnWidth + 15;
            return btn;
        }

        private void LoadMockData()
        {
            dgvLogs.Columns.Add("Time", "Timestamp");
            dgvLogs.Columns.Add("Level", "Level");
            dgvLogs.Columns.Add("Action", "Action");
            dgvLogs.Columns.Add("User", "User");

            dgvLogs.Columns["Time"].Width = 140;
            dgvLogs.Columns["Level"].Width = 80;
            dgvLogs.Columns["Action"].Width = 200;
            dgvLogs.Columns["User"].Width = 120;

            dgvLogs.Rows.Add(DateTime.Now.ToString("g"), "Info", "User Login", "Alice");
            dgvLogs.Rows.Add(DateTime.Now.AddMinutes(-5).ToString("g"), "Warning", "Failed Login", "Unknown");
            dgvLogs.Rows.Add(DateTime.Now.AddMinutes(-10).ToString("g"), "Info", "Room 101 CheckIn", "Bob");
        }
    }
}
