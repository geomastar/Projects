using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        private Path tank_HitboxPath;
        private RectangleGeometry tank_HitboxRectangleGeometry;
        private Rect tank_HitboxRect;
        private TranslateTransform tank_HitboxPosition;

        public Tank(int X)
        {
            tank_Position = new TranslateTransform(X, 100);
            tank_HitboxPosition = new TranslateTransform(X-1, 99);

            tank_Rect = new Rect(new Size(30, 20));
            tank_HitboxRect = new Rect(new Size(32, 22));

            tank_RectangleGeoemtry = new RectangleGeometry()
            {
                Transform = tank_Position,
                Rect = tank_Rect
            };
            tank_HitboxRectangleGeometry = new RectangleGeometry()
            {
                Transform = tank_HitboxPosition,
                Rect = tank_HitboxRect
            };

            tank_Path = new Path()
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 2,
                Data = tank_RectangleGeoemtry
            };
            tank_HitboxPath = new Path()
            {
                Stroke = Brushes.Red,
                StrokeThickness = 1,
                Data = tank_HitboxRectangleGeometry
            };
        }

        public void AddToCanvas(Canvas gameCanvas)
        {
            gameCanvas.Children.Add(tank_Path);
            gameCanvas.Children.Add(tank_HitboxPath);
        }

        public void MoveTankDown()
        {
            tank_Position.Y += 1;
            tank_HitboxPosition.Y += 1;
        }

        public void MoveTankUp()
        {
            tank_Position.Y -= 1;
            tank_HitboxPosition.Y -= 1;
        }

        public void MoveTankLeft()
        {
            tank_Position.X -= 1;
            tank_HitboxPosition.X -= 1;
        }

        public void MoveTankRight()
        {
            tank_Position.X += 1;
            tank_HitboxPosition.X += 1;
        }

        public Path GetTank_Path(bool hitboxPath)
        {
            if(hitboxPath)
            {
                return tank_HitboxPath;
            }

            return tank_Path;
        }
    }
}
