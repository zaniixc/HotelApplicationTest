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

namespace HotelApplication.Forms.Dashboard
{
    public partial class SystemLogs : UserControl
    {
        private DataGridView dgvLogs;
        private UITextBox txtSearch;
        private Panel pnlOverlay;

        public SystemLogs()
        {
            InitializeComponent();
            SetupStandardUI();
            LoadMockData();

            pnlOverlay = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(180, 0, 0, 0), Visible = false };
            pnlOverlay.Click += (s, e) => HideModal();
            this.Controls.Add(pnlOverlay);
            pnlOverlay.BringToFront();
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

            // 3. Search Box
            txtSearch = new UITextBox { PlaceholderText = "Search by user or action...", Size = new Size(300, 35), Location = new Point(currentX, 12), BorderRadius = 15, ForeColor = HotelPalette.TextPrimary };
            // 4. Search
            txtSearch._TextChanged += (s, e) => SearchData(txtSearch.Text);

            currentX += 300 + gap;

            RoundedButton btnExport = CreateButton("Export Logs", HotelPalette.Accent, ref currentX);
            // 5. Export Logs
            btnExport.Click += (s, e) => ShowExportModal();

            RoundedButton btnClear = CreateButton("Clear All", Color.IndianRed, ref currentX);
            // 6. Clear
            btnClear.Click += (s, e) => ShowClearModal();

            pnlFilterBar.Controls.AddRange(new Control[] { txtSearch, btnExport, btnClear });

            // 7. Content Area
            Panel pnlContentArea = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20), BackColor = HotelPalette.MainBackground };

            dgvLogs = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = HotelPalette.Surface, BorderStyle = BorderStyle.None, ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize, AllowUserToAddRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, EnableHeadersVisualStyles = false, GridColor = HotelPalette.Border, RowTemplate = { Height = 35 } };

            // 8. Grid Styling
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

        private void SearchData(string searchTerm)
        {
            if (dgvLogs.Rows.Count == 0) return;

            dgvLogs.CurrentCell = null;

            foreach (DataGridViewRow row in dgvLogs.Rows)
            {
                if (row.IsNewRow) continue;

                bool isVisible = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        isVisible = true;
                        break;
                    }
                }
                row.Visible = isVisible;
            }
        }

        // --- NEW MODAL FUNCTIONALITY ---
        private void ShowExportModal()
        {
            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = true;
            pnlOverlay.BringToFront();

            // Modal Card
            Panel modal = new Panel { Size = new Size(400, 380), BackColor = HotelPalette.Surface, Location = new Point((this.Width - 400) / 2, (this.Height - 380) / 2) };

            Label title = new Label { Text = "Export Logs", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 20), AutoSize = true };

            // Export Options
            Label lblFormat = new Label { Text = "Select Format", Font = new Font("Segoe UI", 10), ForeColor = HotelPalette.TextSecondary, Location = new Point(20, 80), AutoSize = true };
            ComboBox cmbFormat = new ComboBox { Location = new Point(20, 105), Size = new Size(360, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, BackColor = HotelPalette.MainBackground, ForeColor = HotelPalette.TextPrimary, Font = new Font("Segoe UI", 10) };
            cmbFormat.Items.AddRange(new object[] { "CSV (Comma Separated)", "PDF Document", "JSON Data" });
            cmbFormat.SelectedIndex = 0;

            Label lblRange = new Label { Text = "Date Range", Font = new Font("Segoe UI", 10), ForeColor = HotelPalette.TextSecondary, Location = new Point(20, 155), AutoSize = true };
            ComboBox cmbRange = new ComboBox { Location = new Point(20, 180), Size = new Size(360, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, BackColor = HotelPalette.MainBackground, ForeColor = HotelPalette.TextPrimary, Font = new Font("Segoe UI", 10) };
            cmbRange.Items.AddRange(new object[] { "All Time", "Last 7 Days", "Last 30 Days", "Today" });
            cmbRange.SelectedIndex = 0;

            Label lblInfo = new Label { Text = "The exported file will be saved to your local Documents folder.", Font = new Font("Segoe UI", 9), ForeColor = Color.Gray, Location = new Point(20, 230), Size = new Size(360, 40) };

            // Buttons
            RoundedButton btnConfirm = new RoundedButton { Text = "Export Now", BackColor = HotelPalette.Accent, Size = new Size(150, 40), Location = new Point(230, 320) };
            btnConfirm.Click += (s, e) => {
                MessageBox.Show($"Logs exported as {cmbFormat.SelectedItem} successfully.");
                HideModal();
            };

            RoundedButton btnClose = new RoundedButton { Text = "Cancel", BackColor = Color.FromArgb(60, 60, 60), Size = new Size(100, 40), Location = new Point(20, 320) };
            btnClose.Click += (s, e) => HideModal();

            modal.Controls.Add(title);
            modal.Controls.Add(lblFormat); modal.Controls.Add(cmbFormat);
            modal.Controls.Add(lblRange); modal.Controls.Add(cmbRange);
            modal.Controls.Add(lblInfo);
            modal.Controls.Add(btnConfirm);
            modal.Controls.Add(btnClose);

            pnlOverlay.Controls.Add(modal);
        }

        private void ShowClearModal()
        {
            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = true;
            pnlOverlay.BringToFront();

            // Modal Card
            Panel modal = new Panel { Size = new Size(400, 380), BackColor = HotelPalette.Surface, Location = new Point((this.Width - 400) / 2, (this.Height - 380) / 2) };

            Label title = new Label { Text = "Clear System Logs", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 20), AutoSize = true };

            Label lblWarning = new Label
            {
                Text = $"WARNING: You are about to delete all system activity logs.\n\nThis action cannot be undone.",
                Font = new Font("Segoe UI", 11),
                ForeColor = HotelPalette.TextPrimary,
                Location = new Point(20, 100),
                Size = new Size(360, 120)
            };

            // Buttons
            RoundedButton btnConfirm = new RoundedButton { Text = "Clear All", BackColor = Color.IndianRed, Size = new Size(150, 40), Location = new Point(230, 320) };
            btnConfirm.Click += (s, e) => {
                dgvLogs.Rows.Clear();
                MessageBox.Show("All logs have been cleared.");
                HideModal();
            };

            RoundedButton btnClose = new RoundedButton { Text = "Cancel", BackColor = Color.FromArgb(60, 60, 60), Size = new Size(100, 40), Location = new Point(20, 320) };
            btnClose.Click += (s, e) => HideModal();

            modal.Controls.Add(title);
            modal.Controls.Add(lblWarning);
            modal.Controls.Add(btnConfirm);
            modal.Controls.Add(btnClose);

            pnlOverlay.Controls.Add(modal);
        }

        private void HideModal()
        {
            pnlOverlay.Visible = false;
            pnlOverlay.Controls.Clear();
        }
    }
}
