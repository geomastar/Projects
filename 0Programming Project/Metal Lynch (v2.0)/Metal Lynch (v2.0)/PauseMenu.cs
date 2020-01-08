using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Metal_Lynch__v2._0_
{
    public class PauseMenu : Menu
    {
        private TextBlock pauseMenu_TitleText;

        private Button pauseMenu_ResumeButton;
        private Button pauseMenu_EndButton;

        public PauseMenu(Framework framework)
        {
            BaseConstructor(framework, 380, 200);

            pauseMenu_TitleText = new TextBlock()
            {
                Width = 700,
                FontSize = 60,
                Text = "Game Paused",
                TextAlignment = TextAlignment.Center,
                RenderTransform = new TranslateTransform(290, 50)
                //Instantiates the TextBlock for the pause menu title.
            };
            menu_Canvas.Children.Add(pauseMenu_TitleText);
            //Adds the TextBlock to the Menu Canvas.

            pauseMenu_ResumeButton = new Button()
            {
                Width = 140,
                Height = 40,
                FontSize = 20,
                Content = "Resume Game",
                RenderTransform = new TranslateTransform(490, 150)
                //Instantiates the play Button.
            };
            pauseMenu_ResumeButton.Click += ResumeButtonClickEvent;
            menu_Canvas.Children.Add(pauseMenu_ResumeButton);
            //Adds the play Button to the Menu Canvas.

            pauseMenu_EndButton = new Button()
            {
                Width = 140,
                Height = 40,
                FontSize = 20,
                Content = "End Game",
                RenderTransform = new TranslateTransform(650, 150)
                //Instantiates the tutorial Button.
            };
            pauseMenu_EndButton.Click += EndButtonClickEvent;
            menu_Canvas.Children.Add(pauseMenu_EndButton);
            //Adds the tutorial Button to the Menu Canvas.

            AddToCanvas();
            //Adds the Menu Canvas to the Framework Canvas.
        }

        private void ResumeButtonClickEvent(object sender, RoutedEventArgs e)
        {
            PlayClickForwardSound();

            menu_Framework.GetFramework_Game().TogglePause();
        }

        private void EndButtonClickEvent(object sender, RoutedEventArgs e)
        {
            PlayClickBackwardSound();

            menu_Framework.GetFramework_Game().EndGame();
        }
    }
}
