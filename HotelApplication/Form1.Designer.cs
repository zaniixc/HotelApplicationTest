namespace HotelApplication
{
    partial class LoginFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            exitBtn = new HotelApplication.Components.RoundedButton();
            minimizeBtn = new HotelApplication.Components.RoundedButton();
            userTextBox = new HotelApp.UI.Components.UITextBox();
            label1 = new Label();
            label2 = new Label();
            passTxtBox = new HotelApp.UI.Components.UITextBox();
            signUpLbl = new LinkLabel();
            forgotBtn = new HotelApplication.Components.RoundedButton();
            loginBtn = new HotelApplication.Components.RoundedButton();
            SuspendLayout();
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
            exitBtn.TabIndex = 1;
            exitBtn.Text = "✕";
            exitBtn.TextColor = Color.FromArgb(230, 230, 230);
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
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
            minimizeBtn.TabIndex = 2;
            minimizeBtn.Text = "–";
            minimizeBtn.TextColor = Color.FromArgb(230, 230, 230);
            minimizeBtn.UseVisualStyleBackColor = false;
            minimizeBtn.Click += minimizeBtn_Click;
            // 
            // userTextBox
            // 
            userTextBox.BackColor = Color.White;
            userTextBox.BackgroundImageLayout = ImageLayout.None;
            userTextBox.BorderColor = Color.FromArgb(60, 60, 60);
            userTextBox.BorderFocusColor = Color.FromArgb(100, 149, 237);
            userTextBox.BorderRadius = 5;
            userTextBox.Font = new Font("Segoe UI", 12F);
            userTextBox.ForeColor = Color.Black;
            userTextBox.Location = new Point(117, 100);
            userTextBox.Margin = new Padding(3, 4, 3, 4);
            userTextBox.Multiline = false;
            userTextBox.Name = "userTextBox";
            userTextBox.Padding = new Padding(11, 9, 11, 9);
            userTextBox.PasswordChar = false;
            userTextBox.PlaceholderText = "";
            userTextBox.Size = new Size(419, 47);
            userTextBox.TabIndex = 3;
            userTextBox.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(283, 55);
            label1.Name = "label1";
            label1.Size = new Size(99, 28);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(283, 152);
            label2.Name = "label2";
            label2.Size = new Size(93, 28);
            label2.TabIndex = 5;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // passTxtBox
            // 
            passTxtBox.BackColor = Color.White;
            passTxtBox.BackgroundImageLayout = ImageLayout.None;
            passTxtBox.BorderColor = Color.FromArgb(60, 60, 60);
            passTxtBox.BorderFocusColor = Color.FromArgb(100, 149, 237);
            passTxtBox.BorderRadius = 5;
            passTxtBox.Font = new Font("Segoe UI", 12F);
            passTxtBox.ForeColor = Color.Black;
            passTxtBox.Location = new Point(117, 184);
            passTxtBox.Margin = new Padding(3, 4, 3, 4);
            passTxtBox.Multiline = false;
            passTxtBox.Name = "passTxtBox";
            passTxtBox.Padding = new Padding(11, 9, 11, 9);
            passTxtBox.PasswordChar = true;
            passTxtBox.PlaceholderText = "";
            passTxtBox.Size = new Size(419, 47);
            passTxtBox.TabIndex = 6;
            passTxtBox.UnderlinedStyle = false;
            // 
            // signUpLbl
            // 
            signUpLbl.AutoSize = true;
            signUpLbl.Font = new Font("Segoe UI", 11F);
            signUpLbl.LinkColor = Color.RoyalBlue;
            signUpLbl.Location = new Point(82, 373);
            signUpLbl.Name = "signUpLbl";
            signUpLbl.Size = new Size(321, 25);
            signUpLbl.TabIndex = 7;
            signUpLbl.TabStop = true;
            signUpLbl.Text = "Don't have an account? Sign up here";
            signUpLbl.LinkClicked += linkLabel1_LinkClicked;
            // 
            // forgotBtn
            // 
            forgotBtn.BackColor = Color.FromArgb(80, 80, 80);
            forgotBtn.BackgroundColor = Color.FromArgb(80, 80, 80);
            forgotBtn.BorderColor = Color.FromArgb(60, 60, 60);
            forgotBtn.BorderRadius = 17;
            forgotBtn.BorderSize = 0;
            forgotBtn.FlatAppearance.BorderSize = 0;
            forgotBtn.FlatStyle = FlatStyle.Flat;
            forgotBtn.ForeColor = Color.White;
            forgotBtn.Location = new Point(409, 373);
            forgotBtn.Margin = new Padding(3, 4, 3, 4);
            forgotBtn.Name = "forgotBtn";
            forgotBtn.Size = new Size(171, 29);
            forgotBtn.TabIndex = 8;
            forgotBtn.Text = "Forgot password?";
            forgotBtn.TextColor = Color.White;
            forgotBtn.UseVisualStyleBackColor = false;
            forgotBtn.Click += forgotBtn_Click;
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.FromArgb(80, 80, 80);
            loginBtn.BackgroundColor = Color.FromArgb(80, 80, 80);
            loginBtn.BorderColor = Color.FromArgb(60, 60, 60);
            loginBtn.BorderRadius = 20;
            loginBtn.BorderSize = 0;
            loginBtn.FlatAppearance.BorderSize = 0;
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.ForeColor = Color.White;
            loginBtn.Location = new Point(232, 253);
            loginBtn.Margin = new Padding(3, 4, 3, 4);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(171, 53);
            loginBtn.TabIndex = 9;
            loginBtn.Text = "Login";
            loginBtn.TextColor = Color.White;
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += forgotBtn_Click;
            // 
            // LoginFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(652, 419);
            Controls.Add(loginBtn);
            Controls.Add(forgotBtn);
            Controls.Add(signUpLbl);
            Controls.Add(passTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(userTextBox);
            Controls.Add(minimizeBtn);
            Controls.Add(exitBtn);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginFrm";
            Padding = new Padding(2, 3, 2, 3);
            Text = "HotelApp";
            Load += LoginFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Components.RoundedButton exitBtn;
        private Components.RoundedButton minimizeBtn;
        private HotelApp.UI.Components.UITextBox userTextBox;
        private Label label1;
        private Label label2;
        private HotelApp.UI.Components.UITextBox passTxtBox;
        private LinkLabel signUpLbl;
        private Components.RoundedButton forgotBtn;
        private Components.RoundedButton loginBtn;
    }
}
