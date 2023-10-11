using System.ComponentModel;

namespace TicTacToe.Models
{
    public class Cell : INotifyPropertyChanged
    {
        public const string EmptyCell = "-"; // Adderar en konstant för tom cell

        private string _value = EmptyCell; // Använd konstanten här
        public int Position { get; set; }

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
