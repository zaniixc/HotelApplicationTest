using HotelApp.UI.Components;
using HotelApp.UI.Helpers;
using HotelApplication.Components;
using HotelApplication.Helpers;
using System.Data;
using System.IO;
using System.Drawing;
using static HotelApplication.Components.RoundedCorners;

namespace HotelApplication.Forms.Dashboard
{
    public partial class CustomerUC : UserControl
    {
        // --- Models ---
        private class RoomItem
        {
            public string Name;
            public decimal Price;
            public string Type;
            public string Description;
            public double Rating;
            public List<string> Amenities;
            public string ImageFile;
        }

        private class ServiceItem
        {
            public string Name;
            public decimal Price;
            public string Category;
            public string Description;
            public double Rating;
            public string ImageFile;
        }

        private class HistoryItem
        {
            public string Action;
            public string Details;
            public DateTime Time;
            public decimal Cost;
        }

        // --- UI Controls ---
        private Panel pnlHeader;
        private Panel pnlContentArea;
        private FlowLayoutPanel flowMainContent;

        // Header Controls
        private Label lblWelcome;
        private Label lblBalance;
        private RoundedButton btnAddFunds;

        // Filter & Sort Controls
        private Panel pnlFilters;
        private UITextBox txtSearch;
        private ComboBox cmbSort;
        private FlowLayoutPanel flowCategories;

        // Modal / Overlay Controls
        private Panel pnlOverlay; // Dark background for modal
        private Panel pnlDetailModal; // The actual pop-up card

        // Notification Toast
        private Label lblToast;
        private System.Windows.Forms.Timer tmrToast; // Fixed: Explicit namespace

        // --- Data ---
        private UserData currentUser;
        private List<RoomItem> allRooms;
        private List<ServiceItem> allServices;
        private List<HistoryItem> sessionHistory;

        // State
        private string currentCategoryFilter = "All";

        private const string AssetsFolderName = "Assets";

        private static readonly Dictionary<string, Image> _imageCache = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);

        public CustomerUC()
        {
            InitializeComponent();
            InitializeData();
            SetupManualUI();

            // Default Loading Logic
            string username = SessionManager.CurrentUser?.Username ?? "customer2";
            LoadCustomerData(username);
        }

        // Fixed: Removed manual InitializeComponent() to avoid ambiguity with Designer file.

        private void InitializeData()
        {
            sessionHistory = new List<HistoryItem>();

            // Feature-Rich Mock Data
            allRooms = new List<RoomItem> {
                new RoomItem { Name = "Presidential Suite", Price = 1200m, Type = "Luxury", Rating = 5.0, Description = "Experience the pinnacle of luxury with a panoramic ocean view, private butler service, and exclusive access to the sky lounge.", Amenities = new List<string>{"Butler", "Jacuzzi", "Sky Lounge", "King Bed"}, ImageFile = "presidential.jpg" },
                new RoomItem { Name = "Executive Ocean View", Price = 800m, Type = "Suite", Rating = 4.8, Description = "Spacious suite featuring a private balcony facing the sea, perfect for sunsets.", Amenities = new List<string>{"Balcony", "Mini Bar", "Work Desk", "Ocean View"}, ImageFile = "ocean_view.jpg" },
                new RoomItem { Name = "Garden Villa", Price = 650m, Type = "Luxury", Rating = 4.9, Description = "A private villa surrounded by lush tropical gardens with a private plunge pool.", Amenities = new List<string>{"Private Pool", "Garden", "Hammock"}, ImageFile = "garden_villa.jpg" },
                new RoomItem { Name = "Deluxe King", Price = 450m, Type = "Deluxe", Rating = 4.5, Description = "Modern comfort with a plush King sized bed and a spa-inspired bathroom.", Amenities = new List<string>{"King Bed", "Rain Shower", "Smart TV"}, ImageFile = "deluxe_king.jpg" },
                new RoomItem { Name = "Double Queen", Price = 350m, Type = "Deluxe", Rating = 4.4, Description = "Two queen beds, ideal for families or friends traveling together.", Amenities = new List<string>{"2 Queen Beds", "Bathtub", "Free Wi-Fi"}, ImageFile = "double_queen.jpg" },
                new RoomItem { Name = "Standard Queen", Price = 200m, Type = "Standard", Rating = 4.0, Description = "Cozy and efficient room with a city view.", Amenities = new List<string>{"Queen Bed", "City View", "Coffee Maker"}, ImageFile = "standard_queen.jpg" },
                new RoomItem { Name = "Economy Single", Price = 100m, Type = "Economy", Rating = 3.8, Description = "Budget-friendly option for the solo traveler.", Amenities = new List<string>{"Single Bed", "Desk", "Compact"}, ImageFile = "economy_single.jpg" }
            };

            allServices = new List<ServiceItem> {
                new ServiceItem { Name = "Wagyu Burger", Price = 45m, Category = "Food", Rating = 4.8, Description = "A5 Wagyu beef patty with truffle mayo and brioche bun.", ImageFile = "wagyu_burger.jpg" },
                new ServiceItem { Name = "Lobster Thermidor", Price = 85m, Category = "Food", Rating = 4.9, Description = "Whole lobster cooked in a rich creamy sauce.", ImageFile = "lobster_thermidor.jpg" },
                new ServiceItem { Name = "Club Sandwich", Price = 22m, Category = "Food", Rating = 4.2, Description = "Classic triple-decker sandwich with chicken, bacon, and egg.", ImageFile = "club_sandwich.jpg" },
                new ServiceItem { Name = "Champagne Bottle", Price = 150m, Category = "Drinks", Rating = 5.0, Description = "Premium vintage champagne on ice.", ImageFile = "champagne.jpg" },
                new ServiceItem { Name = "Craft Beer", Price = 12m, Category = "Drinks", Rating = 4.5, Description = "Local IPA brewed in-house.", ImageFile = "craft_beer.jpg" },
                new ServiceItem { Name = "Full Body Massage", Price = 120m, Category = "Spa", Rating = 4.9, Description = "60-minute relaxing Swedish massage.", ImageFile = "massage.jpg" },
                new ServiceItem { Name = "Dry Cleaning", Price = 30m, Category = "Service", Rating = 4.0, Description = "Next-day dry cleaning service for one suit.", ImageFile = "dry_cleaning.jpg" }
            };
        }

        private void SetupManualUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = HotelPalette.MainBackground;

            // --- 1. Header ---
            pnlHeader = new Panel { Height = 80, Dock = DockStyle.Top, BackColor = HotelPalette.MainBackground, Padding = new Padding(20) };

            lblWelcome = new Label { Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, AutoSize = true, Location = new Point(20, 25) };

            // Wallet Area
            Panel pnlWallet = new Panel { Size = new Size(350, 50), Dock = DockStyle.Right };
            lblBalance = new Label { Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.LightGreen, Location = new Point(0, 10), AutoSize = true, Text = "$0.00" };

            btnAddFunds = new RoundedButton { Text = "+ Deposit", Size = new Size(120, 35), Location = new Point(200, 5), BackColor = HotelPalette.Surface, BorderColor = Color.Green, BorderSize = 1 };
            btnAddFunds.Click += BtnAddFunds_Click;

            pnlWallet.Controls.Add(lblBalance);
            pnlWallet.Controls.Add(btnAddFunds);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(pnlWallet);

            // --- 2. Filter Bar ---
            pnlFilters = new Panel { Height = 60, Dock = DockStyle.Top, Visible = false, Padding = new Padding(20, 10, 20, 0) };

            txtSearch = new UITextBox { PlaceholderText = "Search...", Size = new Size(250, 40), Location = new Point(20, 10), BorderRadius = 15 };
            txtSearch._TextChanged += (s, e) => ApplyFilters();

            cmbSort = new ComboBox { Location = new Point(290, 18), Size = new Size(150, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, BackColor = HotelPalette.Surface, ForeColor = Color.White, Font = new Font("Segoe UI", 10) };
            cmbSort.Items.AddRange(new object[] { "Sort by Price: Low to High", "Sort by Price: High to Low", "Sort by Rating" });
            cmbSort.SelectedIndex = 0;
            cmbSort.SelectedIndexChanged += (s, e) => ApplyFilters();

            flowCategories = new FlowLayoutPanel { Location = new Point(460, 10), Size = new Size(500, 45), AutoSize = true };

            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Controls.Add(cmbSort);
            pnlFilters.Controls.Add(flowCategories);

            // --- 3. Main Content ---
            pnlContentArea = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            flowMainContent = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = HotelPalette.MainBackground };

            pnlContentArea.Controls.Add(flowMainContent);
            pnlContentArea.Controls.Add(pnlFilters);

            // --- 4. Modal Overlay (Hidden by default) ---
            pnlOverlay = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(180, 0, 0, 0), Visible = false };
            pnlOverlay.Click += (s, e) => HideModal(); // Click outside to close

            // --- 5. Toast Notification ---
            lblToast = new Label
            {
                AutoSize = false,
                Size = new Size(300, 50),
                BackColor = HotelPalette.Accent,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Visible = false
            };
            this.Controls.Add(lblToast); // Add to root to float on top
            lblToast.BringToFront();

            // Fixed: Use System.Windows.Forms.Timer explicitly
            tmrToast = new System.Windows.Forms.Timer { Interval = 3000 };
            tmrToast.Tick += (s, e) => { lblToast.Visible = false; tmrToast.Stop(); };

            // Assemble
            this.Controls.Add(pnlOverlay); // Overlay must be on top of content
            this.Controls.Add(pnlContentArea);
            this.Controls.Add(pnlHeader);
        }

        public void LoadCustomerData(string username)
        {
            currentUser = MockDataManager.GetUser(username);
            if (currentUser == null) return;

            lblWelcome.Text = $"Welcome back, {currentUser.Username}";
            UpdateBalanceDisplay();

            // Default view logic
            if (currentUser.IsBooked) LoadRoomServices();
            else LoadAvailableRooms();
        }

        private void UpdateBalanceDisplay()
        {
            lblBalance.Text = $"${currentUser.Balance:N2}";
        }

        // --- PUBLIC METHODS (Accessible by Dashboard) ---

        public void LoadAvailableRooms()
        {
            pnlFilters.Visible = true;
            SetupCategories("All", "Luxury", "Suite", "Deluxe", "Standard", "Economy");
            ApplyFilters(); // Triggers render
        }

        public void LoadRoomServices()
        {
            if (!currentUser.IsBooked)
            {
                ShowToast("Please check-in to a room to access services.");
                return;
            }
            pnlFilters.Visible = true;
            SetupCategories("All", "Food", "Drinks", "Spa", "Service");
            ApplyFilters();
        }

        public void LoadHistory()
        {
            pnlFilters.Visible = false;
            flowMainContent.Controls.Clear();
            flowMainContent.Controls.Add(CreateSectionHeader("Transaction History"));

            if (sessionHistory.Count == 0)
            {
                Label lbl = new Label { Text = "No recent activity.", ForeColor = Color.Gray, AutoSize = true, Margin = new Padding(10), Font = new Font("Segoe UI", 10) };
                flowMainContent.Controls.Add(lbl);
                return;
            }

            foreach (var item in sessionHistory)
            {
                Panel row = new Panel { Size = new Size(700, 60), BackColor = HotelPalette.Surface, Margin = new Padding(0, 0, 0, 10) };

                Label lblAction = new Label { Text = item.Action, ForeColor = HotelPalette.Accent, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(15, 15), AutoSize = true };
                Label lblDetail = new Label { Text = item.Details, ForeColor = HotelPalette.TextPrimary, Font = new Font("Segoe UI", 10), Location = new Point(15, 35), AutoSize = true };
                Label lblDate = new Label { Text = item.Time.ToShortTimeString(), ForeColor = Color.Gray, Location = new Point(400, 20), AutoSize = true };
                Label lblCost = new Label { Text = $"-${item.Cost:N2}", ForeColor = Color.IndianRed, Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(580, 15), AutoSize = true };

                row.Controls.Add(lblAction);
                row.Controls.Add(lblDetail);
                row.Controls.Add(lblDate);
                row.Controls.Add(lblCost);
                flowMainContent.Controls.Add(row);
            }
        }

        // --- FILTERING & SORTING LOGIC ---

        private void SetupCategories(params string[] cats)
        {
            flowCategories.Controls.Clear();
            currentCategoryFilter = "All"; // Reset

            foreach (var c in cats)
            {
                RoundedButton btn = new RoundedButton { Text = c, Size = new Size(90, 32), BorderRadius = 15, BackColor = HotelPalette.Surface, BorderColor = HotelPalette.Border };
                if (c == "All") btn.BackColor = HotelPalette.Accent; // Highlight All by default

                btn.Click += (s, e) => {
                    // Reset UI styles
                    foreach (Control ctrl in flowCategories.Controls)
                        if (ctrl is RoundedButton rb) rb.BackColor = HotelPalette.Surface;

                    btn.BackColor = HotelPalette.Accent;
                    currentCategoryFilter = c;
                    ApplyFilters();
                };
                flowCategories.Controls.Add(btn);
            }
        }

        private void ApplyFilters()
        {
            string search = txtSearch.Text.ToLower();

            // NOTE: Robust way relies on a state flag. 
            // Let's infer context from the first category button.
            bool isServiceContext = false;
            if (flowCategories.Controls.Count > 1 && flowCategories.Controls[1].Text == "Food") isServiceContext = true;

            flowMainContent.Controls.Clear();

            if (!isServiceContext)
            {
                // ROOM FILTERING
                var query = allRooms.Where(r => r.Name.ToLower().Contains(search));
                if (currentCategoryFilter != "All") query = query.Where(r => r.Type == currentCategoryFilter);

                // Sorting
                if (cmbSort.SelectedIndex == 0) query = query.OrderBy(r => r.Price);
                else if (cmbSort.SelectedIndex == 1) query = query.OrderByDescending(r => r.Price);
                else query = query.OrderByDescending(r => r.Rating);

                // Add Banner
                if (currentCategoryFilter == "All" && string.IsNullOrEmpty(search)) flowMainContent.Controls.Add(CreateBanner());

                flowMainContent.Controls.Add(CreateSectionHeader(currentCategoryFilter == "All" ? "All Rooms" : $"{currentCategoryFilter} Rooms"));
                foreach (var r in query) flowMainContent.Controls.Add(CreateRoomCard(r));
            }
            else
            {
                // SERVICE FILTERING
                var query = allServices.Where(s => s.Name.ToLower().Contains(search));
                if (currentCategoryFilter != "All") query = query.Where(s => s.Category == currentCategoryFilter);

                // Sorting
                if (cmbSort.SelectedIndex == 0) query = query.OrderBy(s => s.Price);
                else if (cmbSort.SelectedIndex == 1) query = query.OrderByDescending(s => s.Price);
                else query = query.OrderByDescending(s => s.Rating);

                flowMainContent.Controls.Add(CreateSectionHeader("Room Services"));
                foreach (var s in query) flowMainContent.Controls.Add(CreateServiceCard(s));
            }
        }

        // --- VISUAL COMPONENTS GENERATORS ---

        private Panel CreateBanner()
        {
            Panel p = new Panel { Size = new Size(800, 150), BackColor = HotelPalette.Surface, Margin = new Padding(10, 0, 10, 20) };
            Label l1 = new Label { Text = "SUMMER SALE!", Font = new Font("Segoe UI", 24, FontStyle.Bold), ForeColor = HotelPalette.Accent, Location = new Point(30, 30), AutoSize = true };
            Label l2 = new Label { Text = "Get 20% off all Luxury Suites this weekend.", Font = new Font("Segoe UI", 12), ForeColor = Color.White, Location = new Point(30, 80), AutoSize = true };
            p.Controls.Add(l1); p.Controls.Add(l2);
            return p;
        }

        private Panel CreateRoomCard(RoomItem r)
        {
            return CreateGenericCard(r.Name, r.Price, r.Rating, r.Description, "View Details", (sender, args) => ShowRoomModal(r), r.ImageFile);
        }

        private Panel CreateServiceCard(ServiceItem s)
        {
            return CreateGenericCard(s.Name, s.Price, s.Rating, s.Description, "Order Now", (sender, args) => ShowServiceModal(s), s.ImageFile);
        }

        private Panel CreateGenericCard(string title, decimal price, double rating, string desc, string btnText, EventHandler onClick, string imageFile = null)
        {
            Panel card = new Panel { Size = new Size(260, 340), BackColor = HotelPalette.Surface, Margin = new Padding(10) };

            PictureBox pic = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 140,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.DimGray
            };

            if (!string.IsNullOrWhiteSpace(imageFile))
            {
                var img = TryLoadImage(imageFile);
                if (img != null) pic.Image = img;
            }

            // Content
            Label lblT = new Label { Text = title, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, Location = new Point(10, 150), AutoSize = true, MaximumSize = new Size(240, 0) };
            Label lblP = new Label { Text = $"${price:N0}", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = HotelPalette.Accent, Location = new Point(10, 180), AutoSize = true };
            Label lblR = new Label { Text = $"★ {rating:N1}", Font = new Font("Segoe UI", 10), ForeColor = Color.Gold, Location = new Point(180, 182), AutoSize = true };
            Label lblD = new Label { Text = desc, Font = new Font("Segoe UI", 9), ForeColor = HotelPalette.TextSecondary, Location = new Point(10, 215), Size = new Size(240, 60) };

            RoundedButton btn = new RoundedButton { Text = btnText, Size = new Size(240, 35), Location = new Point(10, 290), BorderRadius = 8 };
            btn.Click += onClick;

            card.Controls.Add(btn);
            card.Controls.Add(lblD);
            card.Controls.Add(lblR);
            card.Controls.Add(lblP);
            card.Controls.Add(lblT);
            card.Controls.Add(pic);
            return card;
        }

        // --- MODAL / DETAILS VIEW LOGIC ---

        private void ShowRoomModal(RoomItem r)
        {
            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = true;
            pnlOverlay.BringToFront();

            // Modal Card
            Panel modal = new Panel { Size = new Size(500, 460), BackColor = HotelPalette.Surface, Location = new Point((this.Width - 500) / 2, (this.Height - 460) / 2) };

            PictureBox modalPic = new PictureBox { Size = new Size(460, 180), Location = new Point(20, 15), SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.DimGray };
            if (!string.IsNullOrWhiteSpace(r.ImageFile))
            {
                var img = TryLoadImage(r.ImageFile);
                if (img != null) modalPic.Image = img;
            }

            Label title = new Label { Text = r.Name, Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.White, Location = new Point(20, 205), AutoSize = true };
            Label price = new Label { Text = $"Price: ${r.Price}/night", Font = new Font("Segoe UI", 14), ForeColor = HotelPalette.Accent, Location = new Point(20, 245), AutoSize = true };
            Label desc = new Label { Text = r.Description, Font = new Font("Segoe UI", 10), ForeColor = Color.White, Location = new Point(20, 280), Size = new Size(460, 60) };

            // Amenities List
            Label lblAm = new Label { Text = "Amenities:", Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.White, Location = new Point(20, 340), AutoSize = true };
            FlowLayoutPanel amFlow = new FlowLayoutPanel { Location = new Point(20, 360), Size = new Size(460, 60) };
            foreach (var am in r.Amenities)
            {
                Label badge = new Label { Text = $"• {am}", ForeColor = Color.LightGray, AutoSize = true, Margin = new Padding(0, 0, 15, 5) };
                amFlow.Controls.Add(badge);
            }

            RoundedButton btnConfirm = new RoundedButton { Text = "Confirm Booking", BackColor = HotelPalette.Accent, Size = new Size(150, 40), Location = new Point(330, 400) };
            btnConfirm.Click += (s, e) => { BookRoom(r); HideModal(); };

            RoundedButton btnClose = new RoundedButton { Text = "Close", BackColor = Color.FromArgb(60, 60, 60), Size = new Size(100, 40), Location = new Point(20, 400) };
            btnClose.Click += (s, e) => HideModal();

            modal.Controls.Add(modalPic);
            modal.Controls.Add(btnConfirm);
            modal.Controls.Add(btnClose);
            modal.Controls.Add(amFlow);
            modal.Controls.Add(lblAm);
            modal.Controls.Add(desc);
            modal.Controls.Add(price);
            modal.Controls.Add(title);

            pnlOverlay.Controls.Add(modal);
        }

        private void ShowServiceModal(ServiceItem s)
        {
            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = true;
            pnlOverlay.BringToFront();

            Panel modal = new Panel { Size = new Size(400, 380), BackColor = HotelPalette.Surface, Location = new Point((this.Width - 400) / 2, (this.Height - 380) / 2) };

            PictureBox modalPic = new PictureBox { Size = new Size(360, 140), Location = new Point(20, 15), SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.DimGray };
            if (!string.IsNullOrWhiteSpace(s.ImageFile))
            {
                var img = TryLoadImage(s.ImageFile);
                if (img != null) modalPic.Image = img;
            }

            Label title = new Label { Text = s.Name, Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.White, Location = new Point(20, 165), AutoSize = true };
            Label price = new Label { Text = $"${s.Price}", Font = new Font("Segoe UI", 14), ForeColor = HotelPalette.Accent, Location = new Point(20, 205), AutoSize = true };
            Label desc = new Label { Text = s.Description, Font = new Font("Segoe UI", 10), ForeColor = Color.White, Location = new Point(20, 240), Size = new Size(360, 80) };

            RoundedButton btnOrder = new RoundedButton { Text = "Place Order", BackColor = HotelPalette.Accent, Size = new Size(150, 40), Location = new Point(230, 320) };
            btnOrder.Click += (ev, arg) => { OrderService(s); HideModal(); };

            RoundedButton btnClose = new RoundedButton { Text = "Cancel", BackColor = Color.FromArgb(60, 60, 60), Size = new Size(100, 40), Location = new Point(20, 320) };
            btnClose.Click += (ev, arg) => HideModal();

            modal.Controls.Add(modalPic);
            modal.Controls.Add(btnOrder);
            modal.Controls.Add(btnClose);
            modal.Controls.Add(desc);
            modal.Controls.Add(price);
            modal.Controls.Add(title);

            pnlOverlay.Controls.Add(modal);
        }

        private void HideModal()
        {
            pnlOverlay.Visible = false;
            pnlOverlay.Controls.Clear();
        }

        // --- ACTIONS & TRANSACTIONS ---

        private void BtnAddFunds_Click(object sender, EventArgs e)
        {
            currentUser.Balance += 500;
            MockDataManager.UpdateUserBooking(currentUser.Username, currentUser.IsBooked, currentUser.CurrentRoom, -500);
            UpdateBalanceDisplay();
            ShowToast("+$500.00 Deposit Successful");
        }

        private void BookRoom(RoomItem r)
        {
            if (currentUser.Balance < r.Price)
            {
                ShowToast("Insufficient Funds!");
                return;
            }

            MockDataManager.UpdateUserBooking(currentUser.Username, true, r.Name, r.Price);
            sessionHistory.Add(new HistoryItem { Action = "BOOKING", Details = r.Name, Time = DateTime.Now, Cost = r.Price });

            ShowToast("Booking Confirmed!");
            LoadCustomerData(currentUser.Username);
        }

        private void OrderService(ServiceItem s)
        {
            if (currentUser.Balance < s.Price)
            {
                ShowToast("Insufficient Funds!");
                return;
            }

            MockDataManager.UpdateUserBooking(currentUser.Username, true, currentUser.CurrentRoom, s.Price);
            sessionHistory.Add(new HistoryItem { Action = "ORDER", Details = s.Name, Time = DateTime.Now, Cost = s.Price });

            ShowToast($"Ordered: {s.Name}");
            LoadCustomerData(currentUser.Username);
        }

        // --- UTILS ---

        private void ShowToast(string message)
        {
            lblToast.Text = message;
            // Center the toast at bottom
            lblToast.Location = new Point((this.Width - lblToast.Width) / 2, this.Height - 100);
            lblToast.Visible = true;
            lblToast.BringToFront();
            tmrToast.Start();
        }

        // --- IMAGE FROM "\HotelApplication\Assets\" ---

        private Image TryLoadImage(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) return CreatePlaceholderImage();

            lock (_imageCache)
            {
                if (_imageCache.TryGetValue(filename, out var cached) && cached != null)
                    return cached;
            }

            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory ?? Directory.GetCurrentDirectory();
                string assetsPath = Path.Combine(baseDir, AssetsFolderName, filename);

                if (File.Exists(assetsPath))
                {
                    using var fs = new FileStream(assetsPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    using var img = Image.FromStream(fs);
                    var bmp = new Bitmap(img);
                    lock (_imageCache) { _imageCache[filename] = bmp; }
                    return bmp;
                }

                var res = TryLoadFromResources(filename);
                if (res != null)
                {
                    lock (_imageCache) { _imageCache[filename] = res; }
                    return res;
                }
            }
            catch
            {

            }

            var placeholder = CreatePlaceholderImage();
            lock (_imageCache) { _imageCache[filename] = placeholder; }
            return placeholder;
        }

        private Image? TryLoadFromResources(string filename)
        {
            try
            {
                string baseName = Path.GetFileNameWithoutExtension(filename);
                var resourcesType = typeof(ScrollProperties).GetNestedType("Resources", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
                if (resourcesType != null)
                {
                    var prop = resourcesType.GetProperty(baseName, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                    if (prop != null)
                    {
                        var val = prop.GetValue(null);
                        if (val is Image img) return new Bitmap(img);
                    }
                }
            }
            catch
            {

            }
            return null;
        }

        private Image CreatePlaceholderImage(int width = 800, int height = 400)
        {
            var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(70, 70, 70));
            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using var font = new Font("Segoe UI", Math.Max(12, width / 20), FontStyle.Bold, GraphicsUnit.Pixel);
            using var brush = new SolidBrush(Color.FromArgb(200, 200, 200));
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString("Image Unavailable", font, brush, new RectangleF(0, 0, width, height), sf);
            return bmp;
        }

        private Label CreateSectionHeader(string t) => new Label { Text = t, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = HotelPalette.TextPrimary, AutoSize = true, Margin = new Padding(10, 20, 10, 10) };
    }
}