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
        public Stopwatch timer = new Stopwatch();
        public bool fred = false;

        public MainWindow()
        {
            InitializeComponent();

            timer.Start();

            CompositionTarget.Rendering += newEvent;
        }

        private void newEvent(object sender, EventArgs e)
        {           
            if (jim.Width < 200)
            {
                jim.Width++;
            }
            else
            {                
                if (!fred)
                {
                    Debug.WriteLine(timer.Elapsed);
                }

                fred = true;
            }
        }
    }
}
