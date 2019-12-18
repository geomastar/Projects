using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Metal_Lynch__v2._0_
{
    public class _1v1 : Game
    {        
        private Tank _1v1_Player1;
        private Tank _1v1_Player2;

        protected int game_CentreBoundary;

        public _1v1(Framework framework)
        {
            game_Framework = framework;

            BaseConstructor(game_Framework);

            _1v1_Player1 = new Tank(this, 0, 320, 100);
            _1v1_Player2 = new Tank(this, 0, 900, 100);

            game_TankArray = new Tank[2] { _1v1_Player1, _1v1_Player2 };

            foreach(Tank tank in game_TankArray)
            {
                tank.SetTank_IconPos(game_AimingIcon.GetAimingIcon_Centre());
            }

            game_CentreBoundary = 640;

            CompositionTarget.Rendering += UpdateEvent;

            AddToCanvas();
            //Adds the Grid to the Canvas of the Framework.
        }

        private void UpdateEvent(object sender, EventArgs e)
        {
            game_CurrentPlayer = game_TankArray[(game_Turn-1) % 2];
            //Determines the player who's turn it is.

            if (game_NewTurn)
            {
                if (game_DemoMode)
                {
                    if (game_CurrentPlayer == game_TankArray[0])
                    {
                        game_NextMinX = 100;
                        game_NextMaxX = 500;
                        game_AngleDirection = true;
                    }
                    else
                    {
                        game_NextMinX = 704;
                        game_NextMaxX = 1104;
                        game_AngleDirection = false;
                    }
                    GenerateRandomXLoc();
                    //Changes the variables that determine how the tanks
                    //automatically move while in demo mode, in order to
                    //accomodate for the fact that the different tanks need to
                    //shoot in different directions and move to different
                    //locations.
                }

                game_AimingIcon.SetIconPos(game_CurrentPlayer.GetTank_IconPos());
                //Sets the icon position of the Tank to the icon position of the AimingIcon object.

                game_NewTurn = false;
            }

            foreach (Tank tank in game_TankArray)
            {
                if (tank == game_TankArray[0])
                {
                    if (tank.GetTank_TranslateTransform().X + 76 > game_CentreBoundary) { tank.MoveLeft(); }
                }
                else
                {
                    if (tank.GetTank_TranslateTransform().X < game_CentreBoundary) { tank.MoveRight(); }
                }
                //Keeps the tanks to their sides of the map.
            }

            BaseUpdateEvent(new Tank[1] { game_TankArray[game_Turn % 2] });
        }
    }
}
