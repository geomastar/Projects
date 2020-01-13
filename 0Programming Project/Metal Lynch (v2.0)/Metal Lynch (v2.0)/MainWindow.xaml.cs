using System.Windows;

namespace Metal_Lynch__v2._0_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Framework framework = new Framework(Window);
            //Creates an instance of the Framework class and gives it access
            //to the Window.
        }
    }
}
