using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Metal_Lynch__v1._0_
{
    public class Game
    {
        private Window game_Window;
        private Canvas game_Canvas;
        private Canvas game_GUICanvas;

        private Map game_Map;
        private Tank game_Player;
        private Tank[] game_TankArray;
        private TankBarrier game_TankBarrierLeft;
        private TankBarrier game_TankBarrierRight;

        private int gravity;

        public Game(Window window, Canvas canvas, Canvas GUIcanvas)
        {
            game_Window = window;
            game_Canvas = canvas;
            game_GUICanvas = GUIcanvas;
            //Gives the Game object access to the window and canvases.

            game_Map = new Map(game_Canvas);
            //Instantiates the Map object.

            game_TankBarrierLeft = new TankBarrier(game_Canvas, 0);
            game_TankBarrierRight = new TankBarrier(game_Canvas, 400);
            //Instantiates the TankBarrier objects.

            game_Player = new Tank(game_Canvas, 100, 100);
            //Instantiates the Tank object.

            game_TankArray = new Tank[1] { game_Player };
            //Instantiates the Tank array and adds all the Tank objects to
            //the Tank array.

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

            IntersectionDetail playerTankBarrierRightIntersection =
                game_Player.GetTank_Path().Data.FillContainsWithDetail
                (game_TankBarrierRight.GetTankBarrier_Path().Data);
            IntersectionDetail playerTankBarrierLeftIntersection =
                game_Player.GetTank_Path().Data.FillContainsWithDetail
                (game_TankBarrierLeft.GetTankBarrier_Path().Data);
            //Assigns the results from hitbox tests between the Tank object
            //and TankBarrier objects to variables.

            if(playerTankBarrierRightIntersection ==
                IntersectionDetail.Intersects)
            {
                game_Player.MoveLeft();
                //Moves the player's Tank left if it is intersecting with
                //the TankBarrier object to its right.
            }
            if (playerTankBarrierLeftIntersection ==
                IntersectionDetail.Intersects)
            {
                game_Player.MoveRight();
                //Moves the player's Tank right if it is intersecting with
                //the TankBarrier object to its left.
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                game_Player.MoveLeft();
                //Moves the player's Tank object left if the 'A' key is
                //pressed down.
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                game_Player.MoveRight();
                //Moves the player's Tank object right if the 'D' key is
                //pressed down.
            }

            foreach (Tank tank in game_TankArray)
            {
                int i = gravity;
                //Assigns a temporary integer variable the value of gravity
                //for use as a decrement in the following while loop.
                bool intersectionFound = false;
                //Assigns a temporary Boolean variable the value false for
                //use as an argument in the following while loop.

                while (i > 0 & !intersectionFound)
                {
                    tank.MoveDown();

                    IntersectionDetail tankMapIntersection =
                        tank.GetTank_Path().Data.FillContainsWithDetail
                        (game_Map.GetMap_Path().Data);
                    //Assigns the results from a hitbox test between the
                    //Tank and the Map to a new variable.
                    
                    if(tankMapIntersection == IntersectionDetail.Intersects)
                    {
                        tank.MoveUp();
                        intersectionFound = true;
                        //Will stop the while loop if the tank intersects
                        //with the map, stopping gravity from pulling the
                        //tank through the map.
                    }

                    i--;
                    //Will move the tank down according to the value of
                    //gravity.
                }
                //This code is done for all Tank objects in the array.
            }
        }

        private void FireButtonClickEvent(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
