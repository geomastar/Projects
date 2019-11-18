using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v1._0_
{
    public class AimingIcon
    {
        Canvas GUICanvas;

        private Path aimingIcon_BorderPath;
        private PathGeometry aimingIcon_BorderPathGeometry;
        private PathFigureCollection aimingIcon_BorderPathFigureCollection;
        private PathFigure aimingIcon_BorderPathFigure;
        private PathSegmentCollection aimingIcon_BorderPathSegmentCollection;
        private PolyLineSegment aimingIcon_BorderPolyLineSegment;
        private PointCollection aimingIcon_BorderPointCollection;        

        private Path aimingIcon_IconPath;
        private EllipseGeometry aimingIcon_IconEllipseGeometry;
        private TransformGroup aimingIcon_IconTransformGroup;
        private TranslateTransform aimingIcon_IconTranslateTransform;

        private Point aimingIcon_Centre;

        private int aimingIcon_BorderUpperLimit;
        private int aimingIcon_BorderLowerLimit;
        private int aimingIcon_BorderLeftLimit;
        private int aimingIcon_BorderRightLimit;
        private bool aimingIcon_BeingDragged;

        public AimingIcon(Canvas GUIcanvas)
        {
            aimingIcon_Centre = new Point(425, 55);
            //Instantiates the start point.

            BuildAimingIcon_Border();
            BuildAimingIcon_Icon();
            //Calls the methods that Instantiate the two Path objects.

            aimingIcon_BorderUpperLimit = 10;
            aimingIcon_BorderLowerLimit = 100;
            aimingIcon_BorderLeftLimit = 380;
            aimingIcon_BorderRightLimit = 470;
            //Initialises the limits of the border.
            aimingIcon_BeingDragged = false;
            //Initialises the boolean as false.

            GUICanvas = GUIcanvas;
            //Assigns the parameter to the Canvas variable.

            GUICanvas.Children.Add(aimingIcon_BorderPath);
            GUICanvas.Children.Add(aimingIcon_IconPath);
            //Adds the two Path objects to the GUICanvas.
        }

        private void BuildAimingIcon_Border()
        {
            aimingIcon_BorderPointCollection = new PointCollection()
            {
                new Point(470, 10),
                new Point(470, 100),
                new Point(380, 100),
                new Point(380, 10)
                //Instantiates the PointCollection object defining the shape
                //of the border. Adds the above points to the collection.
            };

            aimingIcon_BorderPolyLineSegment = new PolyLineSegment()
            {
                Points = aimingIcon_BorderPointCollection
                //Instantiates the PolyLineSegment object defining the shape
                //of the border. Adds the PointCollection to its Points
                //property.
            };

            aimingIcon_BorderPathSegmentCollection = new PathSegmentCollection();
            aimingIcon_BorderPathSegmentCollection.Add(aimingIcon_BorderPolyLineSegment);
            //Instantiates the PathSegmentCollection and adds the
            //PolyLineSegment to it.

            aimingIcon_BorderPathFigure = new PathFigure()
            {
                StartPoint = new Point(380, 10),
                Segments = aimingIcon_BorderPathSegmentCollection
                //Instantiates the PathFigure, gives it the starting point,
                //and adds the PathSegmentCollection to it.
            };

            aimingIcon_BorderPathFigureCollection = new PathFigureCollection();
            aimingIcon_BorderPathFigureCollection.Add(aimingIcon_BorderPathFigure);
            //Instantiates the PathFigureCollection and adds the PathFigure
            //to it.

            aimingIcon_BorderPathGeometry = new PathGeometry()
            {
                Figures = aimingIcon_BorderPathFigureCollection
                //Instantiates the PathGeometry and adds the
                //PathFigureCollection to it.
            };

            aimingIcon_BorderPath = new Path()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Data = aimingIcon_BorderPathGeometry
                //Instantiates the Path object for the border and defines
                //its colour, thickness and adds the PathGeometry to it.
            };
        }

        private void BuildAimingIcon_Icon()
        {
            aimingIcon_IconTranslateTransform = new TranslateTransform
                (aimingIcon_Centre.X, aimingIcon_Centre.Y);
            //Instantiates the TranslateTransform for the icon.

            aimingIcon_IconTransformGroup = new TransformGroup();
            aimingIcon_IconTransformGroup.Children.Add(aimingIcon_IconTranslateTransform);
            //Instantiates the TransformGroup and adds the TranslateTransform
            //to it.

            aimingIcon_IconEllipseGeometry = new EllipseGeometry()
            {
                Transform = aimingIcon_IconTransformGroup,
                RadiusX = 5,
                RadiusY = 5
                //Instantiates the EllipseGeometry and adds the TransformGroup
                //to it. Also defines the size of the ellipse.
            };

            aimingIcon_IconPath = new Path()
            {
                Fill = Brushes.Black,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Data = aimingIcon_IconEllipseGeometry
                //Instantiates the Path object for the icon and defines its
                //color, thickness and adds the EllipseGeometry to it.
            };

            aimingIcon_IconPath.MouseDown += AimingIconMouseDownEvent;
            aimingIcon_IconPath.MouseUp += AmingIconMouseUpEvent;
            //Adds two event handlers to the MouseDown and MouseUp events.
            //These will tell the program when the icon is being dragged and
            //when it isn't.
        }

        private void AimingIconMouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            aimingIcon_BeingDragged = true;
            //When being dragged the boolean value will be set to true.
        }
        private void AmingIconMouseUpEvent(object sender, MouseButtonEventArgs e)
        {
            aimingIcon_BeingDragged = false;
            //When dragging is stopped the boolean value will be set to false.
        }

        public void DragIconEvent()
        {
            Point MousePos = Mouse.GetPosition(GUICanvas);
            //Gets the position of the mouse on the GUICanvas.

            if (MousePos.X > aimingIcon_BorderRightLimit ||
                MousePos.X < aimingIcon_BorderLeftLimit ||
                MousePos.Y > aimingIcon_BorderLowerLimit ||
                MousePos.Y < aimingIcon_BorderUpperLimit)
            {
                aimingIcon_BeingDragged = false;
                //Stops the icon from following the mouse when the mouse
                //exceeds the border's limits.
            }
            else
            {
                aimingIcon_IconTranslateTransform.X = MousePos.X;
                aimingIcon_IconTranslateTransform.Y = MousePos.Y;
                //Moves the icon to the mouse's position if it doesn't exceed
                //the border limits.
            }
        }

        public Path GetAimingIcon_IconPath()
        {
            return aimingIcon_IconPath;
            //Returns the icon's Path object.
        }

        public bool GetAimingIcon_BeingDragged()
        {
            return aimingIcon_BeingDragged;
            //Returns the boolean variable for whether the icon is being
            //dragged.
        }

        public double GetInitialVelocity()
        {
            double X = aimingIcon_IconTranslateTransform.X - aimingIcon_Centre.X;
            double Y = aimingIcon_Centre.Y - aimingIcon_IconTranslateTransform.Y;
            //Finds difference in both the X and Y values between the icon
            //and the centre.
            return 2 * Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            //Finds the displacement between the icon and the centre.
        }

        public double GetAngleRadians()
        {
            double X = aimingIcon_IconTranslateTransform.X - aimingIcon_Centre.X;
            double Y = aimingIcon_Centre.Y - aimingIcon_IconTranslateTransform.Y;
            //Finds difference in both the X and Y values between the icon
            //and the centre.
            double a = Math.Atan(Y / X);
            //Finds the angle.
            if(X < 0)
            {               
                if(Y > 0)
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
            if(aimingIcon_IconTranslateTransform.X > aimingIcon_Centre.X)
            {
                return true;
            }

            return false;
        }

        public bool IconCentred()
        {
            if(aimingIcon_IconTranslateTransform.X == aimingIcon_Centre.X &
               aimingIcon_IconTranslateTransform.Y == aimingIcon_Centre.Y)
            {
                return true;
            }

            return false;
        }
    }
}
