namespace HotelApplication.Forms.Auth
{
    partial class RegisterFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            label1 = new Label();
            label2 = new Label();
            txt_Username = new HotelApp.UI.Components.UITextBox();
            txt_Password = new HotelApp.UI.Components.UITextBox();
            returnToLogInLbl = new LinkLabel();
            btnRegister = new HotelApplication.Components.RoundedButton();
            exitBtn = new HotelApplication.Components.RoundedButton();
            minimizeBtn = new HotelApplication.Components.RoundedButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.FromArgb(238, 238, 238);
            label1.Location = new Point(278, 154);
            label1.Name = "label1";
            label1.Size = new Size(93, 28);
            label1.TabIndex = 5;
            label1.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.FromArgb(238, 238, 238);
            label2.Location = new Point(275, 70);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 6;
            label2.Text = "Username";
            // 
            // txt_Username
            // 
            txt_Username.BackColor = Color.FromArgb(57, 62, 70);
            txt_Username.BorderColor = Color.FromArgb(60, 60, 60);
            txt_Username.BorderFocusColor = Color.FromArgb(100, 149, 237);
            txt_Username.BorderRadius = 10;
            txt_Username.ForeColor = Color.White;
            txt_Username.Location = new Point(117, 100);
            txt_Username.Multiline = false;
            txt_Username.Name = "txt_Username";
            txt_Username.Padding = new Padding(10, 7, 10, 7);
            txt_Username.PasswordChar = false;
            txt_Username.PlaceholderText = "Username...";
            txt_Username.Size = new Size(419, 36);
            txt_Username.TabIndex = 11;
            txt_Username.UnderlinedStyle = false;
            // 
            // txt_Password
            // 
            txt_Password.BackColor = Color.FromArgb(57, 62, 70);
            txt_Password.BorderColor = Color.FromArgb(60, 60, 60);
            txt_Password.BorderFocusColor = Color.FromArgb(100, 149, 237);
            txt_Password.BorderRadius = 10;
            txt_Password.ForeColor = Color.White;
            txt_Password.Location = new Point(115, 191);
            txt_Password.Multiline = false;
            txt_Password.Name = "txt_Password";
            txt_Password.Padding = new Padding(10, 7, 10, 7);
            txt_Password.PasswordChar = true;
            txt_Password.PlaceholderText = "Password...";
            txt_Password.Size = new Size(419, 36);
            txt_Password.TabIndex = 12;
            txt_Password.UnderlinedStyle = false;
            // 
            // returnToLogInLbl
            // 
            returnToLogInLbl.ActiveLinkColor = Color.RoyalBlue;
            returnToLogInLbl.AutoSize = true;
            returnToLogInLbl.Font = new Font("Segoe UI", 11F);
            returnToLogInLbl.LinkColor = Color.CornflowerBlue;
            returnToLogInLbl.Location = new Point(252, 373);
            returnToLogInLbl.Name = "returnToLogInLbl";
            returnToLogInLbl.Size = new Size(145, 25);
            returnToLogInLbl.TabIndex = 13;
            returnToLogInLbl.TabStop = true;
            returnToLogInLbl.Text = "Return to Login.";
            returnToLogInLbl.LinkClicked += returnToLogInLbl_LinkClicked;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 173, 181);
            btnRegister.BackgroundColor = Color.FromArgb(0, 173, 181);
            btnRegister.BorderRadius = 10;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(262, 275);
            btnRegister.Name = "btnRegister";
            btnRegister.PressColor = Color.FromArgb(100, 100, 100);
            btnRegister.Size = new Size(122, 50);
            btnRegister.TabIndex = 14;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.FromArgb(34, 40, 49);
            exitBtn.BackgroundColor = Color.FromArgb(34, 40, 49);
            exitBtn.BorderRadius = 0;
            exitBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            exitBtn.ForeColor = Color.White;
            exitBtn.Location = new Point(609, 7);
            exitBtn.Margin = new Padding(3, 4, 3, 4);
            exitBtn.Name = "exitBtn";
            exitBtn.PressColor = Color.FromArgb(100, 100, 100);
            exitBtn.Size = new Size(32, 32);
            exitBtn.TabIndex = 2;
            exitBtn.Text = "X";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // minimizeBtn
            // 
            minimizeBtn.BackColor = Color.FromArgb(34, 40, 49);
            minimizeBtn.BackgroundColor = Color.FromArgb(34, 40, 49);
            minimizeBtn.BorderRadius = 0;
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatStyle = FlatStyle.Flat;
            minimizeBtn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            minimizeBtn.ForeColor = Color.White;
            minimizeBtn.Location = new Point(570, 7);
            minimizeBtn.Margin = new Padding(3, 4, 3, 4);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.PressColor = Color.FromArgb(100, 100, 100);
            minimizeBtn.Size = new Size(32, 32);
            minimizeBtn.TabIndex = 2;
            minimizeBtn.Text = "──";
            minimizeBtn.UseVisualStyleBackColor = false;
            minimizeBtn.Click += minimizeBtn_Click;
            // 
            // RegisterFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 40, 49);
            BorderColor = Color.Black;
            BorderSize = 1;
            ClientSize = new Size(649, 419);
            Controls.Add(minimizeBtn);
            Controls.Add(exitBtn);
            Controls.Add(btnRegister);
            Controls.Add(returnToLogInLbl);
            Controls.Add(txt_Password);
            Controls.Add(txt_Username);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RegisterFrm";
            Padding = new Padding(2, 3, 2, 3);
            Text = "RegisterFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private HotelApp.UI.Components.UITextBox txt_Username;
        private HotelApp.UI.Components.UITextBox txt_Password;
        private LinkLabel returnToLogInLbl;
        private Components.RoundedButton btnRegister;
        private Components.RoundedButton exitBtn;
        private Components.RoundedButton minimizeBtn;
    }
}