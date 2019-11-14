using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v2._0_
{
    public abstract class GameObject
    {
        protected Game game;

        protected Path path;
        protected Geometry geometry;

        public Path GetPath()
        {
            return path;
            //returns the GameObject's Path object.
        }

        public Geometry GetGeometry()
        {
            return geometry;
            //returns the GameObject's Geometry object.
        }
    }
}
