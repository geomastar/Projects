using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace map_prototype
{
    class Projectile
    {
        private Path projectile_Path;
        private Rect projectile_Rect;
        private RectangleGeometry projectile_RectangleGeometry;

        public Projectile(double width, double height, double XPos, double YPos)
        {
            projectile_Rect = new Rect(new Point(XPos, YPos), new Size(width, height));       
            projectile_RectangleGeometry= new RectangleGeometry();
            projectile_RectangleGeometry.Rect = projectile_Rect;
            projectile_Path = new Path();
            projectile_Path.Data = projectile_RectangleGeometry;
            projectile_Path.Stroke = Brushes.Red;
            projectile_Path.StrokeThickness = 2;
            projectile_Path.Fill = Brushes.DarkRed;
        }

        public bool CheckIntersect(Rect theFloor)
        {
            if(projectile_Rect.IntersectsWith(theFloor))
            {
                return true;
            }

            return false;
        }

        public Path GetProjectile_Path()
        {
            return projectile_Path;
        }
    }
}
