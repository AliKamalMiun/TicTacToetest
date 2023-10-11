using System.Windows.Input;
using System;
using TicTacToe.Commands;

namespace TicTacToe.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        public ICommand StartGameCommand { get; private set; }

        public StartViewModel()
        {
            StartGameCommand = new RelayCommand<object>(StartGame, CanStartGame);
        }

        private void StartGame(object parameter)
        {
            // lägger breakpoint här
            if (int.TryParse(parameter as string, out int boardSize))
            {
                GameStarted?.Invoke(boardSize);
            }
        }

        private bool CanStartGame(object parameter)
        {
            return true; // Ska jag lägga en check ifall spelet börjar?
        }

        public event Action<int> GameStarted;
    }
}
