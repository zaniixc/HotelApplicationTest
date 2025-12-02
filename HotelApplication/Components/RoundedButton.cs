
using System.ComponentModel;
using System.Drawing.Drawing2D;
using static HotelApplication.Components.RoundedCorners;

namespace HotelApplication.Components
{
    public class RoundedButton : Button
    {
  
        private int _borderRadius = 20;
        private int _borderSize = 0;
        private Color _borderColor = HotelPalette.Border;

    
        [Category("Appearance")]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Category("Appearance")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

     
        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = HotelPalette.Accent;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
        }

        
        private void Button_Resize(object sender, EventArgs e)
        {
            if (_borderRadius > this.Height)
                _borderRadius = this.Height;
        }

        // Methods
        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 2, this.Height - 2);

            if (_borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, _borderRadius))
                using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, _borderRadius - 1))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(_borderColor, _borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;

                    // 1. Button Surface (This clips the button to the round shape)
                    this.Region = new Region(pathSurface);

                    // 2. Draw Surface border (Fixes aliased/jagged edges by blending with parent)
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    // 3. Button Border (Optional colored border)
                    if (_borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (_borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(_borderColor, _borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        // Handle parent background color changes
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.Parent != null)
            {
                this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
            }
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
