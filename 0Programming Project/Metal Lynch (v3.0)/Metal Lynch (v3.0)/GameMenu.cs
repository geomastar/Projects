﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Metal_Lynch__v3._0_
{
    public class GameMenu : Menu
    {
        private Button gameMenu_PlayButton;
        private Button gameMenu_MainMenuButton;

        private ComboBox gameMenu_MapSelector;

        private ComboBox gameMenu_ModeSelector;
        private ComboBoxItem gameMenu_TrainingComboBoxItem;
        private ComboBoxItem gameMenu_1v1ComboBoxItem;
        private ComboBoxItem gameMenu_4PlayerFFAComboBoxItem;

        private TextBlock gameMenu_ModeDescriptor;

        private UsernamePrompt gameMenu_Player1UsernamePrompt;
        private UsernamePrompt gameMenu_Player2UsernamePrompt;
        private UsernamePrompt gameMenu_Player3UsernamePrompt;
        private UsernamePrompt gameMenu_Player4UsernamePrompt;

        private struct UsernamePrompt
        {
            public TextBlock labelBox;
            public TextBox inputBox;

            public UsernamePrompt(int playerNumber, int XPos, int YPos)
            {
                labelBox = new TextBlock()
                {
                    FontSize = 20,
                    FontStyle = FontStyles.Italic,
                    Text = "Player " + playerNumber + "'s Username:",
                    RenderTransform = new TranslateTransform(XPos, YPos)
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
                    MaxLength = 10,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Text = "Player" + playerNumber,
                    RenderTransform = new TranslateTransform(XPos + 50, YPos + 35)
                };
            }
        }

        public GameMenu(Framework framework)
        {
            BaseConstructor(framework, 640, 420);

            gameMenu_PlayButton = new Button()
            {
                Width = 240,
                Height = 100,
                FontSize = 60,
                Content = "Play",
                RenderTransform = new TranslateTransform(520, 50)
                //Instantiates the play Button.
            };
            gameMenu_PlayButton.Click += PlayButtonClickEvent;
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
            //Adds the Main Menu Button to the Menu Canvas.

            gameMenu_MapSelector = new ComboBox()
            {
                Width = 240,
                Height = 50,
                FontSize = 30,
                FontStyle = FontStyles.Italic,
                IsEditable = true,
                IsReadOnly = true,
                Text = "--Select Map--",
                RenderTransform = new TranslateTransform(360, 230)
            };
            foreach (Framework.MapData mapData in menu_Framework.GetFramework_MapDataList())
            {
                gameMenu_MapSelector.Items.Add(new ComboBoxItem() { Content = mapData.mapName });
            }
            gameMenu_MapSelector.DropDownOpened += DropDownOpenedEvent;
            gameMenu_MapSelector.DropDownClosed += DropDownClosedEvent;
            menu_Canvas.Children.Add(gameMenu_MapSelector);

            gameMenu_1v1ComboBoxItem = new ComboBoxItem() { Content = "1v1" };
            gameMenu_TrainingComboBoxItem = new ComboBoxItem() { Content = "Training" };
            gameMenu_4PlayerFFAComboBoxItem = new ComboBoxItem() { Content = "4 Player FFA" };

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
            gameMenu_ModeSelector.Items.Add(gameMenu_4PlayerFFAComboBoxItem);
            gameMenu_ModeSelector.DropDownOpened += DropDownOpenedEvent;
            gameMenu_ModeSelector.DropDownClosed += DropDownClosedEvent;
            menu_Canvas.Children.Add(gameMenu_ModeSelector);

            gameMenu_ModeDescriptor = new TextBlock()
            {
                FontSize = 18,
                FontStyle = FontStyles.Oblique,
                RenderTransform = new TranslateTransform(640, 170)
            };
            menu_Canvas.Children.Add(gameMenu_ModeDescriptor);

            gameMenu_Player1UsernamePrompt = new UsernamePrompt(1, 360, 290);
            gameMenu_Player2UsernamePrompt = new UsernamePrompt(2, 360, 365);
            gameMenu_Player3UsernamePrompt = new UsernamePrompt(3, 600, 290);
            gameMenu_Player4UsernamePrompt = new UsernamePrompt(4, 600, 365);

            AddToCanvas();
            //Adds the Menu Canvas to the Framework Canvas.
        }

        private void PlayButtonClickEvent(object sender, RoutedEventArgs e)
        {
            if (gameMenu_MapSelector.SelectedItem != null && gameMenu_ModeSelector.SelectedItem != null)
            {
                PlayClickForwardSound();

                Framework.MapData selectedMapData = menu_Framework.GetFramework_MapDataList()[gameMenu_MapSelector.SelectedIndex];

                if (gameMenu_ModeSelector.SelectedItem == gameMenu_TrainingComboBoxItem)
                {
                    menu_Framework.ChangeGameMode(Framework.GameModes.Training, false, selectedMapData);
                }
                else if (gameMenu_ModeSelector.SelectedItem == gameMenu_1v1ComboBoxItem)
                {
                    menu_Framework.ChangeGameMode(Framework.GameModes._1v1, false, selectedMapData);
                    menu_Framework.GetFramework_Game().AssignUsernames(
                        gameMenu_Player1UsernamePrompt.inputBox.Text,
                        gameMenu_Player2UsernamePrompt.inputBox.Text,
                        "", "");
                }
                else if (gameMenu_ModeSelector.SelectedItem == gameMenu_4PlayerFFAComboBoxItem)
                {
                    menu_Framework.ChangeGameMode(Framework.GameModes._4PlayerFFA, false, selectedMapData);
                    menu_Framework.GetFramework_Game().AssignUsernames(
                        gameMenu_Player1UsernamePrompt.inputBox.Text,
                        gameMenu_Player2UsernamePrompt.inputBox.Text,
                        gameMenu_Player3UsernamePrompt.inputBox.Text,
                        gameMenu_Player4UsernamePrompt.inputBox.Text);
                }

                menu_Framework.GetFramework_Canvas().Children.Remove(menu_Canvas);
            }
            else
            {
                PlayClickBackwardSound();
            }
        }

        private void MainMenuButtonClickEvent(object sender, RoutedEventArgs e)
        {
            PlayClickBackwardSound();

            menu_Framework.ChangeMenu(Framework.Menus.MainMenu);
        }

        private void DropDownOpenedEvent(object sender, EventArgs e)
        {
            PlayClickForwardSound();
        }

        private void DropDownClosedEvent(object sender, EventArgs e)
        {
            PlayClickForwardSound();

            Framework.MapData selectedMapData;
            if (gameMenu_MapSelector.SelectedItem == null)
            {
                selectedMapData = menu_Framework.GetFramework_Game().GetGame_MapData();
            }
            else
            {
                selectedMapData = menu_Framework.GetFramework_MapDataList()[gameMenu_MapSelector.SelectedIndex];
            }

            if (gameMenu_ModeSelector.SelectedItem == null)
            {
                if (menu_Framework.GetFramework_Game().GetType().Equals(typeof(Training)))
                {
                    menu_Framework.ChangeGameMode(Framework.GameModes.Training, true, selectedMapData);
                }
                if (menu_Framework.GetFramework_Game().GetType().Equals(typeof(_1v1)))
                {
                    menu_Framework.ChangeGameMode(Framework.GameModes._1v1, true, selectedMapData);
                }
                if (menu_Framework.GetFramework_Game().GetType().Equals(typeof(_4PlayerFFA)))
                {
                    menu_Framework.ChangeGameMode(Framework.GameModes._4PlayerFFA, true, selectedMapData);
                }
            }
            if (gameMenu_ModeSelector.SelectedItem == gameMenu_TrainingComboBoxItem)
            {
                menu_Framework.ChangeGameMode(Framework.GameModes.Training, true, selectedMapData);
                gameMenu_ModeDescriptor.Text = "Practice your aim by endlessly\n firing at an unmoving enemy tank.";
                HideUsernamePrompt(gameMenu_Player1UsernamePrompt);
                HideUsernamePrompt(gameMenu_Player2UsernamePrompt);
                HideUsernamePrompt(gameMenu_Player3UsernamePrompt);
                HideUsernamePrompt(gameMenu_Player4UsernamePrompt);
            }
            if (gameMenu_ModeSelector.SelectedItem == gameMenu_1v1ComboBoxItem)
            {
                menu_Framework.ChangeGameMode(Framework.GameModes._1v1, true, selectedMapData);
                gameMenu_ModeDescriptor.Text = "Take turns with a friend in this\n two player one vs one battle.";
                ShowUsernamePrompt(gameMenu_Player1UsernamePrompt);
                ShowUsernamePrompt(gameMenu_Player2UsernamePrompt);
            }
            if (gameMenu_ModeSelector.SelectedItem == gameMenu_4PlayerFFAComboBoxItem)
            {
                menu_Framework.ChangeGameMode(Framework.GameModes._4PlayerFFA, true, selectedMapData);
                gameMenu_ModeDescriptor.Text = "---Mode Description---";
                ShowUsernamePrompt(gameMenu_Player1UsernamePrompt);
                ShowUsernamePrompt(gameMenu_Player2UsernamePrompt);
                ShowUsernamePrompt(gameMenu_Player3UsernamePrompt);
                ShowUsernamePrompt(gameMenu_Player4UsernamePrompt);
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
