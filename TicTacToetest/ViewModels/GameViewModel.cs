using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows; // För MessageBox
using System.Windows.Input;
using TicTacToe.Models;
using TicTacToe.Commands;

namespace TicTacToe.ViewModels
{
    public class GameViewModel : BaseViewModel

    //Logiken för brädspelet finns i klassen GameBoard 
    {
        private ObservableCollection<Cell> _board;// ObservableCollection är användbart i MVVM-arkitekturen eftersom den automatiskt skickar 
        //meddelanden när objekt läggs till, tas bort eller ändras, vilket underlättar bindning mellan vyn och datamodellen.
        private GameBoard _gameBoard; // Instans av spelbrädet

        private const string PlayerX = "X";
        private const string PlayerO = "O";
        private int BoardSize;  // Ändrade detta till en variabel istället för en konstant, kanske inte hårdkoda storlek?
        private int WinLength;
     

        public ObservableCollection<Cell> Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged(nameof(Board)); // Skickar meddelande till vyn att Board har ändrats
            }
        }

        public ICommand PlayTurnCommand { get; } //Särkiljer mellan kommandon och metoder

        // Standardkonstruktor
        public GameViewModel() : this(5) { }  // Standardstorlek är 5

        // Konstruktor som initierar brädet
        public GameViewModel(int boardSize)
        {
            BoardSize = boardSize;  // Initierar den dynamiska brädstorleken
            _gameBoard = new GameBoard(boardSize);
            Board = new ObservableCollection<Cell>();
            WinLength = (boardSize == 3) ? 3 : 5;
            for (int i = 0; i < boardSize * boardSize; i++) // Initierar brädet med tomma celler
            {
                Board.Add(new Cell { Position = i });
            }

            PlayTurnCommand = new RelayCommand<int>(PlayTurn, CanPlay); 
        }

        // Utför ett drag
        public void PlayTurn(int position)
        {
            if (CanPlay(position))
            {
                var mark = (Board.Count(b => b.Value != Cell.EmptyCell) % 2 == 0) ? PlayerX : PlayerO;
                Board[position].Value = mark;

                int row = position / BoardSize;
                int col = position % BoardSize;

                _gameBoard.Cells[row][col].Value = mark;

                // Kolla om någon spelare har vunnit
                if (_gameBoard.CheckForWinner(WinLength, mark))
                {
                    MessageBox.Show($"Spelare {mark} vinner!", "Grattis!", MessageBoxButton.OK);
                }
            }
        }

        // Kontrollera om draget kan utföras
        private bool CanPlay(int position)
        {
            return position >= 0 && position < Board.Count && Board[position].Value == Cell.EmptyCell;
        }
    }
}
