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
    public partial class Admin : UserControl
    {
        private DataGridView dgvUsers;
        private Label lblTitle;
        private RoundedButton btnAddUser;
        private RoundedButton btnEditUser;
        private RoundedButton btnDeleteUser;
        private UITextBox txtSearch; 
        private Panel pnlHeader;

        public Admin()
        {
            InitializeComponent();
            SetupManualUI();
            LoadMockData();
        }

        private void SetupManualUI()
        {
            this.Size = new Size(800, 600);
            this.BackColor = HotelPalette.MainBackground;

            // 1. Header Area
            lblTitle = new Label();
            lblTitle.Text = "User Management";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = HotelPalette.TextPrimary;
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;

            // 2. Search Bar
            txtSearch = new UITextBox();
            txtSearch.PlaceholderText = "Search staff by name...";
            txtSearch.Location = new Point(20, 70);
            txtSearch.Size = new Size(300, 35);
            txtSearch.BorderRadius = 15;
            txtSearch.BackColor = HotelPalette.MainBackground;
            txtSearch.BorderColor = HotelPalette.Border;
            txtSearch._TextChanged += TxtSearch_TextChanged;

            // 3. Action Buttons
            btnAddUser = CreateButton("Add Staff", HotelPalette.Accent, 340);
            btnEditUser = CreateButton("Edit Selected", HotelPalette.Surface, 500);
            btnDeleteUser = CreateButton("Deactivate", Color.IndianRed, 660);

            // 4. Data Grid View (The list)
            dgvUsers = new DataGridView();
            dgvUsers.Location = new Point(20, 120);
            dgvUsers.Size = new Size(760, 460);
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.BackgroundColor = HotelPalette.Surface;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.AllowUserToAddRows = false;

            // Basic Grid Styling to match theme
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = HotelPalette.Surface;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = HotelPalette.TextPrimary;
            dgvUsers.DefaultCellStyle.BackColor = HotelPalette.MainBackground;
            dgvUsers.DefaultCellStyle.ForeColor = HotelPalette.TextSecondary;
            dgvUsers.GridColor = HotelPalette.Border;

            // Add controls to UserControl
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnAddUser);
            this.Controls.Add(btnEditUser);
            this.Controls.Add(btnDeleteUser);
            this.Controls.Add(dgvUsers);
        }

        // Helper to create consistent buttons
        private RoundedButton CreateButton(string text, Color bg, int x)
        {
            RoundedButton btn = new RoundedButton();
            btn.Text = text;
            btn.BackColor = bg;
            btn.ForeColor = Color.White;
            btn.Size = new Size(140, 35);
            btn.Location = new Point(x, 70);
            btn.BorderRadius = 10;
            btn.Click += ActionButton_Click;
            return btn;
        }

        // --- Mock Functionality ---

        private void LoadMockData()
        {
            // Setup Columns
            dgvUsers.Columns.Add("ID", "ID");
            dgvUsers.Columns.Add("Name", "Full Name");
            dgvUsers.Columns.Add("Role", "Role");
            dgvUsers.Columns.Add("Status", "Status");

            // Add Mock Rows
            dgvUsers.Rows.Add("101", "Alice Johnson", "Manager", "Active");
            dgvUsers.Rows.Add("102", "Bob Smith", "Receptionist", "Active");
            dgvUsers.Rows.Add("103", "Charlie Davis", "Housekeeping", "On Leave");
            dgvUsers.Rows.Add("104", "Diana Prince", "Receptionist", "Active");
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Simple mock filter logic
            string query = txtSearch.Text.ToLower();
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.IsNewRow) continue;
                string name = row.Cells["Name"].Value.ToString().ToLower();
                row.Visible = name.Contains(query);
            }
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            RoundedButton btn = (RoundedButton)sender;
            MessageBox.Show($"You clicked: {btn.Text}\n(This would open a form to {btn.Text})");
        }
    }
}
