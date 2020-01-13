using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metal_Lynch__v2._0_
{
    public class Map : GameObject
    {
        private PathFigureCollection map_PathFigureCollection;
        private PathFigure map_PathFigure;
        private PathSegmentCollection map_PathSegmentCollection;
        private PolyBezierSegment map_PolyBezierSegment;
        private PolyLineSegment map_PolyLineSegment;
        private PointCollection map_BezierPointCollection;
        private PointCollection map_LinePointCollection;

        private BitmapImage map_DirtTexture;

        public Map(Game map_Game)
        {
            game = map_Game;
            //Sets the game variable of the base class to the parameter
            //map_Game.

            map_BezierPointCollection = new PointCollection()
            {
                new Point(0, 300), //P1
                new Point(1280, 300), //P2
                new Point(1280, 300) //P3
                //Instantiates the PointCollection object of the Bezier curve.
                //Defines the three latter control points of the Bezier curve
                //of the Path object.
            };
            map_PolyBezierSegment = new PolyBezierSegment()
            {
                Points = map_BezierPointCollection
                //Instantiates the PolyBezierSegment.
                //Adds the BezierPointCollection object to the PolyBezierSegment
                //object.
            };

            map_LinePointCollection = new PointCollection()
            {
                new Point(1280, 300),
                new Point(1280, 450),
                new Point(0, 450),
                new Point(0, 300)
                //Instantiates the PointCollection object of the line segment.
                //Defines the points for the geometry for the bottom section of
                //the map.
            };
            map_PolyLineSegment = new PolyLineSegment()
            {
                Points = map_LinePointCollection
                //Instantiates the PolyLineSegment.
                //Adds the LinePointCollection object to the PolyLineSegment
                //object.
            };

            map_PathSegmentCollection = new PathSegmentCollection();
            map_PathSegmentCollection.Add(map_PolyBezierSegment);
            map_PathSegmentCollection.Add(map_PolyLineSegment);
            //Instantiates the PathSegmentCollection object and adds the two
            //PathSegment objects to it.

            map_PathFigure = new PathFigure()
            {
                StartPoint = new Point(0, 300), //P0
                Segments = map_PathSegmentCollection
                //Instantiates the PathFigure.
                //Defines the first control point of the Bezier curve and adds
                //the PathSegmentCollection to the PathFigure object.
            };

            map_PathFigureCollection = new PathFigureCollection();
            map_PathFigureCollection.Add(map_PathFigure);
            //Instantiates the PathFigureCollection object and adds the
            //PathFigure object to it.

            geometry = new PathGeometry()
            {
                Figures = map_PathFigureCollection
                //Instantiates the PathGeometry.
                //Adds the PathFigureCollection to the PathGeometry.
            };

            map_DirtTexture = new BitmapImage(new Uri(@"Resources/Dirt texture.png", UriKind.Relative));
            //Selects the image for the Map's texture.

            path = new Path()
            {
                Stroke = Brushes.Brown,
                Fill = new ImageBrush(map_DirtTexture)
                {
                    Viewport = new Rect(0, 0, 1d / 12.8, 1d / 1.5),
                    TileMode = TileMode.Tile
                },
                StrokeThickness = 2,
                Data = geometry
                //Instantiates the Path object that will define the Map's
                //geometry, stroke thickness and stroke colour.
                //Assigns the stroke colour as brown and thickness as 2.
                //Assigns the PathGeometry object instantiated earlier
                //to the Path's data variable.
            };

            AddToCanvas();
            //Adds the Path to the Canvas of the Game that it belongs to.
        }
    }
}
