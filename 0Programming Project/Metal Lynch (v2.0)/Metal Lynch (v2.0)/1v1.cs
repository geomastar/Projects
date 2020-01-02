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

        private ProgressBar _1v1_Player1HealthBar;
        private ProgressBar _1v1_Player2HealthBar;

        private ProgressBar _1v1_FuelBar;

        protected int _1v1_CentreBoundary;

        public _1v1(Framework framework, bool demoMode)
        {
            game_Framework = framework;

            BaseConstructor(game_Framework, demoMode);

            _1v1_Player1 = new Tank(this, 100, 100, 320, 100);
            _1v1_Player2 = new Tank(this, 100, 100, 900, 100);

            game_TankArray = new Tank[2] { _1v1_Player1, _1v1_Player2 };

            foreach(Tank tank in game_TankArray)
            {
                tank.SetTank_IconPos(game_AimingIcon.GetAimingIcon_Centre());
            }

            _1v1_Player1HealthBar = new ProgressBar(this, 1000, 50, 20,
                "Player1", true, _1v1_Player1.GetTank_Health());
            _1v1_Player2HealthBar = new ProgressBar(this, 1000, 100, 20,
                "Player2", true, _1v1_Player2.GetTank_Health());

            _1v1_FuelBar = new ProgressBar(this, 730, 175, 15,
                "Fuel", false, game_TankArray[0].GetTank_Fuel());

            _1v1_CentreBoundary = 640;

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
                    if (tank.GetTank_TranslateTransform().X + 76 > _1v1_CentreBoundary)
                    {
                        tank.MoveLeft();
                        tank.IncrementFuel(); tank.IncrementFuel();
                    }
                }
                else
                {
                    if (tank.GetTank_TranslateTransform().X < _1v1_CentreBoundary)
                    {
                        tank.MoveRight();
                        tank.IncrementFuel(); tank.IncrementFuel();
                    }
                }
                //Keeps the tanks to their sides of the map.
            }

            BaseUpdateEvent(new Tank[1] { game_TankArray[game_Turn % 2] });

            _1v1_Player1HealthBar.Update(_1v1_Player1.GetTank_Health());
            _1v1_Player2HealthBar.Update(_1v1_Player2.GetTank_Health());
            _1v1_FuelBar.Update(game_CurrentPlayer.GetTank_Fuel());
        }

        public override void AssignUsernames(string player1Username, string player2Username)
        {
            _1v1_Player1HealthBar.SetProgressBar_LabelText(player1Username);
            _1v1_Player2HealthBar.SetProgressBar_LabelText(player2Username);
        }
    }
}
