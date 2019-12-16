using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        protected void BaseConstructor(Framework framework)
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
        }
    }
}
