using System;
using System.ComponentModel;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Code_Editor.Controls
{
    public class RoundButton : Button
    {
        int borderSize = 0;
        int borderRadius = 40;

        bool isAnimated = false;

        Color borderColor = Color.PaleVioletRed;

        [Category("HolyJavaEditor")]
        public int BorderSize { get => borderSize; 
            set { borderSize = value; Invalidate(); } }

        [Category("HolyJavaEditor")]
        public int BorderRadius { get => borderRadius; 
            set { borderRadius = value; Invalidate(); } }

        [Category("HolyJavaEditor")]
        public Color BorderColor { get => borderColor; 
            set { borderColor = value; Invalidate(); } }

        [Category("HolyJavaEditor")]
        public Color BackgroundColor { get => BackColor; set=>BackColor = value; }

        [Category("HolyJavaEditor")]
        public Color TextColor { get => ForeColor; set=>ForeColor = value; }

        [Category("HolyJavaEditor")]
        public bool Animated { get => isAnimated; set => isAnimated = value; }

        public RoundButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = Color.MediumSlateBlue;
            ForeColor = Color.White;
        }

        GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width-radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width-radius, rect.Height-radius, 
                radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height-radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0 , Width, Height);
            RectangleF rectBorder = new RectangleF(1, 1, Width-0.8f, Height-1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, 
                    borderRadius))
                using(GraphicsPath pathBorder =  GetFigurePath(rectBorder, 
                    borderRadius-1))
                using (Pen penSurface = new Pen(Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    Region = new Region(pathSurface);

                    e.Graphics.DrawPath(penSurface, pathSurface);
                    
                    if (borderSize > 1)
                        e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawRectangle(penBorder, 0, 0, Width-1, Height-1);
                    }
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (isAnimated)
            {
                Size = new Size(Size.Width + 2, Size.Height + 2);
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (isAnimated)
            {
                Size = new Size(Size.Width - 2, Size.Height - 2);
                Invalidate();
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (DesignMode)
                Invalidate();
        }
    }
}
