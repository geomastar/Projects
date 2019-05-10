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

            Path floor = new Path();
            floor.Stroke = Brushes.Black;


            theCanvas.Children.Add(floor);
        }
    }
}
