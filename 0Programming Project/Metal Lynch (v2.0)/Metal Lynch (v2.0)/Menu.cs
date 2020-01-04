using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v2._0_
{
    public abstract class Menu
    {
        protected Framework menu_Framework;

        protected Canvas menu_Canvas;

        protected Path menu_BackgroundPath;
        protected RectangleGeometry menu_BackgroundRectangleGeometry;

        protected void AddToCanvas()
        {
            menu_Framework.GetFramework_Canvas().Children.Add(menu_Canvas);
            //Adds the Menu Canvas to the Canvas of the Framework.
        }

        protected void BaseConstructor(Framework framework, int width, int height)
        {
            menu_Framework = framework;
            //Assigns the framework parameter to the variable.

            menu_Canvas = new Canvas()
            {
                Height = menu_Framework.GetFramework_Canvas().Height,
                Width = menu_Framework.GetFramework_Canvas().Width
                //Creates the instance of Canvas. Gives it the same height
                //and width as the Framework Canvas.
            };

            menu_BackgroundRectangleGeometry = new RectangleGeometry()
            {
                Rect = new Rect(new Size(width, height)),
                Transform = new TranslateTransform(640 - (width / 2), 30)
                //Instantiates the RectangleGeometry, giving it a size and
                //a location.
            };

            menu_BackgroundPath = new Path()
            {
                Data = menu_BackgroundRectangleGeometry,
                Fill = new SolidColorBrush()
                {
                    Color = Colors.Gray,
                    Opacity = 0.5
                },
                Stroke = Brushes.Black,
                StrokeThickness = 2
                //Instantiates the Path object, giving it a Geometry, colour,
                //and stroke.
            };
            menu_Canvas.Children.Add(menu_BackgroundPath);
            //Adds the Path to the Menu Canvas.
        }

        public Canvas GetMenu_Canvas()
        {
            return menu_Canvas;
            //Returns the Grid.
        }
    }
}
