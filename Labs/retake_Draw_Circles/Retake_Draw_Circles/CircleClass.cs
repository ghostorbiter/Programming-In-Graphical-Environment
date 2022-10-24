using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retake_Draw_Circles
{
    public class CircleClass
    {
        public int radius { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int thickness { get; set; }

        public CircleClass(int r, int X, int Y, int t)
        {
            radius = r;
            posX = X;
            posY = Y;
            thickness = t;
        }
        public CircleClass()
        {
            radius = 0;
            posX = 0;
            posY = 0;
            thickness = 0;
        }
    }
}
