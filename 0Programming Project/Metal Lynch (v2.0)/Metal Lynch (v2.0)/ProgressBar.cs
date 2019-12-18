using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v2._0_
{
    public class ProgressBar : GUIObject
    {
        private Path progressBar_BarPath;
        private RectangleGeometry progressBar_BarRectangleGeometry;

        private Path progressBar_ProgressPath;
        private RectangleGeometry progressBar_ProgressRectangleGeometry;

        public ProgressBar(Game progressBar_Game, int X, int Y, int size)
        {
            game = progressBar_Game;
            //Sets the game variable of the base class to the parameter
            //progressBar_Game.

            progressBar_BarRectangleGeometry = new RectangleGeometry()
            {
                Rect = new Rect(new Size(50, 20)),
                Transform = new TranslateTransform(X, Y)
            };
            progressBar_BarPath = new Path()
            {
                Data = progressBar_BarRectangleGeometry,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            GUIMainElement = progressBar_BarPath;
            AddToCanvas();
            //Adds the progressBar_BarPath to the Canvas of the Game that it
            //belongs to.

            progressBar_ProgressRectangleGeometry = new RectangleGeometry()
            {
                Rect = new Rect(new Size(50, 20)),
                Transform = new TranslateTransform(X, Y)
            };
            progressBar_ProgressPath = new Path()
            {
                Data = progressBar_ProgressRectangleGeometry,
                Fill = Brushes.DarkGray,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            GUIMainElement = progressBar_ProgressPath;
            AddToCanvas();
            //Adds the progressBar_ProgressPath to the Canvas of the Game that it
            //belongs to.
        }
    }
}
