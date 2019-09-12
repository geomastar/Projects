using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v1._0_
{
    public class Projectile
    {
        private Path projectile_Path;
        private EllipseGeometry projectile_EllipseGeometry;
        private TransformGroup projectile_TransformGroup;
        private TranslateTransform projectile_TranslateTransform;

        public Projectile(Canvas Gamecanvas)
        {
            projectile_TranslateTransform = new TranslateTransform(20, 20);
            //Instantiates the TranslateTransform for the Projectile, defining
            //its location.

            projectile_TransformGroup = new TransformGroup();
            projectile_TransformGroup.Children.Add(projectile_TranslateTransform);
            //Instantiates the TransformGroup and adds the TranslateTransform
            //to it.

            projectile_EllipseGeometry = new EllipseGeometry()
            {
                Transform = projectile_TransformGroup,
                RadiusX = 5,
                RadiusY = 5
                //Instantiates the EllipseGeometry and adds the TransformGroup
                //to it. Also defines the size of the ellipse.
            };

            projectile_Path = new Path()
            {
                Stroke = Brushes.Red,
                Fill = Brushes.DarkRed,
                StrokeThickness = 2,
                Data = projectile_EllipseGeometry
                //Instantiates the Path object for the Projectile and defines
                //its colour, thickness and adds the EllipseGeometry to it.
            };

            Gamecanvas.Children.Add(projectile_Path);
            //Adds the Projectile's Path to the Canvas.
        }
    }
}
