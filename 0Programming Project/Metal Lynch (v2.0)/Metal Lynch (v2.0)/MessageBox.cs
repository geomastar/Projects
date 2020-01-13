using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Metal_Lynch__v2._0_
{
    public class MessageBox : GUIObject
    {        
        private TextBlock messageBox_TextBlock;
        private ScrollViewer messageBox_ScrollViewer;

        public MessageBox(Game messageBox_Game)
        {
            game = messageBox_Game;
            //Sets the game variable of the base class to the parameter
            //messageBox_Game.

            messageBox_TextBlock = new TextBlock()
            {
                Foreground = Brushes.Black,
                Width = 400,
                FontSize = 16,
                TextWrapping = TextWrapping.Wrap,
                RenderTransform = new TranslateTransform(0, 0)
                //Instantiates the TextBlock object defining the width,
                //position and text formatting of the MessageBox.
            };

            messageBox_ScrollViewer = new ScrollViewer()
            {
                Height = 250,
                VerticalScrollBarVisibility = ScrollBarVisibility.Hidden,
                Content = messageBox_TextBlock
                //Instantiates the ScrollViewer object defining the height
                //and scroll properties of the MessageBox. Also adds the
                //TextBlock to its Content property.
            };

            GUIMainElement = messageBox_ScrollViewer;
            //Makes the ScrollViewer object the object that will be added to
            //the GUICanvas.

            AddToCanvas();
            //Adds the ScrollViewer to the Canvas of the Game that it
            //belongs to.
        }


        public void StartGameMessage(bool demoMode)
        {
            messageBox_TextBlock.Text += "Starting ";

            if (game.GetType().Equals(typeof(Training)))
            {
                messageBox_TextBlock.Text += "Training";
            }
            else if (game.GetType().Equals(typeof(_1v1)))
            {
                messageBox_TextBlock.Text += "1v1";

                if (!demoMode)
                {
                    messageBox_TextBlock.Text += " between "
                        + game.getGame_Stats().player1Username + " and "
                        + game.getGame_Stats().player2Username;
                }
            }

            if (demoMode) { messageBox_TextBlock.Text += " in demo mode"; }

            messageBox_TextBlock.Text += ".\n\n";

            messageBox_ScrollViewer.ScrollToEnd();
        }

        public void EndTurnMessage(int damageDealt, int turn)
        {
            messageBox_TextBlock.Text += ">End of turn " + turn + ".\n   " +
                damageDealt + " damage was dealt.\n\n>Starting turn " +
                (turn + 1) + ".\n";
            //Adds a message to the MessageBox describing the turn number
            //and damage dealt each turn.

            messageBox_ScrollViewer.ScrollToEnd();
            //Scrolls to the end of the MessageBox.
        }

        public void EndGameMessage()
        {
            messageBox_TextBlock.Text += "\nEnd of game. ";
            
            if (game.getGame_Stats().winner == null)
            {
                messageBox_TextBlock.Text += "Nobody";
            }
            else
            {
                messageBox_TextBlock.Text += game.getGame_Stats().winner.GetTank_Username();
            }

            messageBox_TextBlock.Text += " Won!\n";

            messageBox_ScrollViewer.ScrollToEnd();
        }
    }
}
