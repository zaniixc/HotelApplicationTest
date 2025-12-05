using HotelApplication.Components;
using HotelApplication.Forms.Dashboard;
using HotelApplication.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApplication.Forms.Auth
{
    public partial class ProgressBar : RoundedCorners
    {
        private System.Windows.Forms.Timer loadingTimer;

        private int currentProgress = 0;
        private string[] loadSteps = {
            "Initializing Core Components...",
            "Connecting to Mock Database...",
            "Loading Configuration...",
            "Verifying Secure Session...",
            "Starting Application..."
        };

        public ProgressBar()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitializeCustomLogic();
        }

        private void InitializeCustomLogic()
        {
            loadingTimer = new System.Windows.Forms.Timer();
            loadingTimer.Interval = 30; // Slightly faster for testing
            loadingTimer.Tick += LoadingTimer_Tick;
            loadingTimer.Start();
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            currentProgress += 1;

            if (uiProgressBar != null)
                uiProgressBar.Value = currentProgress;

            if (statusLbl != null)
            {
                int stepIndex = (currentProgress / 20);
                if (stepIndex < loadSteps.Length)
                    statusLbl.Text = loadSteps[stepIndex];
            }

            if (currentProgress >= 100)
            {
                loadingTimer.Stop();
                PerformNavigation();
            }
        }

        private void PerformNavigation()
        {
            this.Hide();

            // --- REAL IMPLEMENTATION ---
            // Try to decrypt the session file and auto-login
            bool sessionRestored = SessionManager.TryAutoLogin();

            if (sessionRestored && SessionManager.IsLoggedIn)
            {
                // Session found! Go to Dashboard
                FrmMainDashboard dashboard = new FrmMainDashboard();
                dashboard.Show();
            }
            else
            {
                // No valid session found, go to Login
                LoginFrm login = new LoginFrm();
                login.Show();
            }
        }
    }
}
