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
    public partial class RoomSettings : UserControl
    {
        private DataGridView dgvRooms;
        private UITextBox txtSearch;
        private Panel pnlOverlay;

        public RoomSettings()
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

            Label lblTitle = new Label { Text = "Room Settings", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 15), AutoSize = true };

            pnlHeader.Controls.Add(lblTitle);

            // 2. Filter Bar
            Panel pnlFilterBar = new Panel { Height = 60, Dock = DockStyle.Top, BackColor = HotelPalette.MainBackground };

            int currentX = 20;
            int gap = 15;

            txtSearch = new UITextBox { PlaceholderText = "Search rooms...", Size = new Size(300, 35), Location = new Point(currentX, 12), BorderRadius = 15, ForeColor = HotelPalette.TextPrimary };
            // 3. Search
            txtSearch._TextChanged += (s, e) => SearchData(txtSearch.Text);

            currentX += 300 + gap;

            RoundedButton btnEditRoom = CreateButton("Edit Room", HotelPalette.Surface, ref currentX);
            // 4. Edit
            btnEditRoom.Click += (s, e) => ShowEditModal();

            RoundedButton btnDeleteRoom = CreateButton("Delete", Color.IndianRed, ref currentX);
            // 5. Delete
            btnDeleteRoom.Click += (s, e) => ShowDeleteModal();

            pnlFilterBar.Controls.AddRange(new Control[] { txtSearch, btnEditRoom, btnDeleteRoom });

            // 6. Content Area
            Panel pnlContentArea = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20), BackColor = HotelPalette.MainBackground };

            dgvRooms = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = HotelPalette.Surface, BorderStyle = BorderStyle.None, ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize, AllowUserToAddRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, EnableHeadersVisualStyles = false, GridColor = HotelPalette.Border, RowTemplate = { Height = 35 } };

            // 7. Grid Styling
            dgvRooms.ColumnHeadersDefaultCellStyle.BackColor = HotelPalette.Surface;
            dgvRooms.ColumnHeadersDefaultCellStyle.ForeColor = HotelPalette.TextPrimary;
            dgvRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRooms.DefaultCellStyle.BackColor = HotelPalette.MainBackground;
            dgvRooms.DefaultCellStyle.ForeColor = HotelPalette.TextSecondary;
            dgvRooms.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            pnlContentArea.Controls.Add(dgvRooms);

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
                ForeColor = (bg == HotelPalette.Surface) ? HotelPalette.TextPrimary : Color.White,
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
            dgvRooms.Columns.Add("RoomNo", "Room #");
            dgvRooms.Columns.Add("Type", "Type");
            dgvRooms.Columns.Add("Price", "Price");
            dgvRooms.Columns.Add("Status", "Status");

            dgvRooms.Columns["RoomNo"].Width = 80;
            dgvRooms.Columns["Type"].Width = 150;
            dgvRooms.Columns["Price"].Width = 100;
            dgvRooms.Columns["Status"].Width = 120;

            dgvRooms.Rows.Add("101", "Deluxe King", "$150.00", "Available");
            dgvRooms.Rows.Add("102", "Standard Queen", "$100.00", "Occupied");
            dgvRooms.Rows.Add("201", "Suite", "$250.00", "Maintenance");
        }

        private void SearchData(string searchTerm)
        {
            if (dgvRooms.Rows.Count == 0) return;

            dgvRooms.CurrentCell = null;

            foreach (DataGridViewRow row in dgvRooms.Rows)
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

        // --- MODAL LOGIC ---
        private void ShowEditModal()
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to edit.");
                return;
            }

            DataGridViewRow row = dgvRooms.SelectedRows[0];
            string currentNo = row.Cells["RoomNo"].Value?.ToString() ?? "";
            string currentType = row.Cells["Type"].Value?.ToString() ?? "";
            string currentPrice = row.Cells["Price"].Value?.ToString() ?? "";
            string currentStatus = row.Cells["Status"].Value?.ToString() ?? "";

            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = true;
            pnlOverlay.BringToFront();

            // Modal Card
            Panel modal = new Panel { Size = new Size(400, 380), BackColor = HotelPalette.Surface, Location = new Point((this.Width - 400) / 2, (this.Height - 380) / 2) };

            Label title = new Label { Text = "Edit Room Details", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 20), AutoSize = true };

            // Inputs arranged to fit height
            Label lblNo = new Label { Text = "Room Number", Font = new Font("Segoe UI", 9), ForeColor = HotelPalette.TextSecondary, Location = new Point(20, 70), AutoSize = true };
            UITextBox txtRoomNo = new UITextBox { Text = currentNo, Location = new Point(20, 90), Size = new Size(360, 30), BorderRadius = 10 };

            Label lblType = new Label { Text = "Room Type", Font = new Font("Segoe UI", 9), ForeColor = HotelPalette.TextSecondary, Location = new Point(20, 130), AutoSize = true };
            ComboBox cmbType = new ComboBox { Text = currentType, Location = new Point(20, 150), Size = new Size(360, 30), FlatStyle = FlatStyle.Flat, BackColor = HotelPalette.MainBackground, ForeColor = HotelPalette.TextPrimary };
            cmbType.Items.AddRange(new object[] { "Deluxe King", "Standard Queen", "Suite", "Economy Single" });

            Label lblPrice = new Label { Text = "Price Per Night", Font = new Font("Segoe UI", 9), ForeColor = HotelPalette.TextSecondary, Location = new Point(20, 190), AutoSize = true };
            UITextBox txtPrice = new UITextBox { Text = currentPrice, Location = new Point(20, 210), Size = new Size(360, 30), BorderRadius = 10 };

            Label lblStatus = new Label { Text = "Status", Font = new Font("Segoe UI", 9), ForeColor = HotelPalette.TextSecondary, Location = new Point(20, 250), AutoSize = true };
            ComboBox cmbStatus = new ComboBox { Text = currentStatus, Location = new Point(20, 270), Size = new Size(360, 30), FlatStyle = FlatStyle.Flat, BackColor = HotelPalette.MainBackground, ForeColor = HotelPalette.TextPrimary };
            cmbStatus.Items.AddRange(new object[] { "Available", "Occupied", "Maintenance", "Cleaning" });

            // Buttons
            RoundedButton btnSave = new RoundedButton { Text = "Save Changes", BackColor = HotelPalette.Accent, Size = new Size(150, 40), Location = new Point(230, 320) };
            btnSave.Click += (s, e) =>
            {
                row.Cells["RoomNo"].Value = txtRoomNo.Text;
                row.Cells["Type"].Value = cmbType.Text;
                row.Cells["Price"].Value = txtPrice.Text;
                row.Cells["Status"].Value = cmbStatus.Text;
                HideModal();
            };

            RoundedButton btnClose = new RoundedButton { Text = "Cancel", BackColor = Color.FromArgb(60, 60, 60), Size = new Size(100, 40), Location = new Point(20, 320) };
            btnClose.Click += (s, e) => HideModal();

            modal.Controls.Add(title);
            modal.Controls.Add(lblNo); modal.Controls.Add(txtRoomNo);
            modal.Controls.Add(lblType); modal.Controls.Add(cmbType);
            modal.Controls.Add(lblPrice); modal.Controls.Add(txtPrice);
            modal.Controls.Add(lblStatus); modal.Controls.Add(cmbStatus);
            modal.Controls.Add(btnSave);
            modal.Controls.Add(btnClose);

            pnlOverlay.Controls.Add(modal);
        }

        private void ShowDeleteModal()
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to delete.");
                return;
            }

            DataGridViewRow row = dgvRooms.SelectedRows[0];
            string roomNo = row.Cells["RoomNo"].Value?.ToString();

            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = true;
            pnlOverlay.BringToFront();

            // Modal Card
            Panel modal = new Panel { Size = new Size(400, 380), BackColor = HotelPalette.Surface, Location = new Point((this.Width - 400) / 2, (this.Height - 380) / 2) };

            Label title = new Label { Text = "Delete Room", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 20), AutoSize = true };

            Label lblWarning = new Label
            {
                Text = $"WARNING: Are you sure you want to permanently delete Room {roomNo}?\n\nThis action cannot be undone.",
                Font = new Font("Segoe UI", 11),
                ForeColor = HotelPalette.TextPrimary,
                Location = new Point(20, 100),
                Size = new Size(360, 100)
            };

            // Buttons
            RoundedButton btnConfirm = new RoundedButton { Text = "Delete", BackColor = Color.IndianRed, Size = new Size(150, 40), Location = new Point(230, 320) };
            btnConfirm.Click += (s, e) =>
            {
                dgvRooms.Rows.Remove(row);
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
