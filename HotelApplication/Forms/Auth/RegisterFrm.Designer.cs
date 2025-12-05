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
            minimizeBtn = new HotelApplication.Components.RoundedButton();
            exitBtn = new HotelApplication.Components.RoundedButton();
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
            // RegisterFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(652, 419);
            Controls.Add(exitBtn);
            Controls.Add(minimizeBtn);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RegisterFrm";
            Padding = new Padding(2, 3, 2, 3);
            Text = "RegisterFrm";
            ResumeLayout(false);
        }

        #endregion

        private Components.RoundedButton minimizeBtn;
        private Components.RoundedButton exitBtn;
    }
}