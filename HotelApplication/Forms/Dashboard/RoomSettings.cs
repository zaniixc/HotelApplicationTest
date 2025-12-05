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
    public partial class RoomSettings : UserControl
    {
        private DataGridView dgvRooms;

        public RoomSettings()
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

            Label lblTitle = new Label { Text = "Room Settings", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 15), AutoSize = true };

            pnlHeader.Controls.Add(lblTitle);

            // 2. Filter Bar
            Panel pnlFilterBar = new Panel { Height = 60, Dock = DockStyle.Top, BackColor = HotelPalette.MainBackground };

            // Dynamic X Calculation for perfect spacing
            int currentX = 20;
            int gap = 15;

            UITextBox txtSearch = new UITextBox { PlaceholderText = "Search rooms...", Size = new Size(250, 35), Location = new Point(currentX, 12), BorderRadius = 15, ForeColor = HotelPalette.TextPrimary };
            
            currentX += 250 + gap;

            RoundedButton btnAddRoom = CreateButton("Add Room", HotelPalette.Accent, ref currentX);
            RoundedButton btnEditRoom = CreateButton("Edit Room", HotelPalette.Surface, ref currentX);
            // Delete button - Color Red
            RoundedButton btnDeleteRoom = CreateButton("Delete", Color.IndianRed, ref currentX);

            pnlFilterBar.Controls.AddRange(new Control[] { txtSearch, btnAddRoom, btnEditRoom, btnDeleteRoom });

            // 3. Content Area
            Panel pnlContentArea = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20), BackColor = HotelPalette.MainBackground };

            dgvRooms = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = HotelPalette.Surface, BorderStyle = BorderStyle.None, ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize, AllowUserToAddRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, EnableHeadersVisualStyles = false, GridColor = HotelPalette.Border, RowTemplate = { Height = 35 } };

            // Grid Styling
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

        // Helper to auto-advance X position
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
    }
}
