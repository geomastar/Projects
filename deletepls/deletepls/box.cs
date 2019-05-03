using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace deletepls
{
    public class box
    {
        private double x;
        private double y;
        private Rect hitBox;
        private Rectangle visualBox;
        
        public box(double xCord, double yCord, double width, double height)
        {
            x = xCord;
            y = yCord;
            hitBox = new Rect(x, y, width, height);
            visualBox = new Rectangle();
            Canvas.SetLeft(visualBox, x);
            Canvas.SetBottom(visualBox, y);
            visualBox.Width = width;
            visualBox.Height = height;
            visualBox.Fill = Brushes.Black;
        }

        public bool checkIntersect(Rect target)
        {
            if(hitBox.IntersectsWith(target))
            {
                return true;
            }
            return false;
        }

        public Rectangle getVisualBox()
        {
            return visualBox;
        }

        public Rect getHitBox()
        {
            return hitBox;
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public void setX(double xCord)
        {
            x = xCord;
            hitBox.X = x;
            Canvas.SetLeft(visualBox, x);
        }

        public void setY(double yCord)
        {
            y = yCord;
            hitBox.Y = y;
            Canvas.SetBottom(visualBox, y);
        }        
    }
}
