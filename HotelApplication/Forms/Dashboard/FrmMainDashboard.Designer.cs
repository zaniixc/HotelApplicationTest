using System.Drawing;
using HotelApplication.Components;
using HotelApp.UI.Components;

namespace HotelApplication.Forms.Dashboard
{
    partial class FrmMainDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel contentPanel;
        private HotelApplication.Components.RoundedButton btnDashboard;
        private HotelApplication.Components.RoundedButton btnUsers;
        private HotelApplication.Components.RoundedButton btnSettings;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Panel cardSales;
        private System.Windows.Forms.Panel cardUsers;
        private System.Windows.Forms.Label lblTotalSalesTitle;
        private System.Windows.Forms.Label lblTotalSalesValue;
        private System.Windows.Forms.Label lblNewUsersTitle;
        private System.Windows.Forms.Label lblNewUsersValue;
        private HotelApplication.Components.RoundedButton btnLogout;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTest = new Panel();
            leftPanel = new Panel();
            btnLogout = new RoundedButton();
            btnSettings = new RoundedButton();
            btnUsers = new RoundedButton();
            btnDashboard = new RoundedButton();
            lblTitle = new Label();
            topPanel = new Panel();
            contentPanel = new Panel();
            cardPanel = new Panel();
            cardSales = new Panel();
            lblTotalSalesTitle = new Label();
            lblTotalSalesValue = new Label();
            cardUsers = new Panel();
            lblNewUsersTitle = new Label();
            lblNewUsersValue = new Label();
            leftPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            cardPanel.SuspendLayout();
            cardSales.SuspendLayout();
            cardUsers.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTest
            // 
            pnlTest.BackColor = Color.FromArgb(34, 40, 49);
            pnlTest.BorderStyle = BorderStyle.FixedSingle;
            pnlTest.ForeColor = Color.FromArgb(32, 32, 32);
            pnlTest.Location = new Point(18, 138);
            pnlTest.Name = "pnlTest";
            pnlTest.Size = new Size(1095, 498);
            pnlTest.TabIndex = 1;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(34, 40, 49);
            leftPanel.Controls.Add(btnLogout);
            leftPanel.Controls.Add(btnSettings);
            leftPanel.Controls.Add(btnUsers);
            leftPanel.Controls.Add(btnDashboard);
            leftPanel.Controls.Add(lblTitle);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(2, 2);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(12);
            leftPanel.Size = new Size(145, 716);
            leftPanel.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(57, 62, 70);
            btnLogout.BackgroundColor = Color.FromArgb(57, 62, 70);
            btnLogout.BorderRadius = 10;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.FromArgb(238, 238, 238);
            btnLogout.Location = new Point(12, 520);
            btnLogout.Name = "btnLogout";
            btnLogout.PressColor = Color.FromArgb(0, 173, 181);
            btnLogout.Size = new Size(122, 36);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.TextColor = Color.FromArgb(238, 238, 238);
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(57, 62, 70);
            btnSettings.BackgroundColor = Color.FromArgb(57, 62, 70);
            btnSettings.BorderRadius = 10;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.FromArgb(238, 238, 238);
            btnSettings.Location = new Point(12, 160);
            btnSettings.Name = "btnSettings";
            btnSettings.PressColor = Color.FromArgb(0, 173, 181);
            btnSettings.Size = new Size(122, 36);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "Settings";
            btnSettings.TextColor = Color.FromArgb(238, 238, 238);
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.FromArgb(57, 62, 70);
            btnUsers.BackgroundColor = Color.FromArgb(57, 62, 70);
            btnUsers.BorderRadius = 10;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.ForeColor = Color.FromArgb(238, 238, 238);
            btnUsers.Location = new Point(12, 108);
            btnUsers.Name = "btnUsers";
            btnUsers.PressColor = Color.FromArgb(0, 173, 181);
            btnUsers.Size = new Size(122, 36);
            btnUsers.TabIndex = 2;
            btnUsers.Text = "Users";
            btnUsers.TextColor = Color.FromArgb(238, 238, 238);
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(57, 62, 70);
            btnDashboard.BackgroundColor = Color.FromArgb(57, 62, 70);
            btnDashboard.BorderRadius = 10;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.FromArgb(238, 238, 238);
            btnDashboard.Location = new Point(12, 56);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.PressColor = Color.FromArgb(0, 173, 181);
            btnDashboard.Size = new Size(122, 36);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextColor = Color.FromArgb(238, 238, 238);
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(238, 238, 238);
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(106, 32);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "TestApp";
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(34, 40, 49);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(147, 2);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(12);
            topPanel.Size = new Size(1131, 64);
            topPanel.TabIndex = 1;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(34, 40, 49);
            contentPanel.Controls.Add(cardPanel);
            contentPanel.Controls.Add(pnlTest);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(147, 66);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(18);
            contentPanel.Size = new Size(1131, 652);
            contentPanel.TabIndex = 0;
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.FromArgb(34, 40, 49);
            cardPanel.Controls.Add(cardSales);
            cardPanel.Controls.Add(cardUsers);
            cardPanel.Dock = DockStyle.Top;
            cardPanel.Location = new Point(18, 18);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(6);
            cardPanel.Size = new Size(1095, 120);
            cardPanel.TabIndex = 1;
            // 
            // cardSales
            // 
            cardSales.BackColor = Color.FromArgb(34, 40, 49);
            cardSales.BorderStyle = BorderStyle.FixedSingle;
            cardSales.Controls.Add(lblTotalSalesTitle);
            cardSales.Controls.Add(lblTotalSalesValue);
            cardSales.Location = new Point(0, 12);
            cardSales.Name = "cardSales";
            cardSales.Size = new Size(420, 100);
            cardSales.TabIndex = 0;
            // 
            // lblTotalSalesTitle
            // 
            lblTotalSalesTitle.ForeColor = Color.FromArgb(160, 160, 160);
            lblTotalSalesTitle.Location = new Point(12, 12);
            lblTotalSalesTitle.Name = "lblTotalSalesTitle";
            lblTotalSalesTitle.Size = new Size(100, 23);
            lblTotalSalesTitle.TabIndex = 0;
            lblTotalSalesTitle.Text = "Total Sales";
            // 
            // lblTotalSalesValue
            // 
            lblTotalSalesValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalSalesValue.ForeColor = Color.FromArgb(230, 230, 230);
            lblTotalSalesValue.Location = new Point(12, 40);
            lblTotalSalesValue.Name = "lblTotalSalesValue";
            lblTotalSalesValue.Size = new Size(395, 45);
            lblTotalSalesValue.TabIndex = 1;
            lblTotalSalesValue.Text = "₱0";
            // 
            // cardUsers
            // 
            cardUsers.BackColor = Color.FromArgb(34, 40, 49);
            cardUsers.BorderStyle = BorderStyle.FixedSingle;
            cardUsers.Controls.Add(lblNewUsersTitle);
            cardUsers.Controls.Add(lblNewUsersValue);
            cardUsers.ForeColor = SystemColors.ControlText;
            cardUsers.Location = new Point(428, 12);
            cardUsers.Name = "cardUsers";
            cardUsers.Size = new Size(200, 100);
            cardUsers.TabIndex = 1;
            // 
            // lblNewUsersTitle
            // 
            lblNewUsersTitle.ForeColor = Color.FromArgb(160, 160, 160);
            lblNewUsersTitle.Location = new Point(12, 12);
            lblNewUsersTitle.Name = "lblNewUsersTitle";
            lblNewUsersTitle.Size = new Size(100, 23);
            lblNewUsersTitle.TabIndex = 0;
            lblNewUsersTitle.Text = "New Users";
            // 
            // lblNewUsersValue
            // 
            lblNewUsersValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblNewUsersValue.ForeColor = Color.FromArgb(230, 230, 230);
            lblNewUsersValue.Location = new Point(12, 40);
            lblNewUsersValue.Name = "lblNewUsersValue";
            lblNewUsersValue.Size = new Size(175, 45);
            lblNewUsersValue.TabIndex = 1;
            lblNewUsersValue.Text = "0";
            // 
            // FrmMainDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderColor = Color.Black;
            BorderSize = 1;
            ClientSize = new Size(1280, 720);
            Controls.Add(contentPanel);
            Controls.Add(topPanel);
            Controls.Add(leftPanel);
            Name = "FrmMainDashboard";
            Text = "FrmMainDashboard";
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardSales.ResumeLayout(false);
            cardUsers.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTest;
    }
}