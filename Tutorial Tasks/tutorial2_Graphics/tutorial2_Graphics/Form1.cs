using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tutorial2_Graphics
{
    public partial class Form1 : Form
    {
        private Bitmap drawArea;
        private Pen pen;
        private Pen dashedPen;
        private const int RADIUS = 10;
        public Form1()
        {
            InitializeComponent();
            drawArea = new Bitmap(Canvas.Size.Width, Canvas.Size.Height);
            Canvas.Image = drawArea;
            Graphics g = Graphics.FromImage(drawArea);
            g.Clear(Color.LightBlue);
            g.Dispose();

            pen = new Pen(Brushes.Black, 3);
            dashedPen = new Pen(Brushes.Black, 3);
            dashedPen.DashPattern = new float[] { 2, 1 };
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.FillEllipse(Brushes.White, e.X - RADIUS, e.Y - RADIUS, RADIUS * 2, RADIUS * 2);
                    g.DrawEllipse(pen, e.X - RADIUS, e.Y - RADIUS, RADIUS * 2, RADIUS * 2);
                }
                Canvas.Refresh();
            }
            if (e.Button == MouseButtons.Right)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.FillEllipse(Brushes.White, e.X - RADIUS, e.Y - RADIUS, RADIUS * 2, RADIUS * 2);
                    g.DrawEllipse(dashedPen, e.X - RADIUS, e.Y - RADIUS, RADIUS * 2, RADIUS * 2);
                }
                Canvas.Refresh();
            }
        }
    }
}
