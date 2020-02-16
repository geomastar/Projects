using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v3._0_
{
    public class Sniper : Projectile
    {
        public Sniper(Game game)
        {
            BaseConstructor(game);

            geometry = new EllipseGeometry()
            {
                Transform = projectile_TransformGroup,
                RadiusX = 4,
                RadiusY = 4
            };
            path = new Path()
            {
                Stroke = Brushes.DarkSlateGray,
                Fill = Brushes.DarkSlateGray,
                StrokeThickness = 2,
                Data = geometry
            };

            projectile_Damage = 60;
        }
    }
}
