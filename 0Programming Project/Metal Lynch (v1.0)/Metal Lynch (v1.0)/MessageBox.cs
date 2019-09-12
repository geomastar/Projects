using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                Background = Brushes.Black,                
                Foreground = Brushes.Green,
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
    }
}
