using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace HotelApp.UI.Components
{
    [DefaultEvent("_TextChanged")]
    public class UITextBox : UserControl
    {
       
        private Color borderColor = HotelApplication.Components.RoundedCorners.HotelPalette.Border;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = HotelApplication.Components.RoundedCorners.HotelPalette.Accent;
        private bool isFocused = false;
        private int borderRadius = 10; 
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;

        // The inner standard textbox
        private TextBox textBox1;

        // Events
        public event EventHandler _TextChanged;

        public UITextBox()
        {
            textBox1 = new TextBox();
            this.SuspendLayout();

            // Setup the inner TextBox
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Fill;
            textBox1.BackColor = HotelApplication.Components.RoundedCorners.HotelPalette.Surface;
            textBox1.ForeColor = HotelApplication.Components.RoundedCorners.HotelPalette.TextPrimary;
            textBox1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            // Hook up events
            textBox1.Enter += TextBox1_Enter;
            textBox1.Leave += TextBox1_Leave;
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox1.KeyDown += (s, e) => OnKeyDown(e);
            textBox1.KeyPress += (s, e) => OnKeyPress(e);

            // Setup container (this UserControl)
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = HotelApplication.Components.RoundedCorners.HotelPalette.Surface;
            this.Padding = new Padding(10, 7, 10, 7);
            this.Size = new Size(250, 30);
            this.Controls.Add(textBox1);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // --- Properties ---
        [Category("Appearance")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("Appearance")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Category("Appearance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set { underlinedStyle = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value;
            }
        }

        [Category("Appearance")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("Appearance")]
        public override string Text
        {
            get { return isPlaceholder ? "" : textBox1.Text; }
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        [Category("Appearance")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }

        // --- Placeholder Logic ---
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if (isPasswordChar) textBox1.UseSystemPasswordChar = false;
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar) textBox1.UseSystemPasswordChar = true;
            }
        }

        // --- Event Handlers ---
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null) _TextChanged.Invoke(sender, e);
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            RemovePlaceholder();
            this.Invalidate();
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            SetPlaceholder();
            this.Invalidate();
        }

        // --- Drawing Logic ---
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            // Colors
            Color currentBorderColor = isFocused ? borderFocusColor : borderColor;

            // Rectangles
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;

            if (underlinedStyle) // MODERN UNDERLINE LOOK
            {
                // Draw just the bottom border
                using (Pen penBorder = new Pen(currentBorderColor, borderSize))
                {
                    this.Region = new Region(rectSurface); // Square region
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                }
            }
            else // STANDARD SOFT SQUARE LOOK
            {
                if (borderRadius > 1)
                {
                    using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
                    using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - borderSize))
                    using (Pen penSurface = new Pen(this.Parent != null ? this.Parent.BackColor : HotelApplication.Components.RoundedCorners.HotelPalette.MainBackground, smoothSize))
                    using (Pen penBorder = new Pen(currentBorderColor, borderSize))
                    {
                        // 1. Set Region
                        this.Region = new Region(pathSurface);

                        // 2. Draw surface smoothing
                        penSurface.Alignment = PenAlignment.Inset;
                        graph.DrawPath(penSurface, pathSurface);

                        // 3. Draw border
                        if (borderSize >= 1)
                            graph.DrawPath(penBorder, pathBorder);
                    }
                }
                else
                {
                    // Square style
                    this.Region = new Region(rectSurface);
                    if (borderSize >= 1)
                    {
                        using (Pen penBorder = new Pen(currentBorderColor, borderSize))
                        {
                            penBorder.Alignment = PenAlignment.Inset;
                            graph.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                        }
                    }
                }
            }
        }

        // Helper: Create rounded path
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Handle resizing
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode) UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }
    }
}


