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
    public class MainMenu : Menu
    {
        private TextBlock mainMenu_TitleText;
        
        private Button mainMenu_PlayButton;
        private Button mainMenu_TutorialButton;
        private Button mainMenu_SettingsButton;
        private Button mainMenu_QuitButton;
        
        public MainMenu(Framework framework)
        {
            BaseConstructor(framework);

            mainMenu_TitleText = new TextBlock()
            {
                Width = 320,
                Height = 400,
                Background = new SolidColorBrush()
                {
                    Color = Colors.Gray,
                    Opacity = 0.5
                },
                FontSize = 60,
                Text = "Metal Lynch",
                RenderTransform = new TranslateTransform(480, 50)
            };
            menu_Canvas.Children.Add(mainMenu_TitleText);

            mainMenu_PlayButton = new Button()
            {
                Width = 200,
                Height = 60,
                FontSize = 40,
                Content = "Play",
                RenderTransform = new TranslateTransform(540, 150)
            };
            menu_Canvas.Children.Add(mainMenu_PlayButton);

            mainMenu_TutorialButton = new Button()
            {
                Width = 200,
                Height = 60,
                FontSize = 40,
                Content = "Tutorial",
                RenderTransform = new TranslateTransform(540, 220)
            };
            menu_Canvas.Children.Add(mainMenu_TutorialButton);

            mainMenu_SettingsButton = new Button()
            {
                Width = 200,
                Height = 60,
                FontSize = 40,
                Content = "Settings",
                RenderTransform = new TranslateTransform(540, 290)
            };
            menu_Canvas.Children.Add(mainMenu_SettingsButton);

            mainMenu_QuitButton = new Button()
            {
                Width = 200,
                Height = 60,
                FontSize = 40,
                Content = "Quit Game",
                RenderTransform = new TranslateTransform(540, 360)
            };
            menu_Canvas.Children.Add(mainMenu_QuitButton);

            AddToCanvas();
        }
    }
}
