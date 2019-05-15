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

namespace map_prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Floor newFloor;

        public MainWindow()
        {
            InitializeComponent();

            newFloor = new Floor(0, 350, 800, 350);

            VisualLayer.Children.Add(newFloor.GetFloor_Path());
        }

        private void addCraterButton_Click(object sender, RoutedEventArgs e)
        {
            newFloor.AddCrater(Convert.ToDouble(addCraterXTextBox.Text));

            addCraterButton.IsEnabled = false;
        }
    }
}
