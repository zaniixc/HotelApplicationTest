namespace HotelApplication.Forms.Auth
{
    partial class ProgressBar
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
            uiProgressBar = new HotelApp.UI.Components.UIProgressBar();
            statusLbl = new Label();
            SuspendLayout();
            // 
            // uiProgressBar
            // 
            uiProgressBar.BackColor = Color.FromArgb(20, 20, 20);
            uiProgressBar.ChannelColor = Color.FromArgb(32, 32, 32);
            uiProgressBar.ForeColor = Color.FromArgb(230, 230, 230);
            uiProgressBar.Location = new Point(97, 105);
            uiProgressBar.Margin = new Padding(3, 4, 3, 4);
            uiProgressBar.Maximum = 100;
            uiProgressBar.Name = "uiProgressBar";
            uiProgressBar.ShowValue = false;
            uiProgressBar.Size = new Size(454, 36);
            uiProgressBar.SliderColor = Color.FromArgb(100, 149, 237);
            uiProgressBar.TabIndex = 0;
            uiProgressBar.Text = "uiProgressBar1";
            uiProgressBar.Value = 0;
            // 
            // statusLbl
            // 
            statusLbl.AutoSize = true;
            statusLbl.Font = new Font("Segoe UI", 16F);
            statusLbl.ForeColor = Color.White;
            statusLbl.Location = new Point(126, 150);
            statusLbl.Name = "statusLbl";
            statusLbl.Size = new Size(88, 37);
            statusLbl.TabIndex = 1;
            statusLbl.Text = "Status";
            // 
            // ProgressBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(654, 260);
            Controls.Add(statusLbl);
            Controls.Add(uiProgressBar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProgressBar";
            Padding = new Padding(2, 3, 2, 3);
            Text = "ProgressBar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private HotelApp.UI.Components.UIProgressBar uiProgressBar;
        private Label statusLbl;
    }
}