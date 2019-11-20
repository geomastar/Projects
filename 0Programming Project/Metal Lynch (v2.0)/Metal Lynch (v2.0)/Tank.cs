using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metal_Lynch__v2._0_
{
    public class Tank : GameObject
    {
        private Rect tank_Rect;
        private TransformGroup tank_TransformGroup;
        private TranslateTransform tank_TranslateTransform;

        private BitmapImage tank_Sprite;

        private int tank_Health;

        public Tank(Game tank_Game, int health, int X, int Y)
        {
            game = tank_Game;
            //Sets the game variable of the base class to the parameter
            //tank_Game.            

            tank_Health = health;
            //Sets the health variable to the corresponding parameter.

            tank_TranslateTransform = new TranslateTransform(X, Y);
            //Instantiates the TranslateTransform object that will define
            //the location of the tank. Its coordinates are assigned by the
            //two integer parameters of the constructor.

            tank_TransformGroup = new TransformGroup();
            tank_TransformGroup.Children.Add(tank_TranslateTransform);
            //Instantiates the TransformGroup object and adds the
            //TranslateTransform to it.

            tank_Rect = new Rect(new Size(76, 35));
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

            tank_Sprite = new BitmapImage(new Uri(@"Resources/Tank sprite.png", UriKind.Relative));
            //Selects the image for the Tank's sprite.

            path = new Path()
            {
                Stroke = Brushes.Blue,
                Fill = new ImageBrush(tank_Sprite),
                StrokeThickness = 2,
                Data = geometry
                //Instantiates the Path object that will define the tank's
                //shape, size, location, stroke thickness and stroke colour.
                //Assigns the stroke colour as blue and thickness as 2.
                //Assigns the sprite to the tank_Sprite image.
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
        }

        public void MoveRight()
        {
            tank_TranslateTransform.X += 1;
            //Moves the Tank right on the canvas.
        }

        public int TakeDamage(Projectile projectile)
        {
            tank_Health = -projectile.GetProjectile_Damage();
            //Subtracts the damage of the projectile from the Tank's health.
            return projectile.GetProjectile_Damage();
            //Returns the damage of the projectile.
        }

        public TranslateTransform GetTank_TranslateTransform()
        {
            return tank_TranslateTransform;
            //Returns the Tank's TranslateTransform object.
        }
    }
}
