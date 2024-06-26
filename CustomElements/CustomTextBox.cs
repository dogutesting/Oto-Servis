﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Oto_Servis.CustomElements
{
    [DefaultEvent("_TextChanged")]
    public partial class CustomTextBox : UserControl
    {
        //Fields
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;

        private int borderRadius = 0;
        private Color placeHolderColor = Color.DarkGray;
        private string placeholderText = "";
        public bool isPlaceholder = false;
        private bool isPasswordChar = false;

        //Constructor
        public CustomTextBox()
        {
            InitializeComponent();
        }

        //Events
        public event EventHandler _TextChanged;

        [Category("Özelleştirilmiş TextBox Ayarları")]
        public bool Multiline
        {
            get
            {
                return textBox1.Multiline;
            }
            set
            {
                textBox1.Multiline = value;
            }
        }
        //Properties
        [Category("Özelleştirilmiş TextBox Ayarları")]
        public Color BorderColor {
            get {
                return borderColor;
            }
            set {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("Özelleştirilmiş TextBox Ayarları")]
        public int BorderSize {
            get {
                return borderSize;
            }
            set {
                borderSize = value;
                this.Invalidate();
            }
        }
        [Category("Özelleştirilmiş TextBox Ayarları")]
        public bool UnderlinedStyle {
            get
            {
                return underlinedStyle;
            }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Özelleştirilmiş TextBox Ayarları")]
        public bool PasswordChar
        {
            get
            {
                return isPasswordChar;
            }
            set
            {
                isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value;
            }
        }

        //Overriden methods
        [Category("Özelleştirilmiş TextBox Ayarları")]
        public override Color BackColor {
            get {
                return base.BackColor;
            }
            set {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }
        [Category("Özelleştirilmiş TextBox Ayarları")]
        public override Color ForeColor {
            get {
                return base.ForeColor;
            }
            set {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("Özelleştirilmiş TextBox Ayarları")]
        public override Font Font {
            get => base.Font; set { base.Font = value; textBox1.Font = value; if (this.DesignMode) { UpdateControlHeight(); } }
        }

        //CustomTextBox'ın içerisindeki text alınmıyor
        /*
        [Category("Özelleştirilmiş TextBox Ayarları")]
        public string Text 
        {
            get => base.Font; set { base.Font = value; textBox1.Font = value; if (this.DesignMode) { UpdateControlHeight(); } }
        }
        */


        [Category("Özelleştirilmiş TextBox Ayarları")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                else return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
                SetPlaceHolder();
            }
        }

        /*
         public string Texts
            get return textBox1.Text;
            set textBox1.Text = value;
         
         */

        [Category("Özelleştirilmiş TextBox Ayarları")]
        public Color BorderFocusColor { get => borderFocusColor; set => borderFocusColor = value; }

        [Category("Özelleştirilmiş TextBox Ayarları")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set 
            { 
                if(value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
                
            } 
        }
        [Category("Özelleştirilmiş TextBox Ayarları")]
        public Color PlaceHolderColor {
            get
            {
               return placeHolderColor;
            }
            set
            {
                placeHolderColor = value;
                if (isPlaceholder)
                    textBox1.ForeColor = value;
            }
        }
        [Category("Özelleştirilmiş TextBox Ayarları")]
        public string PlaceholderText { 
            get => placeholderText;
            set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceHolder();
            }
        }

        private void SetPlaceHolder()
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeHolderColor;
                if(isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = false;
                }
            }
        }
        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = true;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if(borderRadius > 1) //Rounded TextBox
            {
                //Fields
                var rectBorderSmoth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmoth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmoth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius-borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //Drawing
                    this.Region = new Region(pathBorderSmooth); //Set the rounded region of usercontrol
                    if (borderRadius > 15) SetTextBoxRoundedRegion();
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (!isFocused)
                    {

                        if (underlinedStyle) //Line Style
                        {
                            //Draw border smoothing
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            //Draw border
                            graph.SmoothingMode = SmoothingMode.None;

                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        }
                        else //Normal Style
                        {
                            graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                            
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.DrawPath(penBorder, pathBorder);
                        }
                    }
                    else
                    {
                        penBorder.Color = borderFocusColor;

                        if (underlinedStyle) //Line Style
                        {
                            //Draw border smoothing
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            //Draw border
                            graph.SmoothingMode = SmoothingMode.None;

                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        }
                        else //Normal Style
                        {
                            graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);

                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.DrawPath(penBorder, pathBorder);
                        }
                    }
                }
            }
            else
            {
                //Draw border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    if (!isFocused)
                    {

                        if (underlinedStyle) //Line Style
                        {
                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        }
                        else //Normal Style
                        {
                            graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                        }
                    }
                    else
                    {
                        penBorder.Color = borderFocusColor;

                        if (underlinedStyle) //Line Style
                        {
                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        }
                        else //Normal Style
                        {
                            graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                        }
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
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        //Private Methods
        private void UpdateControlHeight()
        {
            if(textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceHolder();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Invalidate();
        }
    }
}
