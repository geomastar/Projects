using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace projectilePrototype
{
    class Projectile
    {
        Path projectile_Path = new Path();
        RectangleGeometry projectile_RectangleGeometry = new RectangleGeometry();
        Rect projectile_Rect = new Rect();
        Point projectile_Point = new Point();
        Point projectile_StartPoint = new Point();
        bool projectile_InMotion = false;
        double projectile_ChangeInX = 0;
        double projectile_ChangeInY = 0;
        double projectile_Angle;
        double projectile_InitialVelocity;
        double projectile_Gravity;

        public Projectile(double width, double height, double XPos, double YPos, double angle, double initialVelocity, double gravity)
        {
            CompositionTarget.Rendering += updateProjectileEvent;

            projectile_StartPoint.X = XPos;
            projectile_StartPoint.Y = YPos;

            projectile_Point.X = XPos;
            projectile_Point.Y = YPos;

            projectile_Rect.Location = projectile_Point;
            projectile_Rect.Size = new Size(width, height);

            projectile_RectangleGeometry.Rect = projectile_Rect;

            projectile_Path.Data = projectile_RectangleGeometry;
            projectile_Path.Stroke = Brushes.Black;
            projectile_Path.StrokeThickness = 2;

            projectile_Angle = angle;
            projectile_InitialVelocity = initialVelocity;
            projectile_Gravity = gravity;
        }

        private void updateProjectileEvent(object sender, EventArgs e)
        {
            if (projectile_InMotion)
            {
                projectile_ChangeInX -= 5;
                projectile_ChangeInY = calculateYPos(projectile_ChangeInX);

                projectile_Point.X = projectile_StartPoint.X + projectile_ChangeInX;
                projectile_Point.Y = projectile_StartPoint.Y - projectile_ChangeInY;

                projectile_Rect.Location = projectile_Point;
                projectile_RectangleGeometry.Rect = projectile_Rect;

                Debug.WriteLine(projectile_Rect.Y);
            }
        }

        private double calculateYPos(double X)
        {
            double angleRadians = (projectile_Angle * Math.PI) / 180;

            double Y = (Math.Tan(angleRadians) * X) - ((projectile_Gravity * Math.Pow(X, 2)) / (2 * Math.Pow(projectile_InitialVelocity, 2) * Math.Pow(Math.Cos(angleRadians), 2)));

            return Y;
        }

        public void SendProjectile()
        {
            projectile_InMotion = true;
        }

        public Path GetProjectile_Path()
        {
            return projectile_Path;
        }
    }
}
