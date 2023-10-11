namespace TicTacToe.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainViewModel()
        {
            SwitchToStartView();
        }

        private void OnGameStarted(int boardSize)
        {

            //brytpunkt för se varför den inte startar spel
            CurrentViewModel = new GameViewModel(boardSize);
        }

        private void SwitchToStartView()
        {
            var startViewModel = new StartViewModel();

            startViewModel.GameStarted += OnGameStarted;
            CurrentViewModel = startViewModel;

        }

    }
}
