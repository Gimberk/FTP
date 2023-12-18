using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Code_Editor.Controls
{
    [DefaultEvent("TextChanged_")]
    public partial class RoundedEntryBox : UserControl
    {
        Color borderColor = Color.MediumSlateBlue;
        int borderSize = 2;
        bool underlinedStyle = false;
        Color borderFocusColor = Color.HotPink;

        bool isFocused = false;

        int borderRadius = 0;
        Color placeHolderColor = Color.DarkGray;
        string placeHolderText = string.Empty;
        bool isPlaceHolder = false;
        bool isAnimated = false;
        bool isPasswordChar = false;

        [Category("HolyJavaEditor")]
        public Color BorderColor { get => borderColor;
            set { borderColor = value; Invalidate(); } }
        [Category("HolyJavaEditor")]
        public int BorderSize { get => borderSize;
            set { borderSize = value; Invalidate(); } }
        [Category("HolyJavaEditor")]
        public bool UnderlinedStyle { get => underlinedStyle;
            set { underlinedStyle = value; Invalidate(); } }

        [Category("HolyJavaEditor")]
        public bool PasswordCharacters
        {
            get => isPasswordChar;
            set { textBox1.UseSystemPasswordChar = value; isPasswordChar = value; }
        }

        [Category("HolyJavaEditor")]
        public bool Multiline
        {
            get => textBox1.Multiline;
            set => textBox1.Multiline = value;
        }

        [Category("HolyJavaEditor")]
        public override Color BackColor { get => base.BackColor;
            set { base.BackColor = value; textBox1.BackColor = value; } }

        [Category("HolyJavaEditor")]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set { base.ForeColor = value; textBox1.ForeColor = value; }
        }

        [Category("HolyJavaEditor")]
        public override Font Font { get => base.Font;
            set { base.Font = value; textBox1.Font = value;
                if (DesignMode) { UpdateControlHeight(); } } }

        [Category("HolyJavaEditor")]
        public string Texts
        {
            get { if (isPlaceHolder) { return string.Empty; } return textBox1.Text; }
            set { textBox1.Text = value; SetPlaceHolder(); }
        }

        [Category("HolyJavaEditor")]
        public Color BorderFocusColor { get => borderFocusColor; set => borderFocusColor = value; }

        [Category("HolyJavaEditor")]
        public int BorderRadius { get => borderRadius;
            set { if (value >= 0) { borderRadius = value; Invalidate(); } } }

        [Category("HolyJavaEditor")]
        public Color PlaceHolderColor { get => placeHolderColor; 
            set { placeHolderColor = value; if (isPlaceHolder) { textBox1.ForeColor = value; } } }

        [Category("HolyJavaEditor")]
        public string PlaceHolderText { get => placeHolderText; 
            set { placeHolderText = value; textBox1.Text = string.Empty; SetPlaceHolder(); } }

        [Category("HolyJavaEditor")]
        public bool Animated 
        { 
            get => isAnimated;
            set => isAnimated = value;
        }

        public void SetText(string text)
        {
            RemovePlaceHolder();
            Texts = text;
        }

        void SetPlaceHolder()
        {
            if (string.IsNullOrEmpty(textBox1.Text) && placeHolderText != string.Empty)
            {
                isPlaceHolder = true;
                textBox1.Text = placeHolderText;
                textBox1.ForeColor = placeHolderColor;
                textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);

                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = false;
            }
        }

        void RemovePlaceHolder()
        {
            if (isPlaceHolder && placeHolderText != string.Empty)
            {
                isPlaceHolder = false;
                textBox1.Text = string.Empty;
                textBox1.ForeColor = ForeColor;
                textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);

                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }

        [Category("HolyJavaEditor")]
        public event EventHandler TextChanged_;

        public RoundedEntryBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            if (borderRadius > 1)
            {
                var rectBorderSmooth = ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    Region = new Region(pathBorderSmooth);
                    if (borderRadius > 15) SetTextBoxRoundedRegion();
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;
                    if (underlinedStyle)
                    {
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graphics.SmoothingMode = SmoothingMode.None;
                        graphics.DrawLine(penBorder, 0, Height - 1, Width, Height - 1);
                    }
                    else
                    {
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    Region = new Region(ClientRectangle);
                    penBorder.Alignment = PenAlignment.Inset;

                    if (!isFocused)
                    {
                        if (underlinedStyle)
                        {
                            graphics.DrawLine(penBorder, 0, Height - 1, Width, Height - 1);
                        }
                        else
                            graphics.DrawRectangle(penBorder, 0, 0, Width - 0.5f, Height - 0.5f);
                    }
                    else
                    {
                        penBorder.Color = borderFocusColor;

                        if (underlinedStyle)
                        {
                            graphics.DrawLine(penBorder, 0, Height - 1, Width, Height - 1);
                        }
                        else
                            graphics.DrawRectangle(penBorder, 0, 0, Width - 0.5f, Height - 0.5f);
                    }
                }
            }
        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;

            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius * 2);
                textBox1.Region = new Region(pathTxt);
            }
        }

        GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Width - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Width - curveSize, rect.Height - curveSize,
                curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Height - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (DesignMode)
                UpdateControlHeight();
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
                int txtHeight = TextRenderer.MeasureText("Text", Font).Height+1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                Height = textBox1.Height + Padding.Top + Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged_ != null)
                TextChanged_.Invoke(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
            if (isAnimated)
            {
                borderSize += 1;
                Invalidate();
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
            if (isAnimated)
            {
                borderSize -= 1;
                Invalidate();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            Invalidate();
            RemovePlaceHolder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            Invalidate();
            SetPlaceHolder();
        }
    }
}
