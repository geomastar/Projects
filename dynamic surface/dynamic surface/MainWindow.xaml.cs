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

        public MainWindow()
        {            
            InitializeComponent();

            theLine = new Line();

            theLine.X1 = 10;
            theLine.Y1 = 10;
            theLine.X2 = 50;
            theLine.Y2 = 10;

            theCanvas.Children.Add(theLine);
        }
    }
}
