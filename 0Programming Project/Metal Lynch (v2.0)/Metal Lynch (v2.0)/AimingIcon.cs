using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v2._0_
{
    public class AimingIcon : GUIObject
    {
        private Border border;
        private Icon icon;        

        private Point aimingIcon_Centre;

        public AimingIcon(Game aimingIcon_Game, int X, int Y)
        {
            game = aimingIcon_Game;
            //Sets the game variable of the base class to the parameter
            //aimingIcon_Game.

            aimingIcon_Centre = new Point(X, Y);
            //Instantiates the start point.

            border = new Border(game, aimingIcon_Centre);
            icon = new Icon(game, aimingIcon_Centre);
            //Instantiates the two elements of the AimingIcon.
        }    

        public void DragIconEvent()
        {
            Point MousePos = Mouse.GetPosition(game.GetGame_GUICanvas());
            //Gets the position of the mouse on the GUICanvas.

            if (MousePos.X > border.border_RightLimit ||
                MousePos.X < border.border_LeftLimit ||
                MousePos.Y > border.border_LowerLimit ||
                MousePos.Y < border.border_UpperLimit)
            {
                icon.icon_BeingDragged = false;
                //Stops the icon from following the mouse when the mouse
                //exceeds the border's limits.
            }
            else
            {
                icon.icon_TranslateTransform.X = MousePos.X;
                icon.icon_TranslateTransform.Y = MousePos.Y;
                //Moves the icon to the mouse's position if it doesn't exceed
                //the border limits.
            }
        }

        public bool BeingDragged()
        {
            return icon.icon_BeingDragged;
            //Returns the boolean variable for whether the icon is being
            //dragged.
        }

        public double GetInitialVelocity()
        {
            double X = icon.icon_TranslateTransform.X - aimingIcon_Centre.X;
            double Y = aimingIcon_Centre.Y - icon.icon_TranslateTransform.Y;
            //Finds difference in both the X and Y values between the icon
            //and the centre.
            return 2 * Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            //Finds the displacement between the icon and the centre.
        }

        public double GetAngleRadians()
        {
            double X = icon.icon_TranslateTransform.X - aimingIcon_Centre.X;
            double Y = aimingIcon_Centre.Y - icon.icon_TranslateTransform.Y;
            //Finds difference in both the X and Y values between the icon
            //and the centre.
            double a = Math.Atan(Y / X);
            //Finds the angle.
            if (X < 0)
            {
                if (Y > 0)
                {
                    return a + Math.PI;
                    //Finds the angle if facing in the opposite direction.
                }
            }
            return a;
            //returns the angle.
        }

        public bool GetTrajectoryDirection()
        {
            if (icon.icon_TranslateTransform.X > aimingIcon_Centre.X)
            {
                return true;
            }

            return false;
        }

        public bool IconCentred()
        {
            if (icon.icon_TranslateTransform.X == aimingIcon_Centre.X &
               icon.icon_TranslateTransform.Y == aimingIcon_Centre.Y)
            {
                return true;
            }

            return false;
        }



        private class Border : GUIObject
        {
            private Path border_Path;
            private PathGeometry border_PathGeometry;
            private PathFigureCollection border_PathFigureCollection;
            private PathFigure border_PathFigure;
            private PathSegmentCollection border_PathSegmentCollection;
            private PolyLineSegment border_PolyLineSegment;
            private PointCollection border_PointCollection;

            public int border_UpperLimit;
            public int border_LowerLimit;
            public int border_LeftLimit;
            public int border_RightLimit;

            public Border(Game border_Game, Point centre)
            {
                game = border_Game;
                //Sets the game variable of the base class to the parameter
                //border_Game.

                GUIMainElement = border_Path;
                //Makes the Path object the object that will be added to
                //the GUICanvas.

                border_UpperLimit = Convert.ToInt32(centre.Y) - 45;
                border_LowerLimit = Convert.ToInt32(centre.Y) + 45;
                border_LeftLimit = Convert.ToInt32(centre.X) - 45;
                border_RightLimit = Convert.ToInt32(centre.X) + 45;
                //Initialises the limits of the border.

                border_PointCollection = new PointCollection()
                {
                    new Point(border_RightLimit, border_UpperLimit),
                    new Point(border_RightLimit, border_LowerLimit),
                    new Point(border_LeftLimit, border_LowerLimit),
                    new Point(border_LeftLimit, border_UpperLimit)
                    //Instantiates the PointCollection object, defining the
                    //shape of the border. Adds the above points to the
                    //collection.
                };

                border_PolyLineSegment = new PolyLineSegment()
                {
                    Points = border_PointCollection
                    //Instantiates the PolyLineSegment object defining the
                    //shape of the border. Adds the PointCollection to its
                    //Points property.
                };

                border_PathSegmentCollection = new PathSegmentCollection();
                border_PathSegmentCollection.Add(border_PolyLineSegment);
                //Instantiates the PathSegmentCollection and adds the
                //PolyLineSegment to it.

                border_PathFigure = new PathFigure()
                {
                    StartPoint = new Point(border_LeftLimit, border_UpperLimit),
                    Segments = border_PathSegmentCollection
                    //Instantiates the PathFigure, gives it the starting point,
                    //and adds the PathSegmentCollection to it.
                };

                border_PathFigureCollection = new PathFigureCollection();
                border_PathFigureCollection.Add(border_PathFigure);
                //Instantiates the PathFigureCollection and adds the PathFigure
                //to it.

                border_PathGeometry = new PathGeometry()
                {
                    Figures = border_PathFigureCollection
                    //Instantiates the PathGeometry and adds the
                    //PathFigureCollection to it.
                };

                border_Path = new Path()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Data = border_PathGeometry
                    //Instantiates the Path object for the border and defines
                    //its colour, thickness and adds the PathGeometry to it.
                };

                AddToCanvas();
                //Adds the Path to the Canvas of the Game that it belongs to.
            }
        }

        private class Icon : GUIObject
        {
            private Path icon_Path;
            private EllipseGeometry icon_EllipseGeometry;
            private TransformGroup icon_TransformGroup;
            public TranslateTransform icon_TranslateTransform;

            public bool icon_BeingDragged;

            public Icon(Game border_Game, Point centre)
            {
                game = border_Game;
                //Sets the game variable of the base class to the parameter
                //border_Game.

                GUIMainElement = icon_Path;
                //Makes the Path object the object that will be added to
                //the GUICanvas.

                icon_TranslateTransform = new TranslateTransform
                    (centre.X,
                    centre.Y);
                //Instantiates the TranslateTransform for the icon.

                icon_TransformGroup = new TransformGroup();
                icon_TransformGroup.Children.Add(icon_TranslateTransform);
                //Instantiates the TransformGroup and adds the TranslateTransform
                //to it.

                icon_EllipseGeometry = new EllipseGeometry()
                {
                    Transform = icon_TransformGroup,
                    RadiusX = 5,
                    RadiusY = 5
                    //Instantiates the EllipseGeometry and adds the TransformGroup
                    //to it. Also defines the size of the ellipse.
                };

                icon_Path = new Path()
                {
                    Fill = Brushes.Black,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Data = icon_EllipseGeometry
                    //Instantiates the Path object for the icon and defines its
                    //color, thickness and adds the EllipseGeometry to it.
                };

                icon_BeingDragged = false;
                //Initialises the boolean as false.

                icon_Path.MouseDown += AimingIconMouseDownEvent;
                icon_Path.MouseUp += AmingIconMouseUpEvent;
                //Adds two event handlers to the MouseDown and MouseUp events.
                //These will tell the program when the icon is being dragged and
                //when it isn't.

                AddToCanvas();
                //Adds the Path to the Canvas of the Game that it belongs to.
            }

            private void AimingIconMouseDownEvent(object sender, MouseButtonEventArgs e)
            {
                icon_BeingDragged = true;
                //When being dragged the boolean value will be set to true.
            }
            private void AmingIconMouseUpEvent(object sender, MouseButtonEventArgs e)
            {
                icon_BeingDragged = false;
                //When dragging is stopped the boolean value will be set to false.
            }
        }
    }
}
