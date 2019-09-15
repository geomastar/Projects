using System.Windows;

namespace Metal_Lynch__v1._0_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game game = new Game(gameWindow, gameCanvas, GUICanvas);
            //Creates the instance of the Game class, and gives it access
            //to the gameWindow, gameCanvas and GUICanvas.
        }
    }
}
