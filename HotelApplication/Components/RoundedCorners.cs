using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HotelApplication.Components
{
    public class RoundedCorners : Form
    {

        public static class HotelPalette
        {
            public static readonly Color MainBackground = Color.FromArgb(20, 20, 20);  
            public static readonly Color Surface = Color.FromArgb(32, 32, 32);    
            public static readonly Color Border = Color.FromArgb(60, 60, 60);      
            public static readonly Color Accent = Color.FromArgb(100, 149, 237);  
            public static readonly Color TextPrimary = Color.FromArgb(230, 230, 230);
            public static readonly Color TextSecondary = Color.FromArgb(160, 160, 160);   
        }

        private int _borderRadius = 30;
        private int _borderSize = 2;
        private Color _borderColor = Color.FromArgb(128, 128, 255);

      
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

   
        public RoundedCorners()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(_borderSize); 
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 0x1;
            const int HTCAPTION = 0x2;

            base.WndProc(ref m);

         
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                m.Result = (IntPtr)HTCAPTION;
            }
        }

      
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
           
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 2, this.Height - 2);

            if (_borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, _borderRadius))
                using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, _borderRadius - 1))
                using (Pen penSurface = new Pen(this.Parent != null ? this.Parent.BackColor : Color.Gray, 1))
                using (Pen penBorder = new Pen(_borderColor, _borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;

                    this.Region = new Region(pathSurface);

                
                    e.Graphics.DrawPath(penSurface, pathSurface);

                  
                    if (_borderSize >= 1)
                    {
                        e.Graphics.DrawPath(penBorder, pathBorder);
                    }
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
                        e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }


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


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}

