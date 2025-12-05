using static HotelApplication.Components.RoundedCorners;

namespace HotelApplication.Forms.Dashboard
{
    public partial class Settings : UserControl
    {
        private Label lblTitle;
        public Settings()
        {
            InitializeComponent();
            SetupManualUI();
            LoadMockData();
        }
        private void SetupManualUI()
        {
            this.Size = new Size(800, 600);
            this.BackColor = Color.FromArgb(34, 40, 49);
            // 1. Header Area
            lblTitle = new Label();
            lblTitle.Text = "Settings Management";
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.ForeColor = HotelPalette.TextPrimary;
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;

            // Add controls to UserControl
            this.Controls.Add(lblTitle);
        }
        private void LoadMockData()
        {
            // Load any mock data if necessary
        }
    }
}
