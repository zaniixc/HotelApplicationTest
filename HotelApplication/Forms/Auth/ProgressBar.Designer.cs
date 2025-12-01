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
            uiProgressBar1 = new HotelApp.UI.Components.UIProgressBar();
            label3 = new Label();
            SuspendLayout();
            // 
            // uiProgressBar1
            // 
            uiProgressBar1.BackColor = Color.FromArgb(20, 20, 20);
            uiProgressBar1.ChannelColor = Color.FromArgb(32, 32, 32);
            uiProgressBar1.ForeColor = Color.FromArgb(230, 230, 230);
            uiProgressBar1.Location = new Point(99, 105);
            uiProgressBar1.Margin = new Padding(3, 4, 3, 4);
            uiProgressBar1.Maximum = 100;
            uiProgressBar1.Name = "uiProgressBar1";
            uiProgressBar1.ShowValue = false;
            uiProgressBar1.Size = new Size(457, 36);
            uiProgressBar1.SliderColor = Color.FromArgb(100, 149, 237);
            uiProgressBar1.TabIndex = 0;
            uiProgressBar1.Text = "uiProgressBar1";
            uiProgressBar1.Value = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(288, 150);
            label3.Name = "label3";
            label3.Size = new Size(88, 37);
            label3.TabIndex = 4;
            label3.Text = "Status";
            // 
            // ProgressBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(655, 260);
            Controls.Add(label3);
            Controls.Add(uiProgressBar1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProgressBar";
            Padding = new Padding(2, 3, 2, 3);
            Text = "ProgressBar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private HotelApp.UI.Components.UIProgressBar uiProgressBar1;
        private Label label3;
    }
}