using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private PointCollection map_PointCollection;

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
                default:
                    GenerateMap(new Point(0, 350), new PointCollection { new Point(0, 350), new Point(800, 350), new Point(800, 350) });
                    break;
            }
        }

        private void GenerateMap(Point startPoint, PointCollection points)
        {
            map_PointCollection = points;

            map_PolyBezierSegment = new PolyBezierSegment()
            {
                Points = map_PointCollection
            };

            map_PathSegmentCollection = new PathSegmentCollection();
            map_PathSegmentCollection.Add(map_PolyBezierSegment);

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
                StrokeThickness = 2,
                Data = map_PathGeometry
            };
        }

        public Path GetMap_Path()
        {
            return map_Path;
        }
    }
}
