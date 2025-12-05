using HotelApp.UI.Components;
using HotelApplication.Components;
using HotelApplication.Forms.Dashboard;
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
        private UITextBox txtSearchUsers;
        private Panel pnlOverlay;

        public Admin()
        {
            InitializeComponent();
            SetupStandardUI();
            LoadMockUserData();

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
            Panel pnlHeader = new Panel { Height = 60, Dock = DockStyle.Top, Padding = new Padding(20) };
            Label lblTitle = new Label { Text = "Staff Directory", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 15), AutoSize = true };
            pnlHeader.Controls.Add(lblTitle);

            // 2. Filter Bar
            Panel pnlFilter = new Panel { Height = 60, Dock = DockStyle.Top, Padding = new Padding(20, 0, 20, 0) };

            int currentX = 20;

            txtSearchUsers = new UITextBox { PlaceholderText = "Search staff...", Size = new Size(300, 35), Location = new Point(currentX, 12), BorderRadius = 15, ForeColor = HotelPalette.TextPrimary };
            // Search
            txtSearchUsers._TextChanged += (s, e) => SearchData(txtSearchUsers.Text);

            currentX += 300 + 20;

            RoundedButton btnAdd = new RoundedButton { Text = "Add Staff", BackColor = HotelPalette.Accent, ForeColor = HotelPalette.TextPrimary, Size = new Size(130, 35), Location = new Point(currentX, 12), BorderRadius = 15, Font = new Font("Segoe UI", 10) };
            btnAdd.Click += (s, e) => ShowAddModal();

            pnlFilter.Controls.Add(txtSearchUsers);
            pnlFilter.Controls.Add(btnAdd);

            // 3. Grid Content
            Panel pnlContent = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20), BackColor = HotelPalette.MainBackground };

            dgvUsers = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = HotelPalette.Surface, BorderStyle = BorderStyle.None, ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize, AllowUserToAddRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, EnableHeadersVisualStyles = false, GridColor = HotelPalette.Border, RowTemplate = { Height = 35 } };

            // Grid Styling
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = HotelPalette.Surface;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = HotelPalette.TextPrimary;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.DefaultCellStyle.BackColor = HotelPalette.MainBackground;
            dgvUsers.DefaultCellStyle.ForeColor = HotelPalette.TextSecondary;
            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            pnlContent.Controls.Add(dgvUsers);

            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlFilter);
            this.Controls.Add(pnlHeader);
        }

        private void LoadMockUserData()
        {
            dgvUsers.Columns.Add("ID", "ID");
            dgvUsers.Columns.Add("Name", "Name");
            dgvUsers.Columns.Add("Role", "Role");

            dgvUsers.Columns["ID"].Width = 80;
            dgvUsers.Columns["Name"].Width = 200;
            dgvUsers.Columns["Role"].Width = 150;

            dgvUsers.Rows.Add("101", "Alice Johnson", "Manager");
            dgvUsers.Rows.Add("102", "Bob Smith", "Receptionist");
            dgvUsers.Rows.Add("103", "Charlie Davis", "Housekeeping");
        }

        private void SearchData(string searchTerm)
        {
            if (dgvUsers.Rows.Count == 0) return;

            dgvUsers.CurrentCell = null;

            foreach (DataGridViewRow row in dgvUsers.Rows)
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
        private void ShowAddModal()
        {
            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = true;
            pnlOverlay.BringToFront();

            // Modal Card
            Panel modal = new Panel { Size = new Size(400, 380), BackColor = HotelPalette.Surface, Location = new Point((this.Width - 400) / 2, (this.Height - 380) / 2) };

            // Title
            Label title = new Label { Text = "Add New Staff", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 20), AutoSize = true };

            // 1. Name
            Label lblName = new Label { Text = "Full Name", Font = new Font("Segoe UI", 10), ForeColor = HotelPalette.TextSecondary, Location = new Point(20, 70), AutoSize = true };
            UITextBox txtName = new UITextBox { PlaceholderText = "Enter name", Location = new Point(20, 95), Size = new Size(360, 35), BorderRadius = 10, ForeColor = HotelPalette.TextPrimary };

            // 2. Role
            Label lblRole = new Label { Text = "Position / Role", Font = new Font("Segoe UI", 10), ForeColor = HotelPalette.TextSecondary, Location = new Point(20, 145), AutoSize = true };
            ComboBox cmbRole = new ComboBox { Location = new Point(20, 170), Size = new Size(360, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, BackColor = HotelPalette.MainBackground, ForeColor = HotelPalette.TextPrimary, Font = new Font("Segoe UI", 10) };
            cmbRole.Items.AddRange(new object[] { "Manager", "Receptionist", "Housekeeping", "Security", "Chef" });
            cmbRole.SelectedIndex = 1;

            // 3. ID
            Label lblID = new Label { Text = "Staff ID", Font = new Font("Segoe UI", 10), ForeColor = HotelPalette.TextSecondary, Location = new Point(20, 220), AutoSize = true };
            UITextBox txtID = new UITextBox { PlaceholderText = "e.g. 104", Location = new Point(20, 245), Size = new Size(360, 35), BorderRadius = 10, ForeColor = HotelPalette.TextPrimary };

            // Buttons
            RoundedButton btnSave = new RoundedButton { Text = "Save Staff", BackColor = HotelPalette.Accent, Size = new Size(150, 40), Location = new Point(230, 320) };
            btnSave.Click += (s, e) => {
                if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtID.Text))
                {
                    dgvUsers.Rows.Add(txtID.Text, txtName.Text, cmbRole.SelectedItem.ToString());
                    HideModal();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.");
                }
            };

            RoundedButton btnClose = new RoundedButton { Text = "Cancel", BackColor = Color.FromArgb(60, 60, 60), Size = new Size(100, 40), Location = new Point(20, 320) };
            btnClose.Click += (s, e) => HideModal();

            // Add controls to modal
            modal.Controls.Add(title);
            modal.Controls.Add(lblName);
            modal.Controls.Add(txtName);
            modal.Controls.Add(lblRole);
            modal.Controls.Add(cmbRole);
            modal.Controls.Add(lblID);
            modal.Controls.Add(txtID);
            modal.Controls.Add(btnSave);
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
