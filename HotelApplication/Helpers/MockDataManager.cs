using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// Note: If System.Text.Json is missing, add it via NuGet or use Newtonsoft.Json
using System.Text.Json;

namespace HotelApp.UI.Helpers
{
    // Simple Model for our User
    public class UserData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsBooked { get; set; }
        public decimal Balance { get; set; }
        public string CurrentRoom { get; set; } // Null if not booked
    }

    public static class MockDataManager
    {
        private static string filePath = "mock_data.json";

        public static List<UserData> LoadUsers()
        {
            if (!File.Exists(filePath))
            {
                return InitializeDefaults();
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<UserData>>(json) ?? InitializeDefaults();
        }

        public static void SaveUsers(List<UserData> users)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(users, options);
            File.WriteAllText(filePath, json);
        }

        public static UserData GetUser(string username)
        {
            var users = LoadUsers();
            return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public static void UpdateUserBooking(string username, bool isBooked, string roomName, decimal cost)
        {
            var users = LoadUsers();
            var user = users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                user.IsBooked = isBooked;
                user.CurrentRoom = roomName;
                user.Balance -= cost; // Deduct balance
                SaveUsers(users);
            }
        }

        private static List<UserData> InitializeDefaults()
        {
            var users = new List<UserData>
            {
                new UserData { Username = "admin", Password = "123", Role = "Admin", IsBooked = false, Balance = 0 },
                new UserData { Username = "staff", Password = "123", Role = "Staff", IsBooked = false, Balance = 0 },
                // Booked Customer
                new UserData { Username = "customer1", Password = "123", Role = "Customer", IsBooked = true, Balance = 1500.00m, CurrentRoom = "Presidential Suite" },
                // Not Booked Customer
                new UserData { Username = "customer2", Password = "123", Role = "Customer", IsBooked = false, Balance = 5000.00m, CurrentRoom = null }
            };
            SaveUsers(users);
            return users;
        }
    }
}