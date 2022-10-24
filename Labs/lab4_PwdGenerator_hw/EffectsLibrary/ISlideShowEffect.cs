using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Lab4
{
    public interface ISlideShowEffect
    {
        string Name { get; }
        void Play(Image imageIn, Image imageOut, double windowWidth, double windowHeight);
    }
}
