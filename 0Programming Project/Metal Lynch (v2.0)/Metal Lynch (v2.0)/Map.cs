using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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

        public Map()
        {

        }
    }
}
