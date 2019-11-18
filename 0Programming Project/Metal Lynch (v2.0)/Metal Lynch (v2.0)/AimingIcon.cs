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
    public class AimingIcon : GUIObject
    {
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

        public AimingIcon()
        {

        }
    }
}
