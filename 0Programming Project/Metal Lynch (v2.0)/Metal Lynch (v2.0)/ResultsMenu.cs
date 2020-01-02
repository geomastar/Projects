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
    public class ResultsMenu : Menu
    {
        private TextBlock resultsMenu_ResultText;

        private Path resultsMenu_StatsBackgroundPath;
        private RectangleGeometry resultsMenu_StatsBackgroundRectangleGeometry;

        private TextBlock resultsMenu_Player1DamageText;
        private TextBlock resultsMenu_Player2DamageText;
        private TextBlock resultsMenu_TotalDamageText;
        private TextBlock resultsMenu_Player1DistanceTravelledText;
        private TextBlock resultsMenu_Player2DistanceTravelledText;
        private TextBlock resultsMenu_TotalDistanceTravelledText;

        private Button resultsMenu_PlayAgainButton;
        private Button resultsMenu_MainMenuButton;

        public ResultsMenu(Framework framework)
        {
            BaseConstructor(framework);

            menu_BackgroundRectangleGeometry = new RectangleGeometry()
            {
                Rect = new Rect(new Size(360, 420)),
                Transform = new TranslateTransform(460, 30)
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

            resultsMenu_ResultText = new TextBlock()
            {
                FontSize = 60,
                Text = "Metal Lynch",
                RenderTransform = new TranslateTransform(480, 50)
                //Instantiates the TextBlock for the game title.
            };
            menu_Canvas.Children.Add(resultsMenu_ResultText);
            //Adds the TextBlock to the Menu Canvas.

            AddToCanvas();
            //Adds the Menu Canvas to the Framework Canvas.
        }
    }
}
