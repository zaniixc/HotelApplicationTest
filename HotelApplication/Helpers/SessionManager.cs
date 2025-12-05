using HotelApp.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelApplication.Helpers
{
    public static class SessionManager
    {

        public static UserData CurrentUser { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;

        // --- CONFIGURATION ---
        private static readonly string SessionFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hotel_session.dat");

        // A hardcoded key for AES encryption (In production, use a more secure key storage)
        private static readonly string EncryptionKey = "HotelApp_Secret_Key_2024_Secure!";

        // --- MAIN METHODS ---

        public static void Login(UserData user, bool rememberMe = true)
        {
            CurrentUser = user;
            if (rememberMe)
            {
                SaveEncryptedSession(user.Username);
            }
        }

        public static void Logout()
        {
            CurrentUser = null;
            if (File.Exists(SessionFilePath))
            {
                File.Delete(SessionFilePath);
            }
        }

        // Tries to load the file, decrypt it, and log the user in automatically
        public static bool TryAutoLogin()
        {
            if (!File.Exists(SessionFilePath)) return false;

            try
            {
                string decryptedData = DecryptFile(SessionFilePath);

                // Format: "username|expiry_ticks"
                string[] parts = decryptedData.Split('|');
                if (parts.Length != 2) return false;

                string username = parts[0];
                long expiryTicks = long.Parse(parts[1]);

                // Check Expiry (e.g., session lasts 24 hours)
                if (DateTime.Now.Ticks > expiryTicks)
                {
                    Logout(); // Session expired
                    return false;
                }

                // Verify user still exists in our "Database"
                UserData user = MockDataManager.GetUser(username);
                if (user != null)
                {
                    CurrentUser = user; // Auto-login success
                    return true;
                }
            }
            catch
            {
                // If file is corrupted or tampered with, delete it
                Logout();
            }

            return false;
        }

        // --- ENCRYPTION HELPERS (The "Custom File" Logic) ---

        private static void SaveEncryptedSession(string username)
        {
            // Create data: Username + Expiry (24 hours from now)
            string dataToSave = $"{username}|{DateTime.Now.AddHours(24).Ticks}";

            EncryptToFile(dataToSave, SessionFilePath);
        }

        private static void EncryptToFile(string text, string filePath)
        {
            byte[] key = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 32)); // AES-256 needs 32 bytes
            byte[] iv = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 16));  // AES block size is 16 bytes

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                using (CryptoStream cs = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(text);
                }
            }
        }

        private static string DecryptFile(string filePath)
        {
            byte[] key = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 32));
            byte[] iv = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 16));

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                using (CryptoStream cs = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
