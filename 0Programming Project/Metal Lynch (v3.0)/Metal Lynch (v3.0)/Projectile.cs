using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v3._0_
{
    public class Projectile : GameObject
    {
        private TransformGroup projectile_TransformGroup;
        private TranslateTransform projectile_TranslateTransform;

        private Point projectile_StartPoint;

        private double projectile_AngleRadians;
        private double projectile_InitialVelocity;
        private double projectile_Speed;
        private bool projectile_InMotion;
        private int projectile_Damage;
        private bool projectile_ForwardTrajectory;

        public Projectile(Game projectile_Game)
        {
            game = projectile_Game;
            //Sets the game variable of the base class to the parameter
            //projectile_Game.

            projectile_TranslateTransform = new TranslateTransform(20, 20);
            //Instantiates the TranslateTransform for the Projectile, defining
            //its location.

            projectile_TransformGroup = new TransformGroup();
            projectile_TransformGroup.Children.Add(projectile_TranslateTransform);
            //Instantiates the TransformGroup and adds the TranslateTransform
            //to it.

            geometry = new EllipseGeometry()
            {
                Transform = projectile_TransformGroup,
                RadiusX = 5,
                RadiusY = 5
                //Instantiates the EllipseGeometry and adds the TransformGroup
                //to it. Also defines the size of the ellipse.
            };

            path = new Path()
            {
                Stroke = Brushes.Red,
                Fill = Brushes.DarkRed,
                StrokeThickness = 2,
                Data = geometry
                //Instantiates the Path object for the Projectile and defines
                //its colour, thickness and adds the EllipseGeometry to it.
            };

            projectile_Speed = 0.1;
            //Sets the speed of the projectile.
            projectile_InMotion = false;
            //Instantiates the boolean value as false, as the projectile wont
            //be in motion as soon as the object is instantiated.
            projectile_Damage = 20;
            //Instantiates the base damage of the projectile.
        }

        public void MoveAlongTrajectory(int gravity)
        {
            if (projectile_ForwardTrajectory)
            {
                projectile_TranslateTransform.X++;
                //Increments the X value of the porjectile.
            }
            else
            {
                projectile_TranslateTransform.X--;
                //decrements the X value of the porjectile.
            }
            double X = projectile_TranslateTransform.X - projectile_StartPoint.X;
            //Calculates the difference between the X values of the start
            //point and the current position.
            double Y = (Math.Tan(projectile_AngleRadians) * X) -
                ((gravity * Math.Pow(X, 2)) /
                (2 * Math.Pow(projectile_InitialVelocity, 2) *
                Math.Pow(Math.Cos(projectile_AngleRadians), 2)));
            //Uses the trajectory formula to calculate the projectile's Y
            //value
            projectile_TranslateTransform.Y = projectile_StartPoint.Y - Y;
            //Sets the projectile's Y value to this newly calculated value.
        }

        public void SetAndStartTrajectory(Point startPoint, double angleRadians, double initialVelocity, bool forwardTrajectory)
        {
            projectile_StartPoint = startPoint;
            projectile_AngleRadians = angleRadians;
            projectile_InitialVelocity = initialVelocity;
            projectile_ForwardTrajectory = forwardTrajectory;
            //Sets the values for these four variables that will be used in
            //calculating the trajectory.

            projectile_TranslateTransform.X = projectile_StartPoint.X;
            projectile_TranslateTransform.Y = projectile_StartPoint.Y;
            //Moves the projectile to the start point.

            AddToCanvas();
            //Adds the Projectile's Path to the Canvas.

            projectile_InMotion = true;
            //Starts the trajectory.
        }

        public void StopTrajectory()
        {
            projectile_InMotion = false;
            //Stops the Projectile from moving along its trajectory.

            RemoveFromCanvas();
            //Removes the Projectile's Path from the Canvas.
        }

        public double GetXVelocity()
        {
            double XVelocity = Math.Cos(projectile_AngleRadians) *
                projectile_InitialVelocity;
            if (XVelocity < 0)
            {
                XVelocity *= -1;
            }
            if (XVelocity == 0)
            {
                //XVelocity++;
            }

            return XVelocity;
            //Calculates and returns the velocity of the projectile in the X
            //axis
        }

        public bool GetProjectile_InMotion()
        {
            return projectile_InMotion;
            //Returns the boolean that describes whether the projectile is in
            //motion.
        }

        public TranslateTransform GetProjectile_TranslateTransform()
        {
            return projectile_TranslateTransform;
            //Returns the TranslateTransform of the projectile.
        }

        public double GetProjectile_Speed()
        {
            return projectile_Speed;
            //Returns the speed modifier of the projectile.
        }

        public int GetProjectile_Damage()
        {
            return projectile_Damage;
            //Returns the damage of the projectile.
        }
    }
}
