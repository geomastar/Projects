using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projectilePrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Projectile theProjectile;

        Rectangle jim;

        public MainWindow()
        {
            InitializeComponent();

            theProjectile = new Projectile(20, 20, 300, 300,
                95, 50,
                10);

            theCanvas.Children.Add(theProjectile.GetProjectile_Path());
        }

        private void launchButton_Click(object sender, RoutedEventArgs e)
        {
            theProjectile.SendProjectile();
        }
    }
}
