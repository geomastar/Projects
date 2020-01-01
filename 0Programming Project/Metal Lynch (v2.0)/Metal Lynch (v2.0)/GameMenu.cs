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
        private ComboBoxItem gameMenu_1v1ComboBoxItem;
        private ComboBoxItem gameMenu_TrainingComboBoxItem;

        private TextBlock gameMenu_ModeDescriptor;

        public GameMenu(Framework framework)
        {
            BaseConstructor(framework);

            menu_BackgroundRectangleGeometry = new RectangleGeometry()
            {
                Rect = new Rect(new Size(640, 420)),
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
                Width = 240,
                Height = 100,
                FontSize = 60,
                Content = "Return to Main Menu",
                RenderTransform = new TranslateTransform(520, 50)
                //Instantiates the play Button.
            };
            //menu_Canvas.Children.Add(gameMenu_PlayButton);
            //Adds the play Button to the Menu Canvas.

            gameMenu_1v1ComboBoxItem = new ComboBoxItem(){ Content = "1v1" };
            gameMenu_TrainingComboBoxItem = new ComboBoxItem() { Content = "Training" };

            gameMenu_ModeSelector = new ComboBox()
            {
                Width = 240,
                Height = 50,
                FontSize = 30,
                IsEditable = true,
                IsReadOnly = true,
                Text = "--Select Mode--",
                RenderTransform = new TranslateTransform(360, 170)
            };
            gameMenu_ModeSelector.Items.Add(gameMenu_1v1ComboBoxItem);
            gameMenu_ModeSelector.Items.Add(gameMenu_TrainingComboBoxItem);
            menu_Canvas.Children.Add(gameMenu_ModeSelector);

            gameMenu_ModeDescriptor = new TextBlock()
            {
                FontSize = 20,
                Text = "Mode Description...",
                RenderTransform = new TranslateTransform(680, 170)
            };
            menu_Canvas.Children.Add(gameMenu_ModeDescriptor);

            AddToCanvas();
            //Adds the Menu Canvas to the Framework Canvas.
        }
    }
}
