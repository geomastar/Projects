using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Metal_Lynch__v3._0_
{
    public class _4PlayerFFA : Game
    {
        private Tank _4PlayerFFA_Player1;
        private Tank _4PlayerFFA_Player2;
        private Tank _4PlayerFFA_Player3;
        private Tank _4PlayerFFA_Player4;

        private ProgressBar _4PlayerFFA_Player1HealthBar;
        private ProgressBar _4PlayerFFA_Player2HealthBar;
        private ProgressBar _4PlayerFFA_Player3HealthBar;
        private ProgressBar _4PlayerFFA_Player4HealthBar;

        private ProgressBar _4PlayerFFA_FuelBar;

        public _4PlayerFFA(Framework framework, bool demoMode, Framework.MapData mapData)
        {
            game_Framework = framework;

            BaseConstructor(game_Framework, demoMode, mapData);

            _4PlayerFFA_Player1 = new Tank(this, "Player1", 100, 100, 200, 100);
            _4PlayerFFA_Player2 = new Tank(this, "Player2", 100, 100, 450, 100);
            _4PlayerFFA_Player3 = new Tank(this, "Player3", 100, 100, 750, 100);
            _4PlayerFFA_Player4 = new Tank(this, "Player4", 100, 100, 1000, 100);

            game_TankArray = new Tank[4]
            {
                _4PlayerFFA_Player1,
                _4PlayerFFA_Player2,
                _4PlayerFFA_Player3,
                _4PlayerFFA_Player4
            };

            foreach (Tank tank in game_TankArray)
            {
                tank.SetTank_IconPos(game_AimingIcon.GetAimingIcon_Centre());
            }

            _4PlayerFFA_Player1HealthBar = new ProgressBar(this, 1000, 30, 20,
                "Player1", true, _4PlayerFFA_Player1.GetTank_Health());
            _4PlayerFFA_Player2HealthBar = new ProgressBar(this, 1000, 80, 20,
                "Player2", true, _4PlayerFFA_Player2.GetTank_Health());
            _4PlayerFFA_Player3HealthBar = new ProgressBar(this, 1000, 130, 20,
                "Player3", true, _4PlayerFFA_Player3.GetTank_Health());
            _4PlayerFFA_Player4HealthBar = new ProgressBar(this, 1000, 180, 20,
                "Player4", true, _4PlayerFFA_Player4.GetTank_Health());

            _4PlayerFFA_FuelBar = new ProgressBar(this, 730, 175, 15,
                "Fuel", false, game_TankArray[0].GetTank_Fuel());

            CompositionTarget.Rendering += UpdateEvent;

            AddToCanvas();
            //Adds the Grid to the Canvas of the Framework.
        }

        protected override void UpdateEvent(object sender, EventArgs e)
        {
            game_CurrentPlayer = game_TankArray[(game_Turn - 1) % game_TankArray.Length];
            //Determines the player who's turn it is.
            Debug.WriteLine(game_CurrentPlayer.GetTank_Username());

            if (game_NewTurn)
            {
                if (game_DemoMode)
                {
                    if (game_CurrentPlayer == game_TankArray[0])
                    {
                        game_NextMinX = 100;
                        game_NextMaxX = 300;
                        game_AngleDirection = true;
                    }
                    else if (game_CurrentPlayer == game_TankArray[1])
                    {
                        game_NextMinX = 350;
                        game_NextMaxX = 550;
                        game_AngleDirection = true;
                    }
                    else if (game_CurrentPlayer == game_TankArray[2])
                    {
                        game_NextMinX = 650;
                        game_NextMaxX = 850;
                        game_AngleDirection = false;
                    }
                    else if (game_CurrentPlayer == game_TankArray[3])
                    {
                        game_NextMinX = 900;
                        game_NextMaxX = 1100;
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

                if (!game_DemoMode)
                {
                    game_WeaponSelector.SetWeaponSelector_SelectedWeapon(Weapons.Shot);
                    SelectWeapon(Weapons.Shot);
                }

                game_NewTurn = false;
            }

            BaseUpdateEvent(new Tank[3]
            {
                game_TankArray[game_Turn % game_TankArray.Length],
                game_TankArray[(game_Turn + 1) % game_TankArray.Length],
                game_TankArray[(game_Turn + 2) % game_TankArray.Length]
            });

            _4PlayerFFA_Player1HealthBar.Update(_4PlayerFFA_Player1.GetTank_Health());
            _4PlayerFFA_Player2HealthBar.Update(_4PlayerFFA_Player2.GetTank_Health());
            _4PlayerFFA_Player3HealthBar.Update(_4PlayerFFA_Player3.GetTank_Health());
            _4PlayerFFA_Player4HealthBar.Update(_4PlayerFFA_Player4.GetTank_Health());
            _4PlayerFFA_FuelBar.Update(game_CurrentPlayer.GetTank_Fuel());

            foreach (Tank tank in game_TankArray)
            {
                if (tank.GetTank_Health() <= 0)
                {
                    RemoveTankFromArray(tank);
                }
            }

            if (game_TankArray.Length == 1)
            {
                game_Winner = game_TankArray[0];
                game_Stats.winner = game_Winner;

                EndGame();
            }
        }
        private void RemoveTankFromArray(Tank theTank)
        {
            Tank[] tempArray = game_TankArray;
            game_TankArray = new Tank[tempArray.Length - 1];

            int i = 0;
            foreach (Tank tank in tempArray)
            {
                if (tank != theTank)
                {
                    game_TankArray[i] = tank;
                    i++;
                }
            }
        }

        public override void AssignUsernames(string player1Username, string player2Username,
            string player3Username, string player4Username)
        {
            _4PlayerFFA_Player1HealthBar.SetProgressBar_LabelText(player1Username);
            _4PlayerFFA_Player1.SetTank_Username(player1Username);
            game_Stats.player1Username = player1Username;

            _4PlayerFFA_Player2HealthBar.SetProgressBar_LabelText(player2Username);
            _4PlayerFFA_Player2.SetTank_Username(player2Username);
            game_Stats.player2Username = player2Username;

            _4PlayerFFA_Player3HealthBar.SetProgressBar_LabelText(player3Username);
            _4PlayerFFA_Player3.SetTank_Username(player3Username);
            game_Stats.player3Username = player3Username;

            _4PlayerFFA_Player4HealthBar.SetProgressBar_LabelText(player4Username);
            _4PlayerFFA_Player4.SetTank_Username(player4Username);
            game_Stats.player4Username = player4Username;
        }

        public override void EndGame()
        {
            CompositionTarget.Rendering -= UpdateEvent;

            game_MessageBox.EndGameMessage();

            if (!game_DemoMode)
            {
                game_Framework.GetFramework_Window().KeyDown -= EscKeyPress;

                if (game_FireButton.GetFireButton_IsEnabled()) { game_FireButton.Toggle(); }
                if (game_WeaponSelector.GetWeaponSelector_IsEnabled()) { game_WeaponSelector.Toggle(); }

                game_Stats.player1DamageDealt = _4PlayerFFA_Player1.GetTank_DamageDealt();
                game_Stats.player1DamageTaken = _4PlayerFFA_Player1.GetTank_DamageTaken();
                game_Stats.player1DistanceTravelled = _4PlayerFFA_Player1.GetTank_DistanceTravelled();
                game_Stats.player1ProjectilesFired = _4PlayerFFA_Player1.GetTank_ProjectilesFired();

                game_Stats.player2DamageDealt = _4PlayerFFA_Player2.GetTank_DamageDealt();
                game_Stats.player2DamageTaken = _4PlayerFFA_Player2.GetTank_DamageTaken();
                game_Stats.player2DistanceTravelled = _4PlayerFFA_Player2.GetTank_DistanceTravelled();
                game_Stats.player2ProjectilesFired = _4PlayerFFA_Player2.GetTank_ProjectilesFired();

                game_Stats.CalculateTotals();

                game_Framework.ChangeMenu(Framework.Menus.ResultsMenu);
            }
        }
    }
}
