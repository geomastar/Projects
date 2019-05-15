using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace map_prototype
{
    class Floor
    {
        private Path floor_Path = new Path();
        private PathGeometry floor_PathGeometry = new PathGeometry();
        private PathFigureCollection floor_PathFigureCollection = new PathFigureCollection();
        private PathFigure floor_PathFigure = new PathFigure();
        private PathSegmentCollection floor_PathSegmentCollection = new PathSegmentCollection();
        private PolyBezierSegment floor_PolyBezierSegment = new PolyBezierSegment();
        private PointCollection floor_PointCollection = new PointCollection();

        public Floor(double X1, double Y1, double X2, double Y2)
        {
            floor_PointCollection = new PointCollection(1000);
            floor_PathFigure.StartPoint = new Point(X1, Y1);
            floor_PointCollection.Add(new Point(X1, Y1));
            floor_PointCollection.Add(new Point(X2, Y2));
            floor_PointCollection.Add(new Point(X2, Y2));
            floor_PolyBezierSegment.Points = floor_PointCollection;
            floor_PathSegmentCollection.Add(floor_PolyBezierSegment);
            floor_PathFigure.Segments = floor_PathSegmentCollection;
            floor_PathFigureCollection.Add(floor_PathFigure);
            floor_PathGeometry.Figures = floor_PathFigureCollection;
            floor_Path.Data = floor_PathGeometry;
            floor_Path.Stroke = Brushes.Black;
            floor_Path.StrokeThickness = 2;
        }

        public void AddCrater(double X)
        {
            floor_PointCollection.Insert(1, new Point(X-20, 350)); //control point
            floor_PointCollection.Insert(2, new Point(X-20, 350)); //end point

            floor_PointCollection.Insert(3, new Point(X-20, 350)); //start point
            floor_PointCollection.Insert(4, new Point(X-5, 360)); //control point

            floor_PointCollection.Insert(5, new Point(X+5, 360)); //control point
            floor_PointCollection.Insert(6, new Point(X+20, 370)); //end point

            floor_PointCollection.Insert(7, new Point(X+20, 370)); //start point
            floor_PointCollection.Insert(8, new Point(X+20, 360)); //control point

            foreach (Point p in floor_PointCollection)
            {
                Debug.WriteLine(p.X + "," + p.Y);
            }
        }

        public Path GetFloor_Path()
        {
            return floor_Path;
        }
    }
}
