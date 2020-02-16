using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v3._0_
{
    public abstract class Projectile : GameObject
    {
        protected TransformGroup projectile_TransformGroup;
        protected TranslateTransform projectile_TranslateTransform;

        protected Point projectile_StartPoint;

        protected double projectile_AngleRadians;
        protected double projectile_InitialVelocity;
        protected double projectile_Speed;
        protected bool projectile_InMotion;
        protected int projectile_Damage;
        protected int projectile_Time;

        public virtual int Impact(Tank currentPlayer, Tank[] enemyTankArray) { return 0; }

        public void BaseConstructor(Game projectile_Game)
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

            projectile_Speed = 0.1;
            //Sets the speed of the projectile.
            projectile_InMotion = false;
            //Instantiates the boolean value as false, as the projectile wont
            //be in motion as soon as the object is instantiated.
        }

        public virtual void MoveAlongTrajectory(int gravity)
        {
            double realTime = projectile_Time * projectile_Speed;

            double x = CalculateX(realTime);
            double y = CalculateY(gravity, realTime);

            projectile_TranslateTransform.X = projectile_StartPoint.X + x;
            projectile_TranslateTransform.Y = projectile_StartPoint.Y - y;

            projectile_Time++;
        }

        public virtual double CalculateX(double time)
        {
            return (projectile_InitialVelocity * time * Math.Cos(projectile_AngleRadians));
        }
        public virtual double CalculateY(int gravity, double time)
        {
            return projectile_InitialVelocity * time * Math.Sin(projectile_AngleRadians)
                - (0.5 * gravity * Math.Pow(time, 2));
        }

        public void SetAndStartTrajectory(Point startPoint, double angleRadians, double initialVelocity)
        {
            projectile_StartPoint = startPoint;
            projectile_AngleRadians = angleRadians;
            projectile_InitialVelocity = initialVelocity;
            projectile_Time = 0;
            //Sets the values for these three variables that will be used in
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
