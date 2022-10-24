using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tutorial2_Gallery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void galleryLayoutpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                galleryLayoutpanel.GetControlFromPosition(1, 1).BackColor = cd.Color;
                galleryLayoutpanel.GetControlFromPosition(0, 1).BackColor = cd.Color;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image file (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                galleryLayoutpanel.GetControlFromPosition(0, 0).BackgroundImage = new Bitmap(fd.FileName);
                galleryLayoutpanel.GetControlFromPosition(0, 0).BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
    }
}
