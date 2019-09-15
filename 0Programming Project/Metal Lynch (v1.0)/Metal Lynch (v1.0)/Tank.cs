using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metal_Lynch__v1._0_
{
    public class Tank
    {
        private Path tank_Path;
        private RectangleGeometry tank_RectangleGeometry;
        private Rect tank_Rect;
        private TransformGroup tank_TransformGroup;
        private TranslateTransform tank_TranslateTransform;

        private BitmapImage tank_Sprite;
        private ImageBrush tank_SpriteBrush;

        private int tank_Health;

        public Tank(Canvas Gamecanvas, int X, int Y)
        {
            tank_TranslateTransform = new TranslateTransform(X, Y);
            //Instantiates the TranslateTransform object that will define
            //the location of the tank. Its coordinates are assigned by the
            //two integer parameters of the constructor.

            tank_TransformGroup = new TransformGroup();
            tank_TransformGroup.Children.Add(tank_TranslateTransform);
            //Instantiates the TransformGroup object and adds the
            //TranslateTransform to it.

            tank_Rect = new Rect(new Size(30, 20));
            //Instantiates the Rect object that will define the tank's
            //size. Also defines the Rect's size as having dimensions
            //30x20.

            tank_RectangleGeometry = new RectangleGeometry()
            {
                Transform = tank_TransformGroup,
                Rect = tank_Rect
                //Instantiates the RectangleGeometry object that will define
                //the tank's shape, size and location. Assigns it the
                //TransformGroup and Rect objects instantiated earlier.
            };

            /*
            tank_Sprite = new BitmapImage(new Uri(@"Resources/Tank sprite.png", UriKind.Relative));
            tank_SpriteBrush = new ImageBrush(tank_Sprite);
            //Creates the Brush for the Sprite.
            */

            tank_Path = new Path()
            {
                Stroke = Brushes.Blue,
                Fill = tank_SpriteBrush,
                StrokeThickness = 2,
                Data = tank_RectangleGeometry
                //Instantiates the Path object that will define the tank's
                //shape, size, location, stroke thickness and stroke colour.
                //Assigns the stroke colour as blue and thickness as 2.
                //Assigns the RectangleGeometry object instantiated earlier
                //to the Path's data variable.
            };

            tank_Health = 0;
            //Sets the Tank's health to 0.

            Gamecanvas.Children.Add(tank_Path);
            //Adds the Tank's Path object to the Canvas.
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
            tank_Health =- projectile.GetProjectile_Damage();
            //Subtracts the damage of the projectile from the Tank's health.
            return projectile.GetProjectile_Damage();
            //Returns the damage of the projectile.
        }

        public Path GetTank_Path()
        {
            return tank_Path;
            //returns the Tank's Path object.
        }

        public int GetTank_Health()
        {
            return tank_Health;
            //Returns the Tank's health.
        }

        public TranslateTransform GetTank_TranslateTransform()
        {
            return tank_TranslateTransform;
        }
    }
}
