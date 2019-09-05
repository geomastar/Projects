using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Metal_Lynch__v1._0_
{
    public class Game
    {
        private Window game_Window;
        private Canvas game_Canvas;
        private Tank game_Player;

        private int gravity;

        public Game(Window window, Canvas canvas)
        {
            game_Window = window;
            game_Canvas = canvas;
            //Gives the Game object access to the window and canvas.

            game_Player = new Tank(game_Canvas, 100, 100);
            //Instantiates the tank object.

            gravity = 10;
            //Sets gravity to the default acceleration of 10.

            CompositionTarget.Rendering += UpdateEvent;
            //Adds the UpdateEvent method to the Rendering event that fires
            //every time a frame is rendered.
        }

        private void UpdateEvent(object sender, EventArgs e)
        {
            //This is the method that will run every time a new frame is
            //rendered, and so will be used to update the game.
            
            int i = gravity;
            //Creates a temporary integer variable to the value of gravity for
            //use as a decrement in the following while loop.
            while(i > 0)
            {
                game_Player.MoveDown();
                i--;
                //Will move the player tank down according to the value of
                //gravity
            }
        }
    }
}
