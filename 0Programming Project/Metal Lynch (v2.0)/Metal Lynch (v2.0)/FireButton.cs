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
    public class FireButton : GUIObject
    {
        private Button fireButton_Button;

        public FireButton(Game fireButton_Game, int X, int Y)
        {
            game = fireButton_Game;
            //Sets the game variable of the base class to the parameter
            //fireButton_Game.

            GUIMainElement = fireButton_Button;
            //Makes the Button object the object that will be added to
            //the GUICanvas.

            fireButton_Button = new Button()
            {
                Width = 60,
                Height = 40,
                Content = "Fire",
                FontSize = 20,
                Background = Brushes.Gray,
                RenderTransform = new TranslateTransform(X, Y)
                //Instantiates the Fire Button, defining its size, content
                //position on the GUICanvas.
            };

            fireButton_Button.Click += FireButtonClickEvent;
            //Adds the method that fires a projectile to the Click event of
            //the button.

            AddToCanvas();
            //Adds the Button to the Canvas of the Game that it
            //belongs to.
        }

        private void FireButtonClickEvent(object sender, RoutedEventArgs e)
        {
            game.FireProjectile();
        }

        public void Toggle()
        {
            fireButton_Button.IsEnabled = !fireButton_Button.IsEnabled;
            //Toggles the fire button.
        }
    }
}
