using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Security.Policy;

namespace CMS
{
    [DefaultEvent("_TextChanged")]
    public partial class RJTexbox : UserControl
    {
        //fields
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool ispocused = false;

        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isplaceholder = false;
        private bool ispasswordChar = false;



        public RJTexbox()
        {
            InitializeComponent();
        }
        //Event
        public event EventHandler _TextChanged;

        //propertices
        [Category(" RJ code Advance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;

            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category(" RJ code Advance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        [Category(" RJ code Advance")]
        public bool UnderlinedStyle
        {
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

        [Category(" RJ code Advance")]

        public bool PassWordChar
        {
            get
            {
                return ispasswordChar;
            }

            set
            {
                ispasswordChar = value;
                textBox1.UseSystemPasswordChar = value;
            }

        }
        [Category(" RJ code Advance")]
        public bool MultiLine
        {
            get { return textBox1.Multiline; }

            set { textBox1.Multiline = value; }

        }
        [Category(" RJ code Advance")]
        public override Color BackColor
        {
            get
            {

                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }
        [Category(" RJ code Advance")]
        public override Color ForeColor
        {
            get
            {

                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }
        [Category(" RJ code Advance")]
        public override Font Font
        {
            get
            {

                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    updateControlHeight();
            }
        }
        [Category(" RJ code Advance")]
        public string Texts
        {
            get
            {
                if (isplaceholder) return "";
                else return textBox1.Text;

            }
            set
            {
                textBox1.Text = value;
                setplaceholder();

            }
        }
        [Category(" RJ code Advance")]
        public Color BorderFocusColor
        {
            get
            {
                return borderFocusColor;
            }
            set
            {
                borderFocusColor = value;
            }
        }
        [Category(" RJ code Advance")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }
        [Category(" RJ code Advance")]
        public Color PlaceholderColor
        {
            get
            {
                return placeholderColor;
            }
            set
            {
                placeholderColor = value;
                if (ispasswordChar)
                    textBox1.ForeColor = value;
            }
        }
        [Category(" RJ code Advance")]
        public string PlaceholderText
        {
            get
            {
                return placeholderText;
            }
            set
            {
                placeholderText = value;
                textBox1.Text = "";
                setplaceholder();
            }
        }

        private void setplaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isplaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if (ispasswordChar)
                    textBox1.UseSystemPasswordChar = false;
            }
        }
        private void Removeplaceholder()
        {
            if (isplaceholder && placeholderText != "")
            {
                isplaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (ispasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }


        //overridden methodes
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            if (borderRadius > 1)//rounded texbox
            {
                //-Fields
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -BorderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBordersmooth = GetFigurepath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurepath(rectBorder, borderRadius - borderSize))
                using (Pen penBordersmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //-Drawing
                    this.Region = new Region(pathBordersmooth);//set th rounded reion userconrlolt
                    if (borderRadius > 15) setTextBoxRounded();////set th rounded reion of textbbox compnetes
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

                    if (ispocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle)//Line style
                    {
                        graph.DrawPath(penBordersmooth, pathBordersmooth);
                        //Draw border
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }

                    else//normal style
                    {
                        graph.DrawPath(penBordersmooth, pathBordersmooth);
                        graph.DrawPath(penBorder, pathBorder);
                    }

                }
            }
            else//squaren / normal textbox
            {
                //Draw border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (ispocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle)//Line style
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else//normal style
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }

            }
        }

        private void setTextBoxRounded()
        {
            GraphicsPath pathTxt;
            if (MultiLine)
            {
                pathTxt = GetFigurepath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurepath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);

            }
        }

        private GraphicsPath GetFigurepath(RectangleF rect, float radius)
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
            if (this.DesignMode)
                updateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            updateControlHeight();
        }
        /// prvate methode


        private void updateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int texHeight = TextRenderer.MeasureText("text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, texHeight);

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)

                _TextChanged.Invoke(sender, e);

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            ispocused = true;
            this.Invalidate();
            Removeplaceholder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ispocused =false;
            this.Invalidate();
            setplaceholder();
        }

        private void RJTexbox_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
