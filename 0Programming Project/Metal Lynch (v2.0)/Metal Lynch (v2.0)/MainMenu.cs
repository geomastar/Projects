using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Metal_Lynch__v2._0_
{
    public class MainMenu : Menu
    {
        private TextBlock mainMenu_TitleText;
        
        private Button mainMenu_PlayButton;
        private Button mainMenu_TutorialButton;
        private Button mainMenu_SettingsButton;
        private Button mainMenu_QuitButton;
        
        public MainMenu(Framework framework)
        {
            BaseConstructor(framework, 360, 420);

            mainMenu_TitleText = new TextBlock()
            {
                FontSize = 60,
                Text = "Metal Lynch",
                RenderTransform = new TranslateTransform(480, 50)
                //Instantiates the TextBlock for the game title.
            };
            menu_Canvas.Children.Add(mainMenu_TitleText);
            //Adds the TextBlock to the Menu Canvas.

            mainMenu_PlayButton = new Button()
            {
                Width = 200,
                Height = 60,
                FontSize = 40,
                Content = "Play",
                RenderTransform = new TranslateTransform(540, 150)
                //Instantiates the play Button.
            };
            mainMenu_PlayButton.Click += PlayButtonClickEvent;
            menu_Canvas.Children.Add(mainMenu_PlayButton);
            //Adds the play Button to the Menu Canvas.

            mainMenu_TutorialButton = new Button()
            {
                IsEnabled = false,

                Width = 200,
                Height = 60,
                FontSize = 40,
                Content = "Tutorial",
                RenderTransform = new TranslateTransform(540, 220)
                //Instantiates the tutorial Button.
            };
            menu_Canvas.Children.Add(mainMenu_TutorialButton);
            //Adds the tutorial Button to the Menu Canvas.

            mainMenu_SettingsButton = new Button()
            {
                IsEnabled = false,

                Width = 200,
                Height = 60,
                FontSize = 40,
                Content = "Settings",
                RenderTransform = new TranslateTransform(540, 290)
                //Instantiates the settings Button.
            };
            menu_Canvas.Children.Add(mainMenu_SettingsButton);
            //Adds the settings Button to the Menu Canvas.

            mainMenu_QuitButton = new Button()
            {
                Width = 200,
                Height = 60,
                FontSize = 40,
                Content = "Quit Game",
                RenderTransform = new TranslateTransform(540, 360)
                //Instantiates the quit Button.
            };
            mainMenu_QuitButton.Click += QuitButtonClickEvent;
            menu_Canvas.Children.Add(mainMenu_QuitButton);
            //Adds the quit Button to the Menu Canvas.

            AddToCanvas();
            //Adds the Menu Canvas to the Framework Canvas.
        }

        private void PlayButtonClickEvent(object sender, RoutedEventArgs e)
        {
            PlayClickForwardSound();

            menu_Framework.ChangeMenu(Framework.Menus.GameMenu);
        }

        private void QuitButtonClickEvent(object sender, RoutedEventArgs e)
        {
            PlayClickBackwardSound();

            menu_Framework.GetFramework_Window().Close();
        }
    }
}
