using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace demo
{
    class Tank
    {
        private Path tank_Path;
        private RectangleGeometry tank_RectangleGeoemtry;
        private Rect tank_Rect;
        private TranslateTransform tank_Position;

        public Tank(int X)
        {
            tank_Position = new TranslateTransform(X, 100);

            tank_Rect = new Rect(new Size(30, 20));

            tank_RectangleGeoemtry = new RectangleGeometry()
            {
                Transform = tank_Position,
                Rect = tank_Rect
            };

            tank_Path = new Path()
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 2,
                Data = tank_RectangleGeoemtry
            };
        }

        public void MoveTankDown()
        {
            tank_Position.Y += 1;
        }

        public void MoveTankUp()
        {
            tank_Position.Y -= 1;
        }

        public void MoveTankLeft()
        {
            tank_Position.X -= 1;
        }

        public void MoveTankRight()
        {
            tank_Position.X += 1;
        }

        public Path GetTank_Path()
        {
            return tank_Path;
        }
    }
}
