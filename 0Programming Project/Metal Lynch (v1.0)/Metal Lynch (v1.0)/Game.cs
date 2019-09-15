using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Metal_Lynch__v1._0_
{
    public class Game
    {
        private Window game_Window;
        private Canvas game_Canvas;
        private Canvas game_GUICanvas;

        private Map game_Map;
        private Tank game_Player;
        private Tank game_Enemy;
        private Tank[] game_TankArray;
        private Projectile game_CurrentProjectile;
        private TankBarrier game_TankBarrierLeft;
        private TankBarrier game_TankBarrierRight;

        private MessageBox game_MessageBox;
        private AimingIcon game_AimingIcon;
        private Button game_FireButton;

        private BitmapImage game_SkyTexture;
        private ImageBrush game_SkyBrush;
        private BitmapImage game_SteelTexture;
        private ImageBrush game_SteelBrush;

        private int game_LeftProjectileLimit = -50;
        private int game_RightProjectileLimit = 850;

        private int game_Gravity;
        private int game_Turn;

        public Game(Window window, Canvas Gamecanvas, Canvas GUIcanvas)
        {
            game_Window = window;
            game_Canvas = Gamecanvas;
            game_GUICanvas = GUIcanvas;
            //Gives the Game object access to the window and canvases.

            game_Map = new Map(game_Canvas);
            //Instantiates the Map object.
            game_TankBarrierLeft = new TankBarrier(game_Canvas, 0);
            game_TankBarrierRight = new TankBarrier(game_Canvas, 400);
            //Instantiates the TankBarrier objects.
            game_Player = new Tank(game_Canvas, 100, 100);
            //Instantiates the player's Tank object.
            game_Enemy = new Tank(game_Canvas, 700, 100);
            //Instantiates the enemy's Tank object.
            game_TankArray = new Tank[2] { game_Player, game_Enemy };
            //Instantiates the Tank array and adds all the Tank objects to
            //the Tank array.
            game_CurrentProjectile = new Projectile(game_Canvas);
            //Instantiates the Projectile object.

            InstantiateGame_FireButton();
            //Calls the method that will instantiate the Fire Button object.
            game_MessageBox = new MessageBox(game_GUICanvas);
            //Instantiates the MessageBox object.
            game_AimingIcon = new AimingIcon(game_GUICanvas);
            //Instantiates the AimingIcon object.

            game_SkyTexture = new BitmapImage(new Uri(@"Resources/Sky texture.png", UriKind.Relative));
            game_SkyBrush = new ImageBrush(game_SkyTexture);
            game_Canvas.Background = game_SkyBrush;
            //Adds the Sky Texture to the Canvas background.
            game_SteelTexture = new BitmapImage(new Uri(@"Resources/GUI texture.png", UriKind.Relative));
            game_SteelBrush = new ImageBrush(game_SteelTexture);
            game_GUICanvas.Background = game_SteelBrush;
            //Adds the Steel Texture to the GUICanvas background.

            game_Gravity = 10;
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

            if(game_CurrentProjectile.GetProjectile_InMotion())
            {
                double i = game_CurrentProjectile.GetProjectile_Speed() *
                    game_CurrentProjectile.GetXVelocity();
                //Assigns a temporary integer variable for use as a decrement
                //In the following while loop.
                bool intersectionFound = false;
                //Assigns a temporary Boolean variable the value false for
                //use as an argument in the following while loop.

                while (i > 0 & !intersectionFound)
                {
                    game_CurrentProjectile.MoveAlongTrajectory(game_Gravity);
                    //Moves the Projectile along its trajectory.

                    IntersectionDetail projectileMapIntersection =
                        game_CurrentProjectile.GetProjectile_Path().Data.FillContainsWithDetail
                        (game_Map.GetMap_Path().Data);
                    IntersectionDetail projectileEnemyIntersection =
                        game_CurrentProjectile.GetProjectile_Path().Data.FillContainsWithDetail
                        (game_Enemy.GetTank_Path().Data);
                    //Assigns the results from hitbox tests between the Projectile
                    //object and the Map and Enemy Tank objects to variables.

                    if (projectileEnemyIntersection == IntersectionDetail.Intersects)
                    {
                        EndTurn(game_Enemy.TakeDamage(game_CurrentProjectile));
                        intersectionFound = true;
                        //If the projectile hits the enemy it will deal damage and
                        //stop the while loop.
                    }
                    else if(projectileMapIntersection == IntersectionDetail.Intersects | projectileMapIntersection == IntersectionDetail.FullyInside)
                    {
                        EndTurn(0);
                        intersectionFound = true;
                        //If the projectile hits the map it stop the while loop.
                    }
                    else if(game_CurrentProjectile.GetProjectile_TranslateTransform().X < game_LeftProjectileLimit |
                        game_CurrentProjectile.GetProjectile_TranslateTransform().X > game_RightProjectileLimit)
                    {
                        EndTurn(0);
                        intersectionFound = true;
                        //If the projectile leaves the map it stop the while loop.
                    }

                    i--;
                    //Decrements the while loop.
                }
            }
            else
            {
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

                if (game_AimingIcon.GetAimingIcon_BeingDragged())
                {
                    game_AimingIcon.DragIconEvent();
                }
            }
        }

        private void InstantiateGame_FireButton()
        {
            game_FireButton = new Button()
            {
                Width = 60,
                Height = 40,
                Content = "Fire",
                FontSize = 20,
                Background = Brushes.Gray,                
                RenderTransform = new TranslateTransform(600, 35)
                //Instantiates the Fire Button, defining its size, content
                //position on the GUICanvas.
            };

            game_FireButton.Click += FireButtonClickEvent;
            //Adds the method that fires a projectile to the Click event of
            //the button.

            game_GUICanvas.Children.Add(game_FireButton);
            //Adds the Fire button to the GUICanvas.
        }

        private void FireButtonClickEvent(object sender, RoutedEventArgs e)
        {
            if(!game_AimingIcon.IconCentred())
            {
                game_CurrentProjectile.SetAndStartTrajectory
                    (new Point(game_Player.GetTank_TranslateTransform().X,
                        game_Player.GetTank_TranslateTransform().Y),
                    game_AimingIcon.GetAngleRadians(),
                    game_AimingIcon.GetInitialVelocity(),
                    game_AimingIcon.GetTrajectoryDirection());
                //Starts the trajectory of the Projectile.

                game_FireButton.IsEnabled = false;
                //Disables the FireButton so that it cannot be clicked.
            }
        }

        private void EndTurn(int damageDealt)
        {
            game_CurrentProjectile.StopTrajectory();
            //Stops the trajectory of the Projectile.
            game_MessageBox.EndTurnMessage(damageDealt, game_Turn);
            //Adds an end of turn message to the MessageBox.
            game_Turn++;
            //Increments the turn counter.
            game_FireButton.IsEnabled = true;
            //Enables the fire button.
        }
    }
}
