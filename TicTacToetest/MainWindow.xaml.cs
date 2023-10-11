using System.Windows;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // sätter DataContext till MainViewModel i konstruktören.
            DataContext = new ViewModels.MainViewModel();
        }
    }
}
