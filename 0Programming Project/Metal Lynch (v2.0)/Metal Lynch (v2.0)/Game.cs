using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Metal_Lynch__v2._0_
{
    public abstract class Game
    {
        protected Framework game_Framework;

        protected Grid game_Grid;
        protected RowDefinition game_MainRow;
        protected RowDefinition game_GUIRow;

        protected Canvas game_MainCanvas;
        protected Canvas game_GUICanvas;

        protected Map game_Map;
        protected Projectile game_Projectile;
        protected Tank game_CurrentPlayer;
        protected Tank game_Winner;
        protected Tank[] game_TankArray;

        protected MessageBox game_MessageBox;
        protected AimingIcon game_AimingIcon;
        protected FireButton game_FireButton;

        protected MediaPlayer game_MediaPlayer;
        protected Uri game_TankMoveSoundUri;
        protected Uri game_TankFireSoundUri;
        protected Uri game_ExplosionSoundUri;

        protected BitmapImage game_SkyTexture;
        protected BitmapImage game_SteelTexture;

        protected int game_LeftBoundary;
        protected int game_RightBoundary;

        protected bool game_NewTurn;
        protected int game_Gravity;
        protected int game_Turn;
        protected bool game_Paused;

        protected GameStats game_Stats;

        protected bool game_DemoMode;
        protected int game_NextXLoc;
        protected int game_NextMinX;
        protected int game_NextMaxX;
        protected bool game_AngleDirection;

        protected abstract void UpdateEvent(object sender, EventArgs e);
        public abstract void EndGame();
        public virtual void AssignUsernames(string player1Username, string player2Username) { }

        public struct GameStats
        {
            public Tank winner;
            public string player1Username;
            public string player2Username;
            public int player1DamageDealt;
            public int player2DamageDealt;
            public int player1DamageTaken;
            public int player2DamageTaken;
            public int totalDamage;
            public int player1DistanceTravelled;
            public int player2DistanceTravelled;
            public int totalDistanceTravelled;
            public int player1ProjectilesFired;
            public int player2ProjectilesFired;
            public int totalProjectilesFired;

            public void CalculateTotals()
            {
                totalDamage = player1DamageTaken + player2DamageTaken;
                totalDistanceTravelled = player1DistanceTravelled + player2DistanceTravelled;
                totalProjectilesFired = player1ProjectilesFired + player2ProjectilesFired;
            }
        }

        protected void AddToCanvas()
        {
            game_Framework.GetFramework_Canvas().Children.Add(game_Grid);
            //Adds the Grid object to the Canvas of the Framework.
        }

        protected void BaseConstructor(Framework framework, bool demoMode)
        {
            game_Framework = framework;
            //Assigns the framework parameter to the variable.

            game_MediaPlayer = new MediaPlayer() { Volume = 0.1 };
            game_TankMoveSoundUri = new Uri(@"Resources/Tank Move sound effect.mp3", UriKind.Relative);
            game_TankFireSoundUri = new Uri(@"Resources/Tank Fire sound effect.mp3", UriKind.Relative);
            game_ExplosionSoundUri = new Uri(@"Resources/Explosion sound effect.mp3", UriKind.Relative);

            game_SkyTexture = new BitmapImage(new Uri(@"Resources/Sky texture.png", UriKind.Relative));
            game_SteelTexture = new BitmapImage(new Uri(@"Resources/GUI texture.png", UriKind.Relative));
            //Selects the images for the two textures.

            game_MainCanvas = new Canvas()
            {
                Height = 450,
                Width = 1280,
                Background = new ImageBrush(game_SkyTexture)
            };
            game_GUICanvas = new Canvas()
            {
                Height = 240,
                Width = 1280,
                Background = new ImageBrush(game_SteelTexture)
                {
                    Viewport = new Rect(0, 0, 1d/7.2, 1d/1.35),
                    TileMode = TileMode.Tile
                }
            };
            //Instantiates the two Canvas objects, giving them heights
            //and widths, as well as applying their textures.

            game_Grid = new Grid()
            {
                Height = 690,
                Width = 1280,                
            };            
            //Instantiates the Grid control that will encapsulate the two
            //Canvas objects.

            game_MainRow = new RowDefinition() { Height = new GridLength(450) };
            game_Grid.RowDefinitions.Add(game_MainRow);
            Grid.SetRow(game_MainCanvas, 0);
            game_Grid.Children.Add(game_MainCanvas);
            //Adds the game_MainCanvas to the Grid.

            game_GUIRow = new RowDefinition() { Height = new GridLength(240) };
            game_Grid.RowDefinitions.Add(game_GUIRow);
            Grid.SetRow(game_GUICanvas, 1);
            game_Grid.Children.Add(game_GUICanvas);
            //Adds the game_GUICanvas to the Grid.

            game_Map = new Map(this);
            game_Projectile = new Projectile(this);
            //Instantiates the game objects.

            game_MessageBox = new MessageBox(this);
            game_AimingIcon = new AimingIcon(this, 500, 115);
            game_FireButton = new FireButton(this, 700, 85);
            //Instantiates the GUI objects.

            game_LeftBoundary = 0;
            game_RightBoundary = 1280;
            //Sets the boundaries for the Tank and Projectile objects.

            game_NewTurn = true;
            game_Gravity = 10;
            game_Turn = 1;
            //Sets the gravity, turn counter and NewTurn bool.

            game_Stats = new GameStats();
            game_Stats.player1Username = "Player1";
            game_Stats.player2Username = "Player2";

            game_NextMinX = 100;
            game_NextMaxX = 500;
            game_AngleDirection = true;
            GenerateRandomXLoc();
            if (demoMode) { ToggleDemoMode(); }
            //Assigns the demo mode variables to their defaults and
            //activates the demo mode.
            
            game_Framework.GetFramework_Window().KeyDown += EscKeyPress;

            game_MessageBox.StartGameMessage(demoMode);
        }

        protected void BaseUpdateEvent(Tank[] enemyTankArray)
        {
            foreach (Tank tank in game_TankArray)
            {
                int i = game_Gravity;
                //Assigns a temporary integer variable the value of gravity
                //for use as a decrement in the following while loop.
                bool intersectionFound = false;
                //Assigns a temporary Boolean variable the value false for
                //use as an argument in the following while loop.

                while (i > 0 & !intersectionFound)
                {
                    tank.MoveDown();

                    IntersectionDetail tankMapIntersection =
                        tank.GetGeometry().FillContainsWithDetail
                        (game_Map.GetGeometry());
                    //Assigns the results from a hitbox test between the
                    //Tank and the Map to a new variable.

                    if (tankMapIntersection == IntersectionDetail.Intersects)
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
                
                if (tank.GetTank_TranslateTransform().X < game_LeftBoundary)
                {
                    tank.MoveRight();
                    tank.IncrementFuel(); tank.IncrementFuel();
                    tank.DecrementDistanceTravelled(); tank.DecrementDistanceTravelled();
                    //Moves the tank object right if it crosses the left
                    //boundary and corrects the fuel and distance travelled
                    //values.
                }
                if (tank.GetPath().ActualWidth + 15 > game_RightBoundary)
                {
                    tank.MoveLeft();
                    tank.IncrementFuel(); tank.IncrementFuel();
                    tank.DecrementDistanceTravelled(); tank.DecrementDistanceTravelled();
                    //Moves the tank object left if it crosses the right
                    //boundary and corrects the fuel and distance travelled
                    //values.
                }

                //This code is done for all Tank objects in the array.                
            }

            if (game_Projectile.GetProjectile_InMotion())
            {
                double i = game_Projectile.GetProjectile_Speed() *
                    game_Projectile.GetXVelocity();
                //Assigns a temporary integer variable for use as a decrement
                //In the following while loop.
                bool intersectionFound = false;
                //Assigns a temporary Boolean variable the value false for
                //use as an argument in the following while loop.

                while (i > 0 & !intersectionFound)
                {
                    game_Projectile.MoveAlongTrajectory(game_Gravity);
                    //Moves the Projectile along its trajectory.

                    IntersectionDetail projectileMapIntersection =
                        game_Projectile.GetGeometry().FillContainsWithDetail
                        (game_Map.GetGeometry());
                    //Assigns the results from a hitbox test between the Projectile
                    //object and the Map object to a variable.

                    foreach (Tank tank in enemyTankArray)
                    {
                        IntersectionDetail projectileEnemyIntersection =
                            game_Projectile.GetGeometry().FillContainsWithDetail
                            (tank.GetGeometry());
                        //Assigns the results from a hitbox test between the Projectile
                        //object and the tank object to a variable.

                        if (projectileEnemyIntersection == IntersectionDetail.Intersects
                            & !intersectionFound)
                        {
                            game_MediaPlayer.Open(game_ExplosionSoundUri);
                            game_MediaPlayer.Play();

                            EndTurn(tank.TakeDamage(game_Projectile));
                            game_CurrentPlayer.DealDamage(game_Projectile);
                            intersectionFound = true;
                            //If the projectile hits the enemy it will deal damage and
                            //stop the while loop.
                        }
                    }

                    if ((projectileMapIntersection == IntersectionDetail.Intersects | projectileMapIntersection == IntersectionDetail.FullyInside)
                        & !intersectionFound)
                    {
                        game_MediaPlayer.Open(game_ExplosionSoundUri);
                        game_MediaPlayer.Play();

                        EndTurn(0);
                        intersectionFound = true;
                        //If the projectile hits the map it stops the while loop.
                    }
                    else if ((game_Projectile.GetProjectile_TranslateTransform().X < game_LeftBoundary |
                        game_Projectile.GetProjectile_TranslateTransform().X > game_RightBoundary)
                        & !intersectionFound)
                    {
                        EndTurn(0);
                        intersectionFound = true;
                        //If the projectile leaves the map it stops the while loop.
                    }

                    i--;
                    //Decrements the while loop.
                }
            }
            else if(game_DemoMode)
            {
                if (game_NextXLoc > game_CurrentPlayer.GetTank_TranslateTransform().X
                    && game_CurrentPlayer.GetTank_Fuel() != 0)
                {
                    game_CurrentPlayer.MoveRight();
                    //Moves the tank right if the game_NextXLoc is to its right.
                }
                else if (game_NextXLoc < game_CurrentPlayer.GetTank_TranslateTransform().X
                    && game_CurrentPlayer.GetTank_Fuel() != 0)
                {
                    game_CurrentPlayer.MoveLeft();
                    //Moves the tank left if the game_NextXLoc is to its left.
                }
                else
                {
                    FireProjectileRandom();
                    //Fires the projectile on a random trajectory.
                }
            }
            else
            {
                if (game_CurrentPlayer.GetTank_Fuel() != 0)
                {
                    if (Keyboard.IsKeyDown(Key.A))
                    {
                        game_CurrentPlayer.MoveLeft();
                        //Moves the player's Tank object left if the 'A' key is
                        //pressed down.
                    }
                    if (Keyboard.IsKeyDown(Key.D))
                    {
                        game_CurrentPlayer.MoveRight();
                        //Moves the player's Tank object right if the 'D' key is
                        //pressed down.
                    }
                }

                if (game_AimingIcon.BeingDragged())
                {
                    game_AimingIcon.DragIconEvent();
                }
            }
        }

        protected void EscKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && !game_DemoMode)
            {
                TogglePause();
            }
        }

        public void TogglePause()
        {
            if (!game_Paused)
            {
                CompositionTarget.Rendering -= UpdateEvent;
                game_Framework.ChangeMenu(Framework.Menus.PauseMenu);
            }
            else
            {
                game_Framework.GetFramework_Canvas().Children.Remove(game_Framework.GetFramework_Menu().GetMenu_Canvas());
                CompositionTarget.Rendering += UpdateEvent;
            }
            if (!game_Projectile.GetProjectile_InMotion()) { game_FireButton.Toggle(); }
            game_Paused = !game_Paused;
        }

        public void FireProjectile()
        {
            if (!game_AimingIcon.IconCentred())
            {
                game_MediaPlayer.Open(game_TankFireSoundUri);
                game_MediaPlayer.Play();

                game_Projectile.SetAndStartTrajectory
                    (new Point(game_CurrentPlayer.GetTank_TranslateTransform().X,
                        game_CurrentPlayer.GetTank_TranslateTransform().Y),
                    game_AimingIcon.GetAngleRadians(),
                    game_AimingIcon.GetInitialVelocity(),
                    game_AimingIcon.GetTrajectoryDirection());
                //Starts the trajectory of the Projectile.

                game_CurrentPlayer.FireProjectile();
                //Increments the projectiles fired stat of the tank firing a projectile.

                game_CurrentPlayer.SetTank_IconPos(game_AimingIcon.GetIconPos());
                //Sets the icon position variable of the Tank to the position of the aiming icon.

                game_FireButton.Toggle();
                //Disables the FireButton so that it cannot be clicked.
            }
        }

        public void ToggleDemoMode()
        {
            if (game_DemoMode) { game_MediaPlayer.Volume *= 2; }
            else { game_MediaPlayer.Volume /= 2; }
            game_DemoMode = !game_DemoMode;
            game_FireButton.Toggle();
            //Toggles the game_DemoMode variable as well as the FireButton
            //object.
        }

        private void EndTurn(int damageDealt)
        {
            game_Projectile.StopTrajectory();
            //Stops the trajectory of the Projectile.
            game_MessageBox.EndTurnMessage(damageDealt, game_Turn);
            //Adds an end of turn message to the MessageBox.
            game_Turn++;
            //Increments the turn counter.
            game_CurrentPlayer.ResetFuel();
            //Resets the fuel value for the player who just played.
            if (!game_DemoMode) { game_FireButton.Toggle(); }
            //Enables the fire button if demo mode is not active.
            game_NewTurn = true;
            //Tells the program that a new turn has started.
        }

        protected void GenerateRandomXLoc()
        {
            Random RNG = new Random();
            game_NextXLoc = RNG.Next(game_NextMinX, game_NextMaxX);
            //Assigns the game_NextXLoc variable to a random integer.
        }

        private void FireProjectileRandom()
        {
            Random RNG = new Random();

            double calcAngle = RNG.Next(40, Convert.ToInt32(((Math.PI * 100) - 30) / 2)) / 100D;
            if (!game_AngleDirection)
            {
                calcAngle = calcAngle * -1;
            }

            game_MediaPlayer.Open(game_TankFireSoundUri);
            game_MediaPlayer.Play();

            game_Projectile.SetAndStartTrajectory
                (new Point(game_CurrentPlayer.GetTank_TranslateTransform().X,
                    game_CurrentPlayer.GetTank_TranslateTransform().Y),
                calcAngle,
                RNG.Next(60, 100),
                game_AngleDirection);
                //Starts a random trajectory for the Projectile.
        }

        public void DeactivateGame()
        {
            CompositionTarget.Rendering -= UpdateEvent;
            //Removes the UpdateEvent from the Rendering EventHandler.
        }

        public Canvas GetGame_MainCanvas()
        {
            return game_MainCanvas;
            //Returns the main Canvas.
        }

        public Canvas GetGame_GUICanvas()
        {
            return game_GUICanvas;
            //Returns the GUI Canvas.
        }

        public Grid GetGame_Grid()
        {
            return game_Grid;
            //Returns the Grid.
        }

        public GameStats getGame_Stats()
        {
            return game_Stats;
            //Returns the game stats.
        }
    }
}
