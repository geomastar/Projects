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
using System.Windows.Threading;

namespace deletepls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int g = 10;
        public box projectile = new box(0, 0, 5, 5);
        public box target = new box(400, 0, 100, 10);

        public MainWindow()
        {
            InitializeComponent();

            testCanvas.Children.Add(projectile.getVisualBox());
            testCanvas.Children.Add(target.getVisualBox());

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 16);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            projectile.setX(projectile.getX() + 10);
            projectile.setY(function(projectile.getX(), 70, 45));

            if(projectile.checkIntersect(target.getHitBox()))
            {
                ((DispatcherTimer)sender).Stop();
            }

            label1.Content = projectile.getY();
        }

        public double function(double x, double u, double angle)
        {
            double radians = (Math.PI/180)*angle;

            double y = x * Math.Tan(radians) - ((g * Math.Pow(x, 2)) / (2 * Math.Pow(u, 2) * Math.Pow(Math.Cos(radians), 2)));

            return y;
        }
    }
}
