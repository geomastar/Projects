using System;
using System.Collections.Generic;
using System.Linq;
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
        protected Tank[] game_TankArray;

        protected MessageBox game_MessageBox;
        protected AimingIcon game_AimingIcon;
        protected FireButton game_FireButton;

        protected BitmapImage game_SkyTexture;
        protected BitmapImage game_SteelTexture;

        protected int game_LeftBoundary;
        protected int game_RightBoundary;

        protected int game_Gravity;
        protected int game_Turn;

        protected void AddToCanvas()
        {
            game_Framework.GetFramework_Canvas().Children.Add(game_Grid);
            //Adds the Grid object to the Canvas of the Framework.
        }

        protected void BaseConstructor(Framework framework)
        {
            game_Framework = framework;
            //Assigns the framework parameter to the variable.

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
            };
            //Instantiates the two Canvas objects, giving them heights
            //and widths, as well as applying their textures.

            game_Grid = new Grid()
            {
                Height = 690,
                Width = 1280
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
            game_AimingIcon = new AimingIcon(this, 425, 55);
            game_FireButton = new FireButton(this, 600, 35);
            //Instantiates the GUI objects.

            game_LeftBoundary = 0;
            game_RightBoundary = 1280;
            //Sets the boundaries for the Tank and Projectile objects.

            game_Gravity = 10;
            game_Turn = 1;
            //Sets the gravity and turn counter.
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
                    //Moves the tank object right if it crosses the left
                    //boundary.
                }
                if (tank.GetPath().ActualWidth + 15 > game_RightBoundary)
                {
                    tank.MoveLeft();
                    //Moves the tank object left if it crosses the right
                    //boundary.
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
                            EndTurn(tank.TakeDamage(game_Projectile));
                            intersectionFound = true;
                            //If the projectile hits the enemy it will deal damage and
                            //stop the while loop.
                        }
                    }

                    if ((projectileMapIntersection == IntersectionDetail.Intersects | projectileMapIntersection == IntersectionDetail.FullyInside)
                        & !intersectionFound)
                    {
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
            else
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

                if (game_AimingIcon.BeingDragged())
                {
                    game_AimingIcon.DragIconEvent();
                }
            }
        }

        public void FireProjectile()
        {
            if (!game_AimingIcon.IconCentred())
            {
                game_Projectile.SetAndStartTrajectory
                    (new Point(game_CurrentPlayer.GetTank_TranslateTransform().X,
                        game_CurrentPlayer.GetTank_TranslateTransform().Y),
                        game_AimingIcon.GetAngleRadians(),
                        game_AimingIcon.GetInitialVelocity(),
                        game_AimingIcon.GetTrajectoryDirection());
                //Starts the trajectory of the Projectile.

                game_FireButton.Toggle();
                //Disables the FireButton so that it cannot be clicked.
            }
        }

        private void EndTurn(int damageDealt)
        {
            game_Projectile.StopTrajectory();
            //Stops the trajectory of the Projectile.
            game_MessageBox.EndTurnMessage(damageDealt, game_Turn);
            //Adds an end of turn message to the MessageBox.
            game_Turn++;
            //Increments the turn counter.
            game_FireButton.Toggle();
            //Enables the fire button.
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
    }
}
