using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Metal_Lynch__v2._0_
{
    public class Framework
    {
        private Window framework_Window;
        private Canvas framework_Canvas;

        private Game framework_Game;
        private Menu framework_Menu;

        public Framework(Window window)
        {
            framework_Window = window;
            //Gives the Framework class access to the Window.

            framework_Canvas = new Canvas()
            {
                Height = window.Height,
                Width = window.Width
                //Creates the instance of Canvas where every graphical object
                //will be encapsulated. Gives it the same height and width as
                //the window.
            };

            framework_Game = new _1v1(this);

            framework_Menu = new MainMenu(this);

            framework_Window.Content = framework_Canvas;
            //Adds the Canvas to the Window.
        }

        public Canvas GetFramework_Canvas()
        {
            return framework_Canvas;
            //Returns the Canvas.
        }
    }
}
