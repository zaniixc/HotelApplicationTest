namespace HotelApplication.Forms.Dashboard
{
    partial class FrmMainDashboard
    {
        private System.ComponentModel.IContainer components = null;

        // UI Controls (Made accessible for logic)
        public System.Windows.Forms.Panel leftPanel;
        public System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel cardSales;
        private System.Windows.Forms.Panel cardUsers;
        private System.Windows.Forms.Label lblTotalSalesTitle;
        private System.Windows.Forms.Label lblTotalSalesValue;
        private System.Windows.Forms.Label lblNewUsersTitle;
        private System.Windows.Forms.Label lblNewUsersValue;
        private HotelApplication.Components.RoundedButton btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            leftPanel = new Panel();
            btnLogout = new HotelApplication.Components.RoundedButton();
            lblTitle = new Label();
            topPanel = new Panel();
            contentPanel = new Panel();
            cardSales = new Panel();
            lblTotalSalesTitle = new Label();
            lblTotalSalesValue = new Label();
            cardUsers = new Panel();
            lblNewUsersTitle = new Label();
            lblNewUsersValue = new Label();
            leftPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(32, 32, 32);
            leftPanel.Controls.Add(btnLogout);
            leftPanel.Controls.Add(lblTitle);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(2, 2);
            leftPanel.Margin = new Padding(3, 4, 3, 4);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(14, 16, 14, 16);
            leftPanel.Size = new Size(183, 956);
            leftPanel.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.FromArgb(64, 64, 64);
            btnLogout.BackgroundColor = Color.FromArgb(64, 64, 64);
            btnLogout.BorderColor = Color.FromArgb(60, 60, 60);
            btnLogout.BorderRadius = 20;
            btnLogout.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(14, 862);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(137, 48);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.TextColor = Color.White;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(114, 31);
            lblTitle.TabIndex = 4;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(32, 32, 32);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(185, 2);
            topPanel.Margin = new Padding(3, 4, 3, 4);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1276, 85);
            topPanel.TabIndex = 1;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(32, 32, 32);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(185, 87);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(21, 24, 21, 24);
            contentPanel.Size = new Size(1276, 871);
            contentPanel.TabIndex = 0;
            // 
            // cardSales
            // 
            cardSales.Location = new Point(0, 0);
            cardSales.Name = "cardSales";
            cardSales.Size = new Size(200, 100);
            cardSales.TabIndex = 0;
            // 
            // lblTotalSalesTitle
            // 
            lblTotalSalesTitle.Location = new Point(0, 0);
            lblTotalSalesTitle.Name = "lblTotalSalesTitle";
            lblTotalSalesTitle.Size = new Size(100, 23);
            lblTotalSalesTitle.TabIndex = 0;
            // 
            // lblTotalSalesValue
            // 
            lblTotalSalesValue.Location = new Point(0, 0);
            lblTotalSalesValue.Name = "lblTotalSalesValue";
            lblTotalSalesValue.Size = new Size(100, 23);
            lblTotalSalesValue.TabIndex = 0;
            // 
            // cardUsers
            // 
            cardUsers.Location = new Point(0, 0);
            cardUsers.Name = "cardUsers";
            cardUsers.Size = new Size(200, 100);
            cardUsers.TabIndex = 0;
            // 
            // lblNewUsersTitle
            // 
            lblNewUsersTitle.Location = new Point(0, 0);
            lblNewUsersTitle.Name = "lblNewUsersTitle";
            lblNewUsersTitle.Size = new Size(100, 23);
            lblNewUsersTitle.TabIndex = 0;
            // 
            // lblNewUsersValue
            // 
            lblNewUsersValue.Location = new Point(0, 0);
            lblNewUsersValue.Name = "lblNewUsersValue";
            lblNewUsersValue.Size = new Size(100, 23);
            lblNewUsersValue.TabIndex = 0;
            // 
            // FrmMainDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            BorderColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1463, 960);
            Controls.Add(contentPanel);
            Controls.Add(topPanel);
            Controls.Add(leftPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMainDashboard";
            Text = "Grand Horizon Dashboard";
            Load += FrmMainDashboard_Load;
            leftPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion
        #endregion
    }
}