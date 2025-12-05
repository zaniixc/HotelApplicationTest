using HotelApp.UI.Components;
using HotelApplication.Components;
using HotelApplicationTest.Forms.Dashboard;
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
        private Panel pnlUserView;
        private DataGridView dgvUsers;
        private UITextBox txtSearchUsers;

        public Admin()
        {
            InitializeComponent();

            // Setup the view directly
            InitializeUserManagementView();
            LoadMockUserData();

            // Add the user view to the control immediately
            pnlUserView.Dock = DockStyle.Fill;
            this.Controls.Add(pnlUserView);
        }

        private void InitializeUserManagementView()
        {
            pnlUserView = new Panel { Dock = DockStyle.Fill, BackColor = HotelPalette.MainBackground };

            // 1. Header
            Panel pnlHeader = new Panel { Height = 60, Dock = DockStyle.Top, Padding = new Padding(20) };
            
            Label lblTitle = new Label { Text = "Staff Directory", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(20, 15), AutoSize = true };
            
            pnlHeader.Controls.Add(lblTitle);

            // 2. Filter Bar
            Panel pnlFilter = new Panel { Height = 60, Dock = DockStyle.Top, Padding = new Padding(20, 0, 20, 0) };

            int currentX = 20;

            txtSearchUsers = new UITextBox { PlaceholderText = "Search staff...", Size = new Size(250, 35), Location = new Point(currentX, 12), BorderRadius = 15, ForeColor = HotelPalette.TextPrimary };
            
            currentX += 250 + 20;

            RoundedButton btnAdd = new RoundedButton { Text = "Add Staff", BackColor = HotelPalette.Accent, ForeColor = HotelPalette.TextPrimary, Size = new Size(130, 35), Location = new Point(currentX, 12), BorderRadius = 15, Font = new Font("Segoe UI", 10) };

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

            pnlUserView.Controls.Add(pnlContent);
            pnlUserView.Controls.Add(pnlFilter);
            pnlUserView.Controls.Add(pnlHeader);
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
    }
}
