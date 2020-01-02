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
    public class GameMenu : Menu
    {
        private Button gameMenu_PlayButton;
        private Button gameMenu_MainMenuButton;

        private ComboBox gameMenu_ModeSelector;
        private ComboBoxItem gameMenu_TrainingComboBoxItem;
        private ComboBoxItem gameMenu_1v1ComboBoxItem;

        private TextBlock gameMenu_ModeDescriptor;

        private UsernamePrompt gameMenu_Player1UsernamePrompt;
        private UsernamePrompt gameMenu_Player2UsernamePrompt;

        private struct UsernamePrompt
        {
            public TextBlock labelBox;
            public TextBox inputBox;

            public UsernamePrompt(int playerNumber, int YPos)
            {
                labelBox = new TextBlock()
                {
                    FontSize = 20,
                    FontStyle = FontStyles.Italic,
                    Text = "Player " + playerNumber + "'s Username:",
                    RenderTransform = new TranslateTransform(360, YPos)
                };

                inputBox = new TextBox()
                {
                    Width = 160,
                    Height = 30,
                    BorderThickness = new Thickness(0),
                    Background = new SolidColorBrush()
                    {
                        Color = Colors.White,
                        Opacity = 1
                    },
                    FontSize = 20,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Text = "Player" + playerNumber,
                    RenderTransform = new TranslateTransform(410, YPos + 35)
                };
            }
        }

        public GameMenu(Framework framework)
        {
            BaseConstructor(framework);

            menu_BackgroundRectangleGeometry = new RectangleGeometry()
            {
                Rect = new Rect(new Size(640, 360)),
                Transform = new TranslateTransform(320, 30)
                //Instantiates the RectangleGeometry, giving it a size and
                //a location.
            };

            menu_BackgroundPath = new Path()
            {
                Data = menu_BackgroundRectangleGeometry,
                Fill = new SolidColorBrush()
                {
                    Color = Colors.Gray,
                    Opacity = 0.5
                },
                Stroke = Brushes.Black,
                StrokeThickness = 2
                //Instantiates the Path object, giving it a Geometry, colour,
                //and stroke.
            };
            menu_Canvas.Children.Add(menu_BackgroundPath);
            //Adds the Path to the Menu Canvas.

            gameMenu_PlayButton = new Button()
            {
                Width = 240,
                Height = 100,
                FontSize = 60,
                Content = "Play",
                RenderTransform = new TranslateTransform(520, 50)
                //Instantiates the play Button.
            };
            menu_Canvas.Children.Add(gameMenu_PlayButton);
            //Adds the play Button to the Menu Canvas.

            gameMenu_MainMenuButton = new Button()
            {
                Width = 80,
                Height = 40,
                FontSize = 14,
                Content = "Return to\n Main Menu",
                RenderTransform = new TranslateTransform(10, 10)
                //Instantiates the play Button.
            };
            gameMenu_MainMenuButton.Click += MainMenuButtonClickEvent;
            menu_Canvas.Children.Add(gameMenu_MainMenuButton);
            //Adds the play Button to the Menu Canvas.

            gameMenu_1v1ComboBoxItem = new ComboBoxItem() { Content = "1v1" };
            gameMenu_TrainingComboBoxItem = new ComboBoxItem() { Content = "Training" };

            gameMenu_ModeSelector = new ComboBox()
            {
                Width = 240,
                Height = 50,
                FontSize = 30,
                FontStyle = FontStyles.Italic,
                IsEditable = true,
                IsReadOnly = true,
                Text = "--Select Mode--",
                RenderTransform = new TranslateTransform(360, 170)
            };
            gameMenu_ModeSelector.Items.Add(gameMenu_TrainingComboBoxItem);
            gameMenu_ModeSelector.Items.Add(gameMenu_1v1ComboBoxItem);
            gameMenu_ModeSelector.DropDownClosed += DropDownClosedEvent;
            menu_Canvas.Children.Add(gameMenu_ModeSelector);

            gameMenu_ModeDescriptor = new TextBlock()
            {
                FontSize = 18,
                FontStyle = FontStyles.Oblique,
                RenderTransform = new TranslateTransform(640, 170)
            };
            menu_Canvas.Children.Add(gameMenu_ModeDescriptor);

            gameMenu_Player1UsernamePrompt = new UsernamePrompt(1, 230);
            gameMenu_Player2UsernamePrompt = new UsernamePrompt(2, 305);

            AddToCanvas();
            //Adds the Menu Canvas to the Framework Canvas.
        }

        private void MainMenuButtonClickEvent(object sender, RoutedEventArgs e)
        {
            menu_Framework.ChangeMenu(Framework.Menus.MainMenu);
        }

        private void DropDownClosedEvent(object sender, EventArgs e)
        {
            if (gameMenu_ModeSelector.SelectedItem == gameMenu_TrainingComboBoxItem)
            {
                menu_Framework.ChangeGameMode(Framework.GameModes.Training, true);
                gameMenu_ModeDescriptor.Text = "Practice your aim by endlessly\n firing at an unmoving enemy tank.";
                HideUsernamePrompt(gameMenu_Player1UsernamePrompt);
                HideUsernamePrompt(gameMenu_Player2UsernamePrompt);
            }
            if (gameMenu_ModeSelector.SelectedItem == gameMenu_1v1ComboBoxItem)
            {
                menu_Framework.ChangeGameMode(Framework.GameModes._1v1, true);
                gameMenu_ModeDescriptor.Text = "Take turns with a friend in this\n two player one vs one battle. ";
                ShowUsernamePrompt(gameMenu_Player1UsernamePrompt);
                ShowUsernamePrompt(gameMenu_Player2UsernamePrompt);
            }
        }

        private void ShowUsernamePrompt(UsernamePrompt usernamePrompt)
        {
            if (!menu_Canvas.Children.Contains(usernamePrompt.labelBox))
            {
                menu_Canvas.Children.Add(usernamePrompt.labelBox);
            }
            if (!menu_Canvas.Children.Contains(usernamePrompt.inputBox))
            {
                menu_Canvas.Children.Add(usernamePrompt.inputBox);
            }
        }
        private void HideUsernamePrompt(UsernamePrompt usernamePrompt)
        {
            if (menu_Canvas.Children.Contains(usernamePrompt.labelBox))
            {
                menu_Canvas.Children.Remove(usernamePrompt.labelBox);
            }
            if (menu_Canvas.Children.Contains(usernamePrompt.inputBox))
            {
                menu_Canvas.Children.Remove(usernamePrompt.inputBox);
            }
        }
    }
}
