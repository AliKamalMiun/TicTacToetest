using System.Windows.Controls;

namespace TicTacToe.Views
{
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
        }

        public GameView(int boardSize)
        {
            InitializeComponent();

            // har inte datacontex här för att den kan override i xaml
        }
    }
}
