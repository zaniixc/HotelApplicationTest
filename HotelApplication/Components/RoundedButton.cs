using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace HotelApplication.Components
{
    [DesignerCategory("Code")]
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    public class RoundedButton : Button
    {
        private int borderSize = 0;
        private int borderRadius = 20;
        private Color borderColor = Color.FromArgb(60, 60, 60);
        private Color backgroundColor = Color.FromArgb(64, 64, 64);
        private Color textColor = Color.White;
        private bool isHovered = false;
        private bool isPressed = false;

        private const int DEFAULT_WIDTH = 150;
        private const int DEFAULT_HEIGHT = 40;
        private const int MIN_RADIUS = 0;
        private const int MAX_RADIUS = 100;

        [Category("Appearance")]
        [Description("The size of the button's border")]
        [DefaultValue(0)]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                if (borderSize != value)
                {
                    borderSize = Math.Max(0, value);
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [Description("The radius of the button's rounded corners")]
        [DefaultValue(20)]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                if (borderRadius != value)
                {
                    borderRadius = Math.Max(MIN_RADIUS, Math.Min(MAX_RADIUS, value));
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [Description("The color of the button's border")]
        [DefaultValue(typeof(Color), "60, 60, 60")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                if (borderColor != value)
                {
                    borderColor = value;
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [Description("The background color of the button")]
        [DefaultValue(typeof(Color), "64, 64, 64")]
        public Color BackgroundColor
        {
            get => backgroundColor;
            set
            {
                if (backgroundColor != value)
                {
                    backgroundColor = value;
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [Description("The color of the button's text")]
        [DefaultValue(typeof(Color), "White")]
        public Color TextColor
        {
            get => textColor;
            set
            {
                if (textColor != value)
                {
                    textColor = value;
                    Invalidate();
                }
            }
        }

        public override Color BackColor
        {
            get => backgroundColor;
            set => BackgroundColor = value;
        }

        public override Color ForeColor
        {
            get => textColor;
            set => TextColor = value;
        }

        [Category("Appearance")]
        [Description("The background color when the mouse hovers over the button")]
        [DefaultValue(typeof(Color), "80, 80, 80")]
        public Color HoverColor { get; set; } = Color.FromArgb(80, 80, 80);

        [Category("Appearance")]
        [Description("The background color when the button is pressed")]
        [DefaultValue(typeof(Color), "100, 100, 100")]
        public Color PressColor { get; set; } = Color.FromArgb(100, 100, 100);

        public RoundedButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.UserPaint, true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT);
            base.BackColor = backgroundColor;
            base.ForeColor = textColor;

            MouseEnter += (s, e) => { isHovered = true; Invalidate(); };
            MouseLeave += (s, e) => { isHovered = false; Invalidate(); };
            MouseDown += (s, e) => { isPressed = true; Invalidate(); };
            MouseUp += (s, e) => { isPressed = false; Invalidate(); };
        }

        private GraphicsPath GetRoundedRectanglePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            float diameter = radius * 2;
            SizeF size = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rect.Location, size);

            path.AddArc(arc, 180, 90);

            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Color currentBgColor = backgroundColor;
            if (isPressed && Enabled)
                currentBgColor = PressColor;
            else if (isHovered && Enabled)
                currentBgColor = HoverColor;

            RectangleF rect = new RectangleF(0, 0, Width, Height);
            RectangleF borderRect = RectangleF.Inflate(rect, -borderSize, -borderSize);

            using (GraphicsPath path = GetRoundedRectanglePath(rect, borderRadius))
            using (GraphicsPath borderPath = GetRoundedRectanglePath(borderRect, Math.Max(0, borderRadius - borderSize)))
            {
                if (borderRadius > 0)
                    Region = new Region(path);

                using (Brush bgBrush = new SolidBrush(currentBgColor))
                {
                    e.Graphics.FillPath(bgBrush, path);
                }

                if (borderSize > 0 && borderColor != Color.Transparent)
                {
                    using (Pen borderPen = new Pen(borderColor, borderSize))
                    {
                        e.Graphics.DrawPath(borderPen, borderPath);
                    }
                }

                if (!string.IsNullOrEmpty(Text))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    using (Brush textBrush = new SolidBrush(Enabled ? textColor : Color.Gray))
                    {
                        e.Graphics.DrawString(Text, Font, textBrush, rect, sf);
                    }
                }

                if (Focused && ShowFocusCues)
                {
                    Rectangle focusRect = Rectangle.Inflate(ClientRectangle, -4, -4);
                    ControlPaint.DrawFocusRectangle(e.Graphics, focusRect);
                }
            }
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            Invalidate();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
