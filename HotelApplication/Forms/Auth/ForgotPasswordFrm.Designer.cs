namespace HotelApplication.Forms.Auth
{
    partial class ForgotPasswordFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblInstruction;
        private HotelApp.UI.Components.UITextBox txtRecoveryEmail;
        private HotelApplication.Components.RoundedButton btnSendReset;
        private HotelApplication.Components.RoundedButton btnCancel;

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
            lblHeader = new Label();
            lblInstruction = new Label();
            txtRecoveryEmail = new HotelApp.UI.Components.UITextBox();
            btnSendReset = new HotelApplication.Components.RoundedButton();
            btnCancel = new HotelApplication.Components.RoundedButton();
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
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(200, 50);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(286, 41);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Password Recovery";
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.ForeColor = Color.Gray;
            lblInstruction.Location = new Point(120, 110);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(301, 20);
            lblInstruction.TabIndex = 1;
            lblInstruction.Text = "Enter your username to reset your password.";
            // 
            // txtRecoveryEmail
            // 
            txtRecoveryEmail.BackColor = Color.White;
            txtRecoveryEmail.BorderColor = Color.FromArgb(60, 60, 60);
            txtRecoveryEmail.BorderFocusColor = Color.FromArgb(100, 149, 237);
            txtRecoveryEmail.BorderRadius = 5;
            txtRecoveryEmail.Font = new Font("Segoe UI", 12F);
            txtRecoveryEmail.ForeColor = Color.Black;
            txtRecoveryEmail.Location = new Point(117, 140);
            txtRecoveryEmail.Margin = new Padding(3, 4, 3, 4);
            txtRecoveryEmail.Multiline = false;
            txtRecoveryEmail.Name = "txtRecoveryEmail";
            txtRecoveryEmail.Padding = new Padding(11, 9, 11, 9);
            txtRecoveryEmail.PasswordChar = false;
            txtRecoveryEmail.PlaceholderText = "Enter Username";
            txtRecoveryEmail.Size = new Size(419, 47);
            txtRecoveryEmail.TabIndex = 6;
            txtRecoveryEmail.UnderlinedStyle = false;
            // 
            // btnSendReset
            // 
            btnSendReset.BackColor = Color.SeaGreen;
            btnSendReset.BackgroundColor = Color.SeaGreen;
            btnSendReset.BorderColor = Color.FromArgb(60, 60, 60);
            btnSendReset.BorderRadius = 15;
            btnSendReset.BorderSize = 0;
            btnSendReset.FlatStyle = FlatStyle.Flat;
            btnSendReset.ForeColor = Color.White;
            btnSendReset.Location = new Point(117, 203);
            btnSendReset.Margin = new Padding(3, 4, 3, 4);
            btnSendReset.Name = "btnSendReset";
            btnSendReset.Size = new Size(419, 53);
            btnSendReset.TabIndex = 3;
            btnSendReset.Text = "Reset Password";
            btnSendReset.TextColor = Color.White;
            btnSendReset.UseVisualStyleBackColor = false;
            btnSendReset.Click += btnSendReset_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(60, 60, 60);
            btnCancel.BackgroundColor = Color.FromArgb(60, 60, 60);
            btnCancel.BorderColor = Color.FromArgb(60, 60, 60);
            btnCancel.BorderRadius = 15;
            btnCancel.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(232, 273);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(171, 40);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = Color.White;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ForgorPasswordFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(652, 419);
            Controls.Add(lblHeader);
            Controls.Add(lblInstruction);
            Controls.Add(txtRecoveryEmail);
            Controls.Add(btnSendReset);
            Controls.Add(btnCancel);
            Controls.Add(exitBtn);
            Controls.Add(minimizeBtn);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ForgorPasswordFrm";
            Padding = new Padding(2, 3, 2, 3);
            Text = "RegisterFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Components.RoundedButton minimizeBtn;
        private Components.RoundedButton exitBtn;
    }
}