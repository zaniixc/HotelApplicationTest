namespace HotelApplication.Forms.Auth
{
    partial class RegisterFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private HotelApp.UI.Components.UITextBox txtRegUser;
        private System.Windows.Forms.Label lblPass;
        private HotelApp.UI.Components.UITextBox txtRegPass;
        private System.Windows.Forms.Label lblConfirm;
        private HotelApplication.Components.RoundedButton btnRegister;
        private System.Windows.Forms.LinkLabel linkBackToLogin;

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
            minimizeBtn = new HotelApplication.Components.RoundedButton();
            exitBtn = new HotelApplication.Components.RoundedButton();
            lblTitle = new Label();
            lblUser = new Label();
            txtRegUser = new HotelApp.UI.Components.UITextBox();
            lblPass = new Label();
            txtRegPass = new HotelApp.UI.Components.UITextBox();
            lblConfirm = new Label();
            btnRegister = new HotelApplication.Components.RoundedButton();
            linkBackToLogin = new LinkLabel();
            txtRegConfirm = new HotelApp.UI.Components.UITextBox();
            SuspendLayout();
            // 
            // minimizeBtn
            // 
            minimizeBtn.BackColor = Color.FromArgb(32, 32, 32);
            minimizeBtn.BackgroundColor = Color.FromArgb(32, 32, 32);
            minimizeBtn.BorderColor = Color.FromArgb(60, 60, 60);
            minimizeBtn.BorderRadius = 10;
            minimizeBtn.BorderSize = 1;
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatStyle = FlatStyle.Flat;
            minimizeBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            minimizeBtn.ForeColor = Color.FromArgb(230, 230, 230);
            minimizeBtn.Location = new Point(566, 11);
            minimizeBtn.Margin = new Padding(3, 4, 3, 4);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.Size = new Size(37, 43);
            minimizeBtn.TabIndex = 3;
            minimizeBtn.Text = "–";
            minimizeBtn.TextColor = Color.FromArgb(230, 230, 230);
            minimizeBtn.UseVisualStyleBackColor = false;
            minimizeBtn.Click += minimizeBtn_Click;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.FromArgb(32, 32, 32);
            exitBtn.BackgroundColor = Color.FromArgb(32, 32, 32);
            exitBtn.BorderColor = Color.FromArgb(60, 60, 60);
            exitBtn.BorderRadius = 10;
            exitBtn.BorderSize = 1;
            exitBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.Font = new Font("Segoe UI", 11F);
            exitBtn.ForeColor = Color.FromArgb(230, 230, 230);
            exitBtn.Location = new Point(609, 11);
            exitBtn.Margin = new Padding(3, 4, 3, 4);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(37, 43);
            exitBtn.TabIndex = 4;
            exitBtn.Text = "✕";
            exitBtn.TextColor = Color.FromArgb(230, 230, 230);
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(249, 55);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(145, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Account";
            // 
            // lblUser
            // 
            lblUser.Location = new Point(0, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(100, 23);
            lblUser.TabIndex = 0;
            // 
            // txtRegUser
            // 
            txtRegUser.BackColor = Color.White;
            txtRegUser.BorderColor = Color.FromArgb(60, 60, 60);
            txtRegUser.BorderFocusColor = Color.FromArgb(100, 149, 237);
            txtRegUser.BorderRadius = 5;
            txtRegUser.Font = new Font("Segoe UI", 12F);
            txtRegUser.ForeColor = Color.Black;
            txtRegUser.Location = new Point(117, 90);
            txtRegUser.Margin = new Padding(3, 4, 3, 4);
            txtRegUser.Multiline = false;
            txtRegUser.Name = "txtRegUser";
            txtRegUser.Padding = new Padding(11, 9, 11, 9);
            txtRegUser.PasswordChar = false;
            txtRegUser.PlaceholderText = "Username";
            txtRegUser.Size = new Size(419, 47);
            txtRegUser.TabIndex = 3;
            txtRegUser.UnderlinedStyle = false;
            // 
            // lblPass
            // 
            lblPass.Location = new Point(0, 0);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(100, 23);
            lblPass.TabIndex = 0;
            // 
            // txtRegPass
            // 
            txtRegPass.BackColor = Color.White;
            txtRegPass.BorderColor = Color.FromArgb(60, 60, 60);
            txtRegPass.BorderFocusColor = Color.FromArgb(100, 149, 237);
            txtRegPass.BorderRadius = 5;
            txtRegPass.Font = new Font("Segoe UI", 12F);
            txtRegPass.ForeColor = Color.Black;
            txtRegPass.Location = new Point(117, 154);
            txtRegPass.Margin = new Padding(3, 4, 3, 4);
            txtRegPass.Multiline = false;
            txtRegPass.Name = "txtRegPass";
            txtRegPass.Padding = new Padding(11, 9, 11, 9);
            txtRegPass.PasswordChar = true;
            txtRegPass.PlaceholderText = "Password";
            txtRegPass.Size = new Size(419, 47);
            txtRegPass.TabIndex = 6;
            txtRegPass.UnderlinedStyle = false;
            // 
            // lblConfirm
            // 
            lblConfirm.Location = new Point(0, 0);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(100, 23);
            lblConfirm.TabIndex = 0;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.RoyalBlue;
            btnRegister.BackgroundColor = Color.RoyalBlue;
            btnRegister.BorderColor = Color.FromArgb(60, 60, 60);
            btnRegister.BorderRadius = 20;
            btnRegister.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(232, 282);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(171, 53);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Register";
            btnRegister.TextColor = Color.White;
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // linkBackToLogin
            // 
            linkBackToLogin.AutoSize = true;
            linkBackToLogin.Font = new Font("Segoe UI", 11F);
            linkBackToLogin.LinkColor = Color.RoyalBlue;
            linkBackToLogin.Location = new Point(260, 370);
            linkBackToLogin.Name = "linkBackToLogin";
            linkBackToLogin.Size = new Size(125, 25);
            linkBackToLogin.TabIndex = 7;
            linkBackToLogin.TabStop = true;
            linkBackToLogin.Text = "Back to Login";
            linkBackToLogin.LinkClicked += linkBackToLogin_LinkClicked;
            // 
            // txtRegConfirm
            // 
            txtRegConfirm.BackColor = Color.White;
            txtRegConfirm.BorderColor = Color.FromArgb(60, 60, 60);
            txtRegConfirm.BorderFocusColor = Color.FromArgb(100, 149, 237);
            txtRegConfirm.BorderRadius = 5;
            txtRegConfirm.Font = new Font("Segoe UI", 12F);
            txtRegConfirm.ForeColor = Color.Black;
            txtRegConfirm.Location = new Point(117, 218);
            txtRegConfirm.Margin = new Padding(3, 4, 3, 4);
            txtRegConfirm.Multiline = false;
            txtRegConfirm.Name = "txtRegConfirm";
            txtRegConfirm.Padding = new Padding(11, 9, 11, 9);
            txtRegConfirm.PasswordChar = true;
            txtRegConfirm.PlaceholderText = "Password";
            txtRegConfirm.Size = new Size(419, 47);
            txtRegConfirm.TabIndex = 10;
            txtRegConfirm.UnderlinedStyle = false;
            // 
            // RegisterFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(652, 419);
            Controls.Add(txtRegConfirm);
            Controls.Add(lblTitle);
            Controls.Add(txtRegUser);
            Controls.Add(txtRegPass);
            Controls.Add(btnRegister);
            Controls.Add(linkBackToLogin);
            Controls.Add(exitBtn);
            Controls.Add(minimizeBtn);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RegisterFrm";
            Padding = new Padding(2, 3, 2, 3);
            Text = "RegisterFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Components.RoundedButton minimizeBtn;
        private Components.RoundedButton exitBtn;
        private HotelApp.UI.Components.UITextBox txtRegConfirm;
    }
}