using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Lab4
{
    public class HorizontalEffect : ISlideShowEffect
    {
        public string Name
        {
            get { return "Horizontal Effect"; }
        }
        public void Play(Image imageIn, Image imageOut, double windowWidth, double windowHeight)
        {
            imageIn.HorizontalAlignment = HorizontalAlignment.Right;
            imageOut.HorizontalAlignment = HorizontalAlignment.Left;

            Storyboard storyBoard1 = new Storyboard();
            Storyboard storyBoard2 = new Storyboard();

            DoubleAnimation doubleAnimation1 = new DoubleAnimation(0, windowWidth, new Duration(new TimeSpan(0, 0, 2)));
            Storyboard.SetTargetProperty(doubleAnimation1, new PropertyPath(FrameworkElement.WidthProperty));
            Storyboard.SetTarget(doubleAnimation1, imageIn);

            DoubleAnimation doubleAnimation2 = new DoubleAnimation(windowWidth, 0, new Duration(new TimeSpan(0, 0, 2)));
            Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(FrameworkElement.WidthProperty));
            Storyboard.SetTarget(doubleAnimation2, imageOut);

            storyBoard1.Children.Add(doubleAnimation1);
            storyBoard2.Children.Add(doubleAnimation2);

            storyBoard1.Begin();
            storyBoard2.Begin();
        }
    }
}
