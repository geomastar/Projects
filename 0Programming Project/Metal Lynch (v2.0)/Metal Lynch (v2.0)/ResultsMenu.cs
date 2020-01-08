using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v2._0_
{
    public class ResultsMenu : Menu
    {
        private TextBlock resultsMenu_ResultText;

        private Path resultsMenu_StatsBackgroundPath;
        private RectangleGeometry resultsMenu_StatsBackgroundRectangleGeometry;

        private Game.GameStats resultsMenu_GameStats;
        private TextBlock[] resultsMenu_StatsTextBlockArray;
        private TextBlock resultsMenu_Player1DamageDealtText;
        private TextBlock resultsMenu_Player2DamageDealtText;
        private TextBlock resultsMenu_Player1DamageTakenText;
        private TextBlock resultsMenu_Player2DamageTakenText;
        private TextBlock resultsMenu_TotalDamageText;
        private TextBlock resultsMenu_Player1DistanceTravelledText;
        private TextBlock resultsMenu_Player2DistanceTravelledText;
        private TextBlock resultsMenu_TotalDistanceTravelledText;
        private TextBlock resultsMenu_Player1ProjectilesFiredText;
        private TextBlock resultsMenu_Player2ProjectilesFiredText;
        private TextBlock resultsMenu_TotalProjectilesFiredText;

        private Button resultsMenu_PlayAgainButton;
        private Button resultsMenu_MainMenuButton;

        public ResultsMenu(Framework framework)
        {
            BaseConstructor(framework, 700, 420);

            resultsMenu_GameStats = menu_Framework.GetFramework_Game().getGame_Stats();

            resultsMenu_ResultText = new TextBlock()
            {
                Width = 700,
                FontSize = 60,
                TextAlignment = TextAlignment.Center,
                RenderTransform = new TranslateTransform(290, 50)
                //Instantiates the TextBlock for the result text.
            };
            if (resultsMenu_GameStats.winner == null)
            {
                resultsMenu_ResultText.Text = "Nobody";
            }
            else
            {
                resultsMenu_ResultText.Text = resultsMenu_GameStats.winner.GetTank_Username();
            }
            resultsMenu_ResultText.Text += " Won!";
            menu_Canvas.Children.Add(resultsMenu_ResultText);
            //Adds the TextBlock to the Menu Canvas.

            BuildStatsDisplay();

            resultsMenu_PlayAgainButton = new Button()
            {
                Width = 100,
                Height = 50,
                FontSize = 20,
                Content = "Play Again",
                RenderTransform = new TranslateTransform(870, 360)
                //Instantiates the play Button.
            };
            resultsMenu_PlayAgainButton.Click += PlayAgainButtonClickEvent;
            menu_Canvas.Children.Add(resultsMenu_PlayAgainButton);
            //Adds the play again Button to the Menu Canvas.

            resultsMenu_MainMenuButton = new Button()
            {
                Width = 80,
                Height = 40,
                FontSize = 14,
                Content = "Return to\n Main Menu",
                RenderTransform = new TranslateTransform(10, 10)
                //Instantiates the play Button.
            };
            resultsMenu_MainMenuButton.Click += MainMenuButtonClickEvent;
            menu_Canvas.Children.Add(resultsMenu_MainMenuButton);
            //Adds the Main Menu Button to the Menu Canvas.

            AddToCanvas();
            //Adds the Menu Canvas to the Framework Canvas.
        }

        private void MainMenuButtonClickEvent(object sender, RoutedEventArgs e)
        {
            PlayClickBackwardSound();

            Random RNG = new Random();
            switch (RNG.Next(2))
            {
                case (0):
                    menu_Framework.ChangeGameMode(Framework.GameModes.Training, true);
                    break;
                case (1):
                    menu_Framework.ChangeGameMode(Framework.GameModes._1v1, true);
                    break;
            }
            menu_Framework.ChangeMenu(Framework.Menus.MainMenu);
        }

        private void PlayAgainButtonClickEvent(object sender, RoutedEventArgs e)
        {
            PlayClickForwardSound();

            if (menu_Framework.GetFramework_Game().GetType().Equals(typeof(Training)))
            {
                menu_Framework.ChangeGameMode(Framework.GameModes.Training, false);
            }
            if (menu_Framework.GetFramework_Game().GetType().Equals(typeof(_1v1)))
            {
                menu_Framework.ChangeGameMode(Framework.GameModes._1v1, false);
                menu_Framework.GetFramework_Game().AssignUsernames(
                    resultsMenu_GameStats.player1Username,
                    resultsMenu_GameStats.player2Username);
            }
            menu_Framework.GetFramework_Canvas().Children.Remove(menu_Canvas);
        }

        private void BuildStatsDisplay()
        {
            resultsMenu_StatsBackgroundRectangleGeometry = new RectangleGeometry()
            {
                Rect = new Rect(new Size(400, 280)),
                RadiusX = 50,
                RadiusY = 50,
                Transform = new TranslateTransform(450, 150)
                //Instantiates the RectangleGeometry, giving it a size and
                //a location.
            };

            resultsMenu_StatsBackgroundPath = new Path()
            {
                Data = resultsMenu_StatsBackgroundRectangleGeometry,
                Fill = new SolidColorBrush()
                {
                    Color = Colors.LightGray,
                    Opacity = 0.5
                },
                Stroke = Brushes.Black,
                StrokeThickness = 2
                //Instantiates the Path object, giving it a Geometry, colour,
                //and stroke.
            };
            menu_Canvas.Children.Add(resultsMenu_StatsBackgroundPath);
            //Adds the Path to the Menu Canvas.

            resultsMenu_Player1DamageDealtText = new TextBlock();
            resultsMenu_Player2DamageDealtText = new TextBlock();
            resultsMenu_Player1DamageTakenText = new TextBlock();
            resultsMenu_Player2DamageTakenText = new TextBlock();
            resultsMenu_TotalDamageText = new TextBlock();
            resultsMenu_Player1DistanceTravelledText = new TextBlock();
            resultsMenu_Player2DistanceTravelledText = new TextBlock();
            resultsMenu_TotalDistanceTravelledText = new TextBlock();
            resultsMenu_Player1ProjectilesFiredText = new TextBlock();
            resultsMenu_Player2ProjectilesFiredText = new TextBlock();
            resultsMenu_TotalProjectilesFiredText = new TextBlock();

            resultsMenu_StatsTextBlockArray = new TextBlock[]
            {
                resultsMenu_Player1DamageDealtText,
                resultsMenu_Player2DamageDealtText,
                resultsMenu_Player1DamageTakenText,
                resultsMenu_Player2DamageTakenText,
                resultsMenu_TotalDamageText,
                resultsMenu_Player1DistanceTravelledText,
                resultsMenu_Player2DistanceTravelledText,
                resultsMenu_TotalDistanceTravelledText,
                resultsMenu_Player1ProjectilesFiredText,
                resultsMenu_Player2ProjectilesFiredText,
                resultsMenu_TotalProjectilesFiredText
            };

            TextBlock[] player1Stats = new TextBlock[]
            {
                resultsMenu_Player1DamageDealtText,
                resultsMenu_Player1DamageTakenText,
                resultsMenu_Player1DistanceTravelledText,
                resultsMenu_Player1ProjectilesFiredText
            };
            TextBlock[] player2Stats = new TextBlock[]
            {
                resultsMenu_Player2DamageDealtText,
                resultsMenu_Player2DamageTakenText,
                resultsMenu_Player2DistanceTravelledText,
                resultsMenu_Player2ProjectilesFiredText
            };
            TextBlock[] totalStats = new TextBlock[]
            {
                resultsMenu_TotalDamageText,
                resultsMenu_TotalDistanceTravelledText,
                resultsMenu_TotalProjectilesFiredText
            };

            TextBlock[] damageDealtStats = new TextBlock[]
            {
                resultsMenu_Player1DamageDealtText,
                resultsMenu_Player2DamageDealtText,
                resultsMenu_TotalDamageText
            };
            TextBlock[] damageTakenStats = new TextBlock[]
            {
                resultsMenu_Player1DamageTakenText,
                resultsMenu_Player2DamageTakenText,
            };
            TextBlock[] distanceTravelledStats = new TextBlock[]
            {
                resultsMenu_Player1DistanceTravelledText,
                resultsMenu_Player2DistanceTravelledText,
                resultsMenu_TotalDistanceTravelledText
            };
            TextBlock[] projectilesFiredStats = new TextBlock[]
            {
                resultsMenu_Player1ProjectilesFiredText,
                resultsMenu_Player2ProjectilesFiredText,
                resultsMenu_TotalProjectilesFiredText
            };

            foreach (TextBlock textblock in player1Stats)
            {
                textblock.Text += resultsMenu_GameStats.player1Username + "'s ";
            }
            foreach (TextBlock textblock in player2Stats)
            {
                textblock.Text += resultsMenu_GameStats.player2Username + "'s ";
            }
            foreach (TextBlock textblock in totalStats)
            {
                textblock.Text += "Total ";
            }

            foreach (TextBlock textblock in damageDealtStats)
            {
                textblock.Text += "damage dealt: ";
            }
            foreach (TextBlock textblock in damageTakenStats)
            {
                textblock.Text += "damage Taken: ";
            }
            foreach (TextBlock textblock in distanceTravelledStats)
            {
                textblock.Text += "distance travelled: ";
            }
            foreach (TextBlock textblock in projectilesFiredStats)
            {
                textblock.Text += "projectiles fired: ";
            }

            foreach (TextBlock textblock in resultsMenu_StatsTextBlockArray)
            {
                textblock.Width = 700;
                textblock.FontSize = 20;
                textblock.FontStyle = FontStyles.Oblique;
                textblock.TextAlignment = TextAlignment.Center;
            }

            resultsMenu_Player1DamageDealtText.Text += resultsMenu_GameStats.player1DamageDealt;
            resultsMenu_Player1DamageTakenText.Text += resultsMenu_GameStats.player1DamageTaken;
            resultsMenu_Player1DistanceTravelledText.Text += resultsMenu_GameStats.player1DistanceTravelled;
            resultsMenu_Player1ProjectilesFiredText.Text += resultsMenu_GameStats.player1ProjectilesFired;

            resultsMenu_Player2DamageDealtText.Text += resultsMenu_GameStats.player2DamageDealt;
            resultsMenu_Player2DamageTakenText.Text += resultsMenu_GameStats.player2DamageTaken;
            resultsMenu_Player2DistanceTravelledText.Text += resultsMenu_GameStats.player2DistanceTravelled;
            resultsMenu_Player2ProjectilesFiredText.Text += resultsMenu_GameStats.player2ProjectilesFired;

            resultsMenu_TotalDamageText.Text += resultsMenu_GameStats.totalDamage;            
            resultsMenu_TotalDistanceTravelledText.Text += resultsMenu_GameStats.totalDistanceTravelled;
            resultsMenu_TotalProjectilesFiredText.Text += resultsMenu_GameStats.totalProjectilesFired;

            Type type = menu_Framework.GetFramework_Game().GetType();
            int XBaseValue = 290;
            int YBaseValue = 160;
            if (type.Equals(typeof(Training)))
            {
                int YIncrement = YBaseValue;
                foreach (TextBlock textblock in player1Stats)
                {
                    if (textblock != resultsMenu_Player1DamageTakenText)
                    {
                        textblock.RenderTransform = new TranslateTransform(XBaseValue, YIncrement);
                        menu_Canvas.Children.Add(textblock);
                        YIncrement += 20;
                    }
                }
            }
            else if (type.Equals(typeof(_1v1)))
            {
                int YIncrement = YBaseValue;
                foreach (TextBlock textblock in player1Stats)
                {
                    textblock.RenderTransform = new TranslateTransform(XBaseValue, YIncrement);
                    menu_Canvas.Children.Add(textblock);
                    YIncrement += 20;
                }
                YIncrement += 10;
                foreach (TextBlock textblock in player2Stats)
                {
                    textblock.RenderTransform = new TranslateTransform(XBaseValue, YIncrement);
                    menu_Canvas.Children.Add(textblock);
                    YIncrement += 20;
                }
                YIncrement += 20;
                foreach (TextBlock textblock in totalStats)
                {
                    textblock.RenderTransform = new TranslateTransform(XBaseValue, YIncrement);
                    menu_Canvas.Children.Add(textblock);
                    YIncrement += 20;
                }
            }
        }
    }
}
