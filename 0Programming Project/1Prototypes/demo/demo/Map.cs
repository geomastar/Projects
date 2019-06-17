using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace demo
{
    class Map
    {
        private Path map_Path;
        private PathGeometry map_PathGeometry;
        private PathFigureCollection map_PathFigureCollection;
        private PathFigure map_PathFigure;
        private PathSegmentCollection map_PathSegmentCollection;
        private PolyBezierSegment map_PolyBezierSegment;
        private PolyLineSegment map_PolyLineSegment;
        private PointCollection map_BezierPointCollection;
        private PointCollection map_LinePointCollection;

        public Map(int mapID)
        {
            switch (mapID)
            {
                case 1:
                    GenerateMap(new Point(0,350), new PointCollection { new Point(0,350), new Point(800,350), new Point(800,350) });
                    break;
                case 2:
                    GenerateMap(new Point(0,350), new PointCollection { new Point(300,200), new Point(500,200), new Point(800,350) });
                    break;
                case 3:
                    GenerateMap(new Point(0,350), new PointCollection { new Point(300,-5000), new Point(500,-5000), new Point(800,350) });
                    break;
                default:
                    GenerateMap(new Point(0,350), new PointCollection { new Point(0,350), new Point(800,350), new Point(800,350) });
                    break;
            }
        }

        private void GenerateMap(Point startPoint, PointCollection points)
        {
            map_LinePointCollection = new PointCollection()
            {
                points.Last(),
                new Point(points.Last().X, 500),
                new Point(startPoint.X, 500),
                startPoint
            };

            map_PolyLineSegment = new PolyLineSegment()
            {
                Points = map_LinePointCollection
            };

            map_BezierPointCollection = points;

            map_PolyBezierSegment = new PolyBezierSegment()
            {
                Points = map_BezierPointCollection
            };

            map_PathSegmentCollection = new PathSegmentCollection();
            map_PathSegmentCollection.Add(map_PolyBezierSegment);
            map_PathSegmentCollection.Add(map_PolyLineSegment);

            map_PathFigure = new PathFigure()
            {
                StartPoint = startPoint,
                Segments = map_PathSegmentCollection
            };

            map_PathFigureCollection = new PathFigureCollection();
            map_PathFigureCollection.Add(map_PathFigure);

            map_PathGeometry = new PathGeometry()
            {
                Figures = map_PathFigureCollection
            };

            map_Path = new Path()
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Green,
                StrokeThickness = 2,
                Data = map_PathGeometry
            };
        }

        public void AddToCanvas(Canvas gameCanvas)
        {
            gameCanvas.Children.Add(map_Path);
        }

        public Path GetMap_Path()
        {
            return map_Path;
        }
    }
}
