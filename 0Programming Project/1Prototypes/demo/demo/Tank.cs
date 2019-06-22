using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private TransformGroup tank_TransformGroup;
        private TranslateTransform tank_Translation;
        private RotateTransform tank_Rotation;

        private Path tank_HitboxPath;
        private RectangleGeometry tank_HitboxRectangleGeometry;
        private Rect tank_HitboxRect;
        private TransformGroup tank_HitboxTransformGroup;
        private TranslateTransform tank_HitboxTranslation;
        private RotateTransform tank_HitboxRotation;

        public Tank(int X)
        {
            tank_Rotation = new RotateTransform(0);
            tank_HitboxRotation = new RotateTransform(0);

            tank_Translation = new TranslateTransform(X, 100);
            tank_HitboxTranslation = new TranslateTransform(X-1, 99);

            tank_TransformGroup = new TransformGroup();
            tank_TransformGroup.Children.Add(tank_Rotation);
            tank_TransformGroup.Children.Add(tank_Translation);

            tank_HitboxTransformGroup = new TransformGroup();
            tank_HitboxTransformGroup.Children.Add(tank_HitboxRotation);
            tank_HitboxTransformGroup.Children.Add(tank_HitboxTranslation);

            tank_Rect = new Rect(new Size(30, 20));
            tank_HitboxRect = new Rect(new Size(32, 22));

            tank_RectangleGeoemtry = new RectangleGeometry()
            {
                Transform = tank_TransformGroup,                
                Rect = tank_Rect
            };
            tank_HitboxRectangleGeometry = new RectangleGeometry()
            {
                Transform = tank_HitboxTransformGroup,
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

        public void ChangeAngle(Point point1)
        {
            double X1 = point1.X;
            double Y1 = point1.Y;

            double X2 = tank_Translation.X;
            double Y2 = tank_Translation.Y;

            double angle = Math.Atan(Math.Abs((Y1-Y2)/(X1-X2)));

            bool right = false;
            bool up = false;

            if(Y2 < Y1)
            {
                up = true;
            }
            if(X2 > X1)
            {
                right = true;
            }

            if(right == up)
            {
                angle = angle * -1;
            }

            tank_Rotation.Angle = angle;
            tank_HitboxRotation.Angle = angle;

            Debug.WriteLine(Y1);
            Debug.WriteLine(Y2);

            //aint workin bruv
        }

        public void MoveTankDown()
        {
            tank_Translation.Y += 1;
            tank_HitboxTranslation.Y += 1;
        }

        public void MoveTankUp()
        {
            tank_Translation.Y -= 1;
            tank_HitboxTranslation.Y -= 1;
        }

        public void MoveTankLeft()
        {
            tank_Translation.X -= 1;
            tank_HitboxTranslation.X -= 1;
        }

        public void MoveTankRight()
        {
            tank_Translation.X += 1;
            tank_HitboxTranslation.X += 1;
        }

        public Path GetTank_Path(bool hitboxPath)
        {
            if(hitboxPath)
            {
                return tank_HitboxPath;
            }

            return tank_Path;
        }

        public Point GetTankPosition()
        {
            return new Point(tank_Translation.X, tank_Translation.Y);
        }
    }
}
