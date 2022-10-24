using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace lab2prepPaint
{
    public partial class Form1 : Form
    {
        private Bitmap drawAreaBitmap;
        private Bitmap oldBitmap;
        private Bitmap dashedBitmap;
        private PictureBox oldPictureBox;
        private static Pen pen;

        private ComponentResourceManager resx;

        private bool usingBrush = false;
        private bool usingSquare = false;
        private bool usingEllipse = false;
        private bool drawing = false;
        private bool loadImage = false;
        private bool firstDashed = true;
        private bool changeLang = false;

        private int X = -1;
        private int Y = -1;
        private int radius = 1;
        public Form1()
        {
            resx = new ComponentResourceManager(GetType());
            CultureInfo.CurrentUICulture = new CultureInfo("en");

            InitializeComponent();

            pen = new Pen(Brushes.Black, radius);

            drawAreaBitmap = new Bitmap(drawArea.Size.Width, drawArea.Size.Height);
            oldBitmap = new Bitmap(drawArea.Size.Width, drawArea.Size.Height);
            drawArea.Image = drawAreaBitmap;

            FillColors();

            using (Graphics g = Graphics.FromImage(drawAreaBitmap))
            {
                g.Clear(Color.White);
            }

            thicknessComboBox.Text = "1";
            thicknessComboBox.Items.Add("1");
            thicknessComboBox.Items.Add("2");
            thicknessComboBox.Items.Add("3");

            toolStripButton6.BackColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void brushTool_Click_1(object sender, EventArgs e)
        {
            usingEllipse = false;
            usingSquare = false;

            ellipse.Checked = false;
            square.Checked = false;

            usingBrush = !usingBrush;
        }

        private void btnCLick_Event(object sender, EventArgs e)
        {
            if (!firstDashed)
            {
                using (Graphics g = Graphics.FromImage(dashedBitmap))
                {
                    g.Clear(oldPictureBox.BackColor);
                    oldPictureBox.Refresh();
                }
            }

            Pen dashedPen = new Pen(Color.Black, 5);
            dashedPen.DashPattern = new float[] { 0.5F, 0.5F };
            Color color = ((PictureBox)sender).BackColor;
            dashedPen.Color = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);

            dashedBitmap = new Bitmap(25, 25);

            ((PictureBox)sender).Image = dashedBitmap;

            using (Graphics g = Graphics.FromImage(dashedBitmap))
            {
                g.DrawRectangle(dashedPen, 0, 0, 25, 25);
                ((PictureBox)sender).Refresh();
            }

            firstDashed = false;

            oldPictureBox = (PictureBox)sender;
            toolStripButton6.BackColor = pen.Color = ((PictureBox)sender).BackColor;

            dashedPen.Dispose();
        }

        private void drawArea_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Button != MouseButtons.Left)
            {
                drawing = false;
                return;
            }
            
            drawing = true;
            X = e.X;
            Y = e.Y;

            if (new Regex(@"[1-3]").Matches(thicknessComboBox.Text).Count > 0 && thicknessComboBox.Text.Length < 2)
                pen.Width = int.Parse(thicknessComboBox.Text);

            if (usingSquare || usingEllipse)
            {
                oldBitmap.Dispose();
                oldBitmap = new Bitmap(drawAreaBitmap, drawAreaBitmap.Size.Width, drawAreaBitmap.Size.Height);
            }
        }

        private void drawArea_MouseMove_1(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
            if (drawing && X >= 0 && Y >= 0 && e.Button == MouseButtons.Left && e.Button != MouseButtons.Right)
            {
                if (usingBrush)
                {
                    using (Graphics g = Graphics.FromImage(drawAreaBitmap))
                    {
                        g.DrawLine(pen, new Point(X, Y), new Point(e.X, e.Y));
                        X = e.X;
                        Y = e.Y;
                    }
                    drawArea.Refresh();
                }
                else if (usingSquare)
                {
                    int width = drawAreaBitmap.Size.Width,
                        height = drawAreaBitmap.Size.Height;

                    drawAreaBitmap.Dispose();
                    drawAreaBitmap = new Bitmap(oldBitmap, width, height);
                    drawArea.Image.Dispose();
                    drawArea.Image = drawAreaBitmap;

                    oldBitmap.Dispose();
                    oldBitmap = new Bitmap(drawAreaBitmap, drawAreaBitmap.Size.Width, drawAreaBitmap.Size.Height);

                    using (Graphics g = Graphics.FromImage(drawAreaBitmap))
                    {
                        g.DrawRectangle(pen, new Rectangle(new Point(X > e.X ? e.X : X, Y > e.Y ? e.Y : Y), new Size(Math.Abs(e.X - X), Math.Abs(e.Y - Y))));
                    }

                    drawArea.Refresh();
                }
                else if (usingEllipse)
                {
                    int width = drawAreaBitmap.Size.Width,
                        height = drawAreaBitmap.Size.Height;

                    drawAreaBitmap.Dispose();
                    drawAreaBitmap = new Bitmap(oldBitmap, width, height);
                    drawArea.Image.Dispose();
                    drawArea.Image = drawAreaBitmap;

                    oldBitmap.Dispose();
                    oldBitmap = new Bitmap(drawAreaBitmap, drawAreaBitmap.Size.Width, drawAreaBitmap.Size.Height);

                    using (Graphics g = Graphics.FromImage(drawAreaBitmap))
                    {
                        g.DrawEllipse(pen, new Rectangle(new Point(X > e.X ? e.X : X, Y > e.Y ? e.Y : Y), new Size(Math.Abs(e.X - X), Math.Abs(e.Y - Y))));
                    }

                    drawArea.Refresh();
                }
            }
        }

        private void drawArea_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right && e.Button == MouseButtons.Left)
            {
                if (usingSquare && drawing)
                {
                    using (Graphics g = Graphics.FromImage(drawAreaBitmap))
                    {
                        g.DrawRectangle(pen, new Rectangle(new Point(X > e.X ? e.X : X, Y > e.Y ? e.Y : Y), new Size(Math.Abs(e.X - X), Math.Abs(e.Y - Y))));
                    }
                    drawArea.Refresh();
                }
                else if (usingEllipse && drawing)
                {
                    using (Graphics g = Graphics.FromImage(drawAreaBitmap))
                    {
                        g.DrawEllipse(pen, new Rectangle(new Point(X > e.X ? e.X : X, Y > e.Y ? e.Y : Y), new Size(Math.Abs(e.X - X), Math.Abs(e.Y - Y))));
                    }
                    drawArea.Refresh();
                }
            }

            drawing = false;

            X = -1;
            Y = -1;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void square_Click(object sender, EventArgs e)
        {
            usingBrush = false;
            usingEllipse = false;

            brushTool.Checked = false;
            ellipse.Checked = false;

            usingSquare = !usingSquare;
        }

        private void ellipse_Click(object sender, EventArgs e)
        {
            usingBrush = false;
            usingSquare = false;

            brushTool.Checked = false;
            square.Checked = false;

            usingEllipse = !usingEllipse;
        }

        private void trash_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(drawAreaBitmap))
            {
                g.Clear(Color.White);
                drawArea.Refresh();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "unnamed.jpg";
            save.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
            if (save.ShowDialog() == DialogResult.OK)
            {
                drawAreaBitmap.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            save.Dispose();
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Load file";
            fileDialog.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                loadImage = true;

                drawAreaBitmap.Dispose();
                drawAreaBitmap = (Bitmap)Image.FromFile(fileDialog.FileName);

                int width = drawAreaBitmap.Size.Width,
                        height = drawAreaBitmap.Size.Height;

                Bitmap prevImage = new Bitmap(drawAreaBitmap, width, height); 

                drawAreaBitmap.Dispose();
                drawAreaBitmap = new Bitmap(prevImage, width, height);

                Size = new Size(Math.Max(drawAreaBitmap.Size.Width + flowLayoutPanel.Size.Width, MinimumSize.Width),
                    Math.Max(MinimumSize.Height, drawAreaBitmap.Size.Height + toolStrip1.Size.Height));

                drawArea.Size = new Size(drawAreaBitmap.Size.Width, drawAreaBitmap.Size.Height);

                drawArea.BackColor = SystemColors.Control;
                drawArea.Image.Dispose();
                drawArea.Image = drawAreaBitmap;

                drawArea.Refresh();

                loadImage = false;

                prevImage.Dispose();
            }

            fileDialog.Dispose();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!loadImage && !changeLang)
            {
                Bitmap newBitmap = new Bitmap(drawArea.Size.Width, drawArea.Size.Height);

                using (Graphics graphics = Graphics.FromImage(newBitmap))
                {
                    graphics.Clear(Color.White);
                    graphics.DrawImage(drawAreaBitmap, 0, 0);
                }

                drawAreaBitmap.Dispose();
                drawAreaBitmap = newBitmap;

                drawArea.Image.Dispose();
                drawArea.Image = drawAreaBitmap;

                drawArea.Refresh();
            }
        }

        private void ResourceChanges(Control parent, CultureInfo culture)
        {
            resx.ApplyResources(parent, parent.Name, culture);
            parent.Invalidate();

            foreach(Control control in parent.Controls)
            {
                ResourceChanges(control, culture);
            }
        }

        private void english_Click(object sender, EventArgs e)
        {
            changeLang = true;

            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            RemoveColors();

            Size oldSize = Size;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            Controls.Clear();

            InitializeComponent();
            Size = oldSize;

            FillColors();

            toolStripButton6.BackColor = pen.Color;
            thicknessComboBox.Text = pen.Width.ToString();

            drawArea.Image = drawAreaBitmap;

            ControlBox = true;
            FormBorderStyle = FormBorderStyle.Sizable;

            changeLang = false;
        }

        private void polish_Click(object sender, EventArgs e)
        {
            changeLang = true;

            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            RemoveColors();

            Size oldSize = Size;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl-PL");
            Controls.Clear();

            InitializeComponent();
            Size = oldSize;

            FillColors();

            toolStripButton6.BackColor = pen.Color;
            thicknessComboBox.Text = pen.Width.ToString();

            drawArea.Image = drawAreaBitmap;

            ControlBox = true;
            FormBorderStyle = FormBorderStyle.Sizable;

            changeLang = false;
        }

        private void drawArea_Resize(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton6_Paint(object sender, PaintEventArgs e)
        {
            ToolStripButton ChooseColorButton = (ToolStripButton)sender;
            Rectangle rect = new Rectangle(0, 0, ChooseColorButton.Width, ChooseColorButton.Height);

            using(SolidBrush brush = new SolidBrush(ChooseColorButton.BackColor))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void FillColors()
        {
            foreach (KnownColor color in Enum.GetValues(typeof(KnownColor)))
            {
                PictureBox button = new PictureBox();
                button.BackColor = Color.FromKnownColor(color);
                button.Size = new Size(25, 25);
                button.Name = color.ToString();
                button.Click += new EventHandler(this.btnCLick_Event);
                flowLayoutPanel.Controls.Add(button);
            }
        }

        private void RemoveColors()
        {
            foreach (KnownColor color in Enum.GetValues(typeof(KnownColor)))
            {
                PictureBox button = new PictureBox();
                button.BackColor = Color.FromKnownColor(color);
                button.Size = new Size(25, 25);
                button.Name = color.ToString();
                button.Click += new EventHandler(this.btnCLick_Event);
                flowLayoutPanel.Controls.Remove(button);
            }
        }
    }
}
