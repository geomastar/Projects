using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v1._0_
{
    public class Projectile
    {
        private Path projectile_Path;
        private EllipseGeometry projectile_EllipseGeometry;
        private TransformGroup projectile_TransformGroup;
        private TranslateTransform projectile_TranslateTransform;

        private Point projectile_StartPoint;

        private double projectile_AngleRadians;
        private double projectile_InitialVelocity;
        private bool projectile_InMotion;

        public Projectile(Canvas Gamecanvas)
        {
            projectile_TranslateTransform = new TranslateTransform(20, 20);
            //Instantiates the TranslateTransform for the Projectile, defining
            //its location.

            projectile_TransformGroup = new TransformGroup();
            projectile_TransformGroup.Children.Add(projectile_TranslateTransform);
            //Instantiates the TransformGroup and adds the TranslateTransform
            //to it.

            projectile_EllipseGeometry = new EllipseGeometry()
            {
                Transform = projectile_TransformGroup,
                RadiusX = 5,
                RadiusY = 5
                //Instantiates the EllipseGeometry and adds the TransformGroup
                //to it. Also defines the size of the ellipse.
            };

            projectile_Path = new Path()
            {
                Stroke = Brushes.Red,
                Fill = Brushes.DarkRed,
                StrokeThickness = 2,
                Data = projectile_EllipseGeometry
                //Instantiates the Path object for the Projectile and defines
                //its colour, thickness and adds the EllipseGeometry to it.
            };

            projectile_InMotion = false;

            Gamecanvas.Children.Add(projectile_Path);
            //Adds the Projectile's Path to the Canvas.
        }

        public void MoveAlongTrajectory(int gravity)
        {
            projectile_TranslateTransform.X++;

            double X = projectile_TranslateTransform.X - projectile_StartPoint.X;

            double Y = (Math.Tan(projectile_AngleRadians) * X) - ((gravity * Math.Pow(X, 2)) / (2 * Math.Pow(projectile_InitialVelocity, 2) * Math.Pow(Math.Cos(projectile_AngleRadians), 2)));

            projectile_TranslateTransform.Y = Y;
        }

        public void SetAndStartTrajectory(Point startPoint, double angleRadians, double initialVelocity)
        {
            projectile_StartPoint = startPoint;
            projectile_AngleRadians = angleRadians;
            projectile_InitialVelocity = initialVelocity;

            projectile_TranslateTransform.X = projectile_StartPoint.X;
            projectile_TranslateTransform.Y = projectile_StartPoint.Y;

            projectile_InMotion = true;
        }

        public bool GetProjectile_InMotion()
        {
            return projectile_InMotion;
        }

        public TranslateTransform GetProjectile_TranslateTransform()
        {
            return projectile_TranslateTransform;
        }


    }
}
