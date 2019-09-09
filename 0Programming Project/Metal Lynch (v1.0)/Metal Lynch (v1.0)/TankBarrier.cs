using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v1._0_
{
    public class TankBarrier
    {
        private Path tankBarrier_Path;
        private LineGeometry tankBarrier_LineGeometry;

        public TankBarrier(Canvas canvas, int X)
        {
            tankBarrier_LineGeometry = new LineGeometry()
            {
                StartPoint = new Point(X, 450),
                EndPoint = new Point(X, 0)
                //Instantiates the LineGeometry object and makes it a
                //vertical line of the same height as the canvas, and
                //in the X position given as an argument in the 
                //constructor.
            };

            tankBarrier_Path = new Path()
            {
                Data = tankBarrier_LineGeometry
                //Instantiates the Path object and assigns the LineGeometry
                //object as it's data.
            };

            canvas.Children.Add(tankBarrier_Path);
        }

        public Path GetTankBarrier_Path()
        {
            return tankBarrier_Path;
            //Returns the Path object.
        }
    }
}
