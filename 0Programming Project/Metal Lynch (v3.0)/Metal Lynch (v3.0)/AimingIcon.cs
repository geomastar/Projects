using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metal_Lynch__v3._0_
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

            if (Math.Sqrt(Math.Pow((MousePos.X - aimingIcon_Centre.X), 2) +
                Math.Pow(aimingIcon_Centre.Y - MousePos.Y, 2)) > 100)
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
            double X = (icon.icon_TranslateTransform.X - aimingIcon_Centre.X);
            double Y = (aimingIcon_Centre.Y - icon.icon_TranslateTransform.Y);
            //Finds difference in both the X and Y values between the icon
            //and the centre.
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
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

        public Point GetAimingIcon_Centre()
        {
            return aimingIcon_Centre;
            //Returns the centre position of the AimingIcon object.
        }

        public void SetIconPos(Point point)
        {
            icon.icon_TranslateTransform.X = point.X;
            icon.icon_TranslateTransform.Y = point.Y;
            //Sets the icon position.
        }
        public Point GetIconPos()
        {
            return new Point(icon.icon_TranslateTransform.X,
                icon.icon_TranslateTransform.Y);
            //Returns the position of the Icon object.
        }



        private class Border : GUIObject
        {
            private Path border_Path;
            public EllipseGeometry border_EllipseGeometry;

            private BitmapImage border_TargetSprite;

            public Border(Game border_Game, Point centre)
            {
                game = border_Game;
                //Sets the game variable of the base class to the parameter
                //border_Game.

                border_EllipseGeometry = new EllipseGeometry()
                {
                    Center = centre,
                    RadiusX = 100,
                    RadiusY = 100
                    //Instantiates the EllipseGeometry and gives it the
                    //centre and a radius of 100.
                };

                border_TargetSprite = new BitmapImage(new Uri(@"Resources/Target sprite.png", UriKind.Relative));

                border_Path = new Path()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = new ImageBrush(border_TargetSprite),
                    Data = border_EllipseGeometry
                    //Instantiates the Path object for the border and defines
                    //its colour, thickness and adds the EllipseGeometry to it.
                };

                GUIMainElement = border_Path;
                //Makes the Path object the object that will be added to
                //the GUICanvas.

                AddToCanvas();
                //Adds the Path to the Canvas of the Game that it belongs to.
            }
        }

        private class Icon : GUIObject
        {
            private Path icon_Path;
            public EllipseGeometry icon_EllipseGeometry;
            private TransformGroup icon_TransformGroup;
            public TranslateTransform icon_TranslateTransform;

            public bool icon_BeingDragged;

            public Icon(Game border_Game, Point centre)
            {
                game = border_Game;
                //Sets the game variable of the base class to the parameter
                //border_Game.

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
                    RadiusX = 6,
                    RadiusY = 6
                    //Instantiates the EllipseGeometry and adds the TransformGroup
                    //to it. Also defines the size of the ellipse.
                };

                icon_Path = new Path()
                {
                    Fill = Brushes.Red,
                    Stroke = Brushes.Red,
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

                GUIMainElement = icon_Path;
                //Makes the Path object the object that will be added to
                //the GUICanvas.

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
