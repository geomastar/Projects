using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace deletepls
{
    public class box
    {
        private Rect hitBox;
        private Rectangle visualBox;
        
        public box(double x, double y, double width, double height)
        {
            hitBox = new Rect(x, y, width, height);
            visualBox = new Rectangle();
            Canvas.SetLeft(visualBox, x);
            Canvas.SetBottom(visualBox, y);
        }
    }
}
