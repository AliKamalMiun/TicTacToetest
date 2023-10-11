using TicTacToe.Models;
using System.Collections.Generic;

public class GameBoard
{
    public int Size { get; private set; }
    public List<List<Cell>> Cells { get; private set; }

    // Konstruktor för att initiera spelbrädet
    public GameBoard(int size)
    {
        Size = size;
        Cells = new List<List<Cell>>();

        for (int i = 0; i < size; i++)
        {
            var row = new List<Cell>();
            for (int j = 0; j < size; j++)
            {
                row.Add(new Cell());
            }
            Cells.Add(row);
        }
    }

    // Kolla om någon spelare har vunnit
    public bool CheckForWinner(int winLength, string player)
    {
        return CheckRows(winLength, player) || CheckColumns(winLength, player) || CheckDiagonals(winLength, player);
    }

    // Kolla rader för vinst
    private bool CheckRows(int winLength, string player)
    {
        for (int row = 0; row < Size; row++)
        {
            int count = 0;
            for (int col = 0; col < Size; col++)
            {
                if (Cells[row][col].Value == player)
                    count++;
                else
                    count = 0;

                if (count == winLength)
                    return true;
            }
        }
        return false;
    }

    // Kolla kolumner för vinst
    private bool CheckColumns(int winLength, string player)
    {
        for (int col = 0; col < Size; col++)
        {
            int count = 0;
            for (int row = 0; row < Size; row++)
            {
                if (Cells[row][col].Value == player)
                    count++;
                else
                    count = 0;

                if (count == winLength)
                    return true;
            }
        }
        return false;
    }

    // Kolla olika vinklar för vinst
    private bool CheckDiagonals(int winLength, string player)
    {
        // Kolla diagonalt
        for (int i = 0; i <= Size - winLength; i++)
        {
            for (int j = 0; j <= Size - winLength; j++)
            {
                int count = 0;
                for (int k = 0; k < winLength; k++)
                {
                    if (Cells[i + k][j + k].Value == player)
                        count++;

                    if (count == winLength)
                        return true;
                }
            }
        }

        // samma här ungefär tittar ifall det finns vinst
        for (int i = 0; i <= Size - winLength; i++)
        {
            for (int j = winLength - 1; j < Size; j++)
            {
                int count = 0;
                for (int k = 0; k < winLength; k++)
                {
                    if (Cells[i + k][j - k].Value == player)
                        count++;

                    if (count == winLength)
                        return true;
                }
            }
        }

        return false;
    }
}
