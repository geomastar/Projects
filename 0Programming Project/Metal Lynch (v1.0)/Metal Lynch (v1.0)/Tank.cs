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
    public class Tank
    {
        private Path tank_Path;
        private RectangleGeometry tank_RectangleGeometry;
        private Rect tank_Rect;
        private TransformGroup tank_TransformGroup;
        private TranslateTransform tank_TranslateTransform;

        public Tank(Canvas canvas, int X, int Y)
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

            tank_Path = new Path()
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 2,
                Data = tank_RectangleGeometry
                //Instantiates the Path object that will define the tank's
                //shape, size, location, stroke thickness and stroke colour.
                //Assigns the stroke colour as blue and thickness as 2.
                //Assigns the RectangleGeometry object instantiated earlier
                //to the Path's data variable.
            };

            canvas.Children.Add(tank_Path);
            //Adds the Tank's Path object to the Canvas.
        }

        public void MoveDown()
        {
            tank_TranslateTransform.Y += 1;
            //Moves the Tank down on the canvas.
        }

        public Path GetTank_Path()
        {
            return tank_Path;
            //returns the Tank's Path object.
        }
    }
}
