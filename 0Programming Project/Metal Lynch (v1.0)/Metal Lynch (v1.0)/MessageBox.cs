﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Metal_Lynch__v1._0_
{
    public class MessageBox
    {
        private TextBlock messageBox_TextBlock;
        private ScrollViewer messageBox_ScrollViewer;

        public MessageBox(Canvas GUIcanvas)
        {
            messageBox_TextBlock = new TextBlock()
            {
                Background = Brushes.Gray,                
                Foreground = Brushes.Black,
                Width = 250,
                FontSize = 12,
                TextWrapping = TextWrapping.Wrap,
                RenderTransform = new TranslateTransform(0, 0)
                //Instantiates the TextBlock object defining the width,
                //position and text formatting of the MessageBox.
            };

            messageBox_ScrollViewer = new ScrollViewer()
            {
                Height = 112,
                VerticalScrollBarVisibility = ScrollBarVisibility.Hidden,
                Content = messageBox_TextBlock
                //Instantiates the ScrollViewer object defining the height
                //and scroll properties of the MessageBox. Also adds the
                //TextBlock to its Content property.
            };

            GUIcanvas.Children.Add(messageBox_ScrollViewer);
            //Adds the ScrollViewer to the GUICanvas.
        }

        public void EndTurnMessage(int damageDealt, int turn)
        {
            messageBox_TextBlock.Text += "End of turn " + turn + ".\n   " +
                damageDealt + " damage was dealt.\nStarting turn " +
                (turn + 1) + ".\n";
            //Adds a message to the MessageBox describing the turn number
            //and damage dealt each turn.
            messageBox_ScrollViewer.ScrollToEnd();
            //Scrolls to the end of the MessageBox.
        }
    }
}
