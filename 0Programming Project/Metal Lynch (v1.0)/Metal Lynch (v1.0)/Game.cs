using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Metal_Lynch__v1._0_
{
    class Game
    {
        private Window game_Window;
        private Canvas game_Canvas;
        private Tank game_Player;

        public Game(Window window, Canvas canvas)
        {
            game_Window = window;
            game_Canvas = canvas;
            //Gives the Game object access to the window and canvas.

            game_Player = new Tank(game_Canvas, 100, 100);
            //Instantiates the tank object.
        }
    }
}
