using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metal_Lynch__v3._0_
{
    public class Tank : GameObject
    {
        private Rect tank_Rect;
        private TransformGroup tank_TransformGroup;
        private TranslateTransform tank_TranslateTransform;
        private RotateTransform tank_RotateTransform;

        private BitmapImage tank_Sprite;
        private ScaleTransform tankSprite_ScaleTransform;

        private Point tank_IconPos;

        private int tank_Health;
        private int tank_MaxFuel;
        private int tank_Fuel;

        private string tank_Username;
        private int tank_DamageDealt;
        private int tank_DamageTaken;
        private int tank_DistanceTravelled;
        private int tank_ProjectilesFired;

        public Tank(Game tank_Game, string username, int health, int fuel, int X, int Y)
        {
            game = tank_Game;
            //Sets the game variable of the base class to the parameter
            //tank_Game.

            tank_Username = username;
            //Sets the username variable to the corresponding parameter.

            tank_Health = health;
            //Sets the health variable to the corresponding parameter.
            tank_MaxFuel = fuel; tank_Fuel = fuel;
            //Sets the fuel variables to their corresponding parameter.

            tank_TranslateTransform = new TranslateTransform(X, Y);
            //Instantiates the TranslateTransform object that will define
            //the location of the tank. Its coordinates are assigned by the
            //two integer parameters of the constructor.
            tank_RotateTransform = new RotateTransform(0, tank_TranslateTransform.X, tank_TranslateTransform.Y);

            tank_TransformGroup = new TransformGroup();
            tank_TransformGroup.Children.Add(tank_TranslateTransform);
            tank_TransformGroup.Children.Add(tank_RotateTransform);
            //Instantiates the TransformGroup object and adds the
            //TranslateTransform to it.

            tank_Rect = new Rect(new Size(78, 35.75));
            //Instantiates the Rect object that will define the tank's
            //size. Also defines the Rect's size as having dimensions
            //30x20.

            geometry = new RectangleGeometry()
            {
                Transform = tank_TransformGroup,
                Rect = tank_Rect
                //Instantiates the geometry object that will define
                //the tank's shape, size and location. Assigns it the
                //TransformGroup and Rect objects instantiated earlier.
            };

            tankSprite_ScaleTransform = new ScaleTransform();
            if (X < 640)
            {
                tankSprite_ScaleTransform.ScaleX = -1;
            }
            //Instantiates the ScaleTransform for the sprite and flips the
            //sprite in the Y-axes if it is to the left of the middle of the
            //screen. This way the tanks will be facing each other.

            tank_Sprite = new BitmapImage(
                new Uri(@"Resources/Tank sprite.png", UriKind.Relative));
            //Selects the image for the Tank's sprite and assigns the
            //ScaleTransform to the image.

            path = new Path()
            {
                Stroke = Brushes.Blue,
                Fill = new ImageBrush(new TransformedBitmap(
                    tank_Sprite, tankSprite_ScaleTransform)),
                StrokeThickness = 2,
                Data = geometry
                //Instantiates the Path object that will define the tank's
                //shape, size, location, stroke thickness and stroke colour.
                //Assigns the stroke colour as blue and thickness as 2.
                //Assigns the sprite to the tank_Sprite image and assigns the
                //ScaleTransform to the image.
                //Assigns the RectangleGeometry object instantiated earlier
                //to the Path's data variable.
            };

            AddToCanvas();
            //Adds the Path to the Canvas of the Game that it belongs to.
        }

        public void MoveUp()
        {
            tank_TranslateTransform.Y -= 1;
            //Moves the Tank up on the canvas.
        }
        public void MoveDown()
        {
            tank_TranslateTransform.Y += 1;
            //Moves the Tank down on the canvas.
        }
        public void MoveLeft()
        {
            tank_TranslateTransform.X -= 1;
            //Moves the Tank left on the canvas.
            tank_Fuel -= 1;
            //Decrements the fuel value.
            tank_DistanceTravelled += 1;
            //Increments the distance travelled stat.
        }
        public void MoveRight()
        {
            tank_TranslateTransform.X += 1;
            //Moves the Tank right on the canvas.
            tank_Fuel -= 1;
            //Decrements the fuel value.
            tank_DistanceTravelled += 1;
            //Increments the distance travelled stat.
        }

        public void FireProjectile()
        {
            tank_ProjectilesFired++;
            //Increments the projectiles fired stat.
        }
        public void DealDamage(Projectile projectile)
        {
            tank_DamageDealt += projectile.GetProjectile_Damage();
            //Adds the damage of the projectile to the Tank's damage dealt stat.
        }
        public int TakeDamage(Projectile projectile)
        {
            tank_Health -= projectile.GetProjectile_Damage();
            //Subtracts the damage of the projectile from the Tank's health.
            tank_DamageTaken += projectile.GetProjectile_Damage();
            //Adds the damage of the projectile to the Tank's damage taken stat.
            return projectile.GetProjectile_Damage();
            //Returns the damage of the projectile.
        }

        public int GetTank_Health()
        {
            return tank_Health;
            //Returns the health value.
        }

        public int GetTank_Fuel()
        {
            return tank_Fuel;
            //Returns the fuel value.
        }
        public void ResetFuel()
        {
            tank_Fuel = tank_MaxFuel;
            //Resets the fuel value.
        }
        public void IncrementFuel()
        {
            tank_Fuel++;
            //Increments the fuel value.
        }
        public void DecrementDistanceTravelled()
        {
            tank_DistanceTravelled -= 1;
            //Decrements the distance travelled stat.
        }

        public void SetTank_IconPos(Point point)
        {
            tank_IconPos = point;
            //Sets the icon position.
        }
        public Point GetTank_IconPos()
        {
            return tank_IconPos;
            //Returns the position of the aiming icon.
        }

        public TranslateTransform GetTank_TranslateTransform()
        {
            return tank_TranslateTransform;
            //Returns the Tank's TranslateTransform object.
        }

        public void SetTank_RotateTransformAngle(double angle)
        {
            tank_RotateTransform.CenterX = tank_TranslateTransform.X + (78/2);
            tank_RotateTransform.CenterY = tank_TranslateTransform.Y + (35.75/2);
            tank_RotateTransform.Angle = angle;

            path.Fill.Transform = tank_RotateTransform;
        }

        public void SetTank_Username(string username)
        {
            tank_Username = username;
            //Sets the username.
        }
        public string GetTank_Username()
        {
            return tank_Username;
            //Returns the username.
        }

        public int GetTank_DamageDealt()
        {
            return tank_DamageDealt;
            //Returns the damage dealt stat.
        }

        public int GetTank_DamageTaken()
        {
            return tank_DamageTaken;
            //Returns the damage taken stat.
        }

        public int GetTank_DistanceTravelled()
        {
            return tank_DistanceTravelled;
            //Returns the distance travelled stat.
        }

        public int GetTank_ProjectilesFired()
        {
            return tank_ProjectilesFired;
            //Returns the projectiles fired stat.
        }
    }
}
