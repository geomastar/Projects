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
    public class ProgressBar : GUIObject
    {
        private Path progressBar_BarPath;
        private RectangleGeometry progressBar_BarRectangleGeometry;

        private Path progressBar_ProgressPath;
        private RectangleGeometry progressBar_ProgressRectangleGeometry;
        private double progressBar_ProgressMaxValue;

        private TextBlock progressBar_LabelText;
        private TextBlock progressBar_ProgressValueText;

        private int progressBar_Width;
        private int progressBar_Height;
        private int progressBar_SizeMod;
        private Point progressBar_Position;

        public ProgressBar(Game progressBar_Game, int X, int Y, int sizeMod,
            string label, bool showValue, double value)
        {
            game = progressBar_Game;
            //Sets the game variable of the base class to the parameter
            //progressBar_Game.

            progressBar_ProgressMaxValue = value;
            //Assings the maximum value for the ProgressBar.

            progressBar_SizeMod = sizeMod;

            progressBar_Width = 5 * progressBar_SizeMod;
            progressBar_Height = 2 * progressBar_SizeMod;
            //Assigns the width and height.
            Size size = new Size(progressBar_Width, progressBar_Height);
            //Calculates the size of the bar based off the modifier parameter.

            progressBar_Position = new Point(X, Y);
            //Assigns the position of the ProgressBar.

            progressBar_LabelText = new TextBlock()
            {
                RenderTransform = new TranslateTransform(
                    X - (label.Length * progressBar_SizeMod / 1.8),
                    Y + (progressBar_SizeMod / 3)),
                Text = label,
                FontSize = progressBar_SizeMod
            };
            GUIMainElement = progressBar_LabelText;
            AddToCanvas();
            //Adds the progressBar_LabelText to the Canvas of the Game that
            //it belongs to.

            progressBar_BarRectangleGeometry = new RectangleGeometry()
            {
                Rect = new Rect(size),
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
                Rect = new Rect(size),
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

            if (showValue)
            {
                progressBar_ProgressValueText = new TextBlock()
                {
                    RenderTransform = new TranslateTransform(
                        X, Y + (sizeMod / 3)),
                    Text = progressBar_ProgressMaxValue.ToString(),
                    FontSize = sizeMod - 0
                };
                GUIMainElement = progressBar_ProgressValueText;
                AddToCanvas();
                //Adds the progressBar_ProgressValueText to the Canvas of the Game that
                //it belongs to, but only if the boolean parameter is true.
            }
        }

        public void Update(double value)
        {
            if (value >= 0)
            {
                progressBar_ProgressRectangleGeometry.Rect = new Rect(
                    new Size((value / progressBar_ProgressMaxValue) * progressBar_Width,
                    progressBar_Height));
            }
            if (progressBar_ProgressValueText != null) { progressBar_ProgressValueText.Text = value.ToString(); }            
            //Updates the ProgressBar.
        }

        public void SetProgressBar_LabelText(string text)
        {
            progressBar_LabelText.Text = text;
            progressBar_LabelText.RenderTransform = new TranslateTransform(
                progressBar_Position.X - (text.Length * progressBar_SizeMod / 1.8),
                progressBar_Position.Y + (progressBar_SizeMod / 3));
        }
    }
}
