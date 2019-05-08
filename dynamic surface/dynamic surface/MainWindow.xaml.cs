using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dynamic_surface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Line theLine;
        Path thePath;
        EllipseGeometry theEllipseGeometry;

        public MainWindow()
        {            
            InitializeComponent();

            theLine = new Line
            {
                X1 = 0,
                Y1 = 300,
                X2 = 800,
                Y2 = 300,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };



            theEllipseGeometry = new EllipseGeometry
            {
                Center = new Point(50, 50),
                RadiusX = 25,
                RadiusY = 25
            };

            thePath = new Path
            {
                Stroke = Brushes.Blue,
                Fill = Brushes.MediumBlue,
                StrokeThickness = 2,
                Data = theEllipseGeometry
            };



            theCanvas.Children.Add(thePath);
        }
    }
}
