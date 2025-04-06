/* This is the board class that set up all elements an functions necessary of the game board */
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;

public class Board
{
    private int[,] twoDimensionalGrid;
    private int size;
    private Dictionary<int, (int, int)> numbersOnBoard = new Dictionary<int, (int, int)>(); // Each number on the board will have a numerical value and position in grid which is mapped to each other.

    public Board(int size)
    {
        this.size = size;
        this.twoDimensionalGrid = new int[size, size];
    }

    public bool isSquareBlank(int row, int column) // This method will return true or false if the specific square is blank or not.
    {
        return twoDimensionalGrid[row, column] == 0;
    }

    public bool isNumberAlreadyUsed(int number) // This method will return true or false if the number is already used or not.
    {
        return numbersOnBoard.ContainsKey(number);
    }

    public void placeNumberOnBoard(int row, int column, int number) // This method will place the number on the board.
    {
        twoDimensionalGrid[row, column] = number;
        numbersOnBoard.Add(number, (row, column));
    }

    public bool confirmIfWon() // This method will check if the game has a winning row of line or not.
    {
        int sum = 0;
        for (int i = 0; i < size; i++) // This loop is checking all rows and making sure there is a winning sum value or not.
        {
            bool isLastElement = false;
            sum = 0;
            for (int j = 0; j < size; j++)
            {
                if (twoDimensionalGrid[i, j] == 0)
                {
                    break;
                }
                if (j == size - 1) isLastElement = true;
                sum += twoDimensionalGrid[i, j];
            }
            if (isLastElement && sum == getWinningValue()) return true;
        }

        for (int j = 0; j < size; j++) // This loop is checking all columns and making sure there is a winning sum value or not.
        {
            bool isLastElement = false;
            sum = 0;
            for (int i = 0; i < size; i++)
            {
                if (twoDimensionalGrid[i, j] == 0)
                {
                    break;
                }
                if (i == size - 1) isLastElement = true;
                sum += twoDimensionalGrid[i, j];
            }
            if (isLastElement && sum == getWinningValue()) return true;
        }

        sum = 0;
        for (int i = 0; i < size; i++) // This loop is checking the main diagonal from left to right and making sure there is a winning sum value or not.
        {
            if (twoDimensionalGrid[i, i] == 0) break;
            sum += twoDimensionalGrid[i, i];
        }
        if (sum == getWinningValue()) return true;

        sum = 0;
        for (int i = 0; i < size; i++) // This loop is checking the reverse diagonal from right to left and making sure there is a winning sum value or not.
        {
            if (twoDimensionalGrid[i, size - 1 - i] == 0) break;
            sum += twoDimensionalGrid[i, size - 1 - i];
        }
        if (sum == getWinningValue()) return true;

        return false;
    }

    public bool hasNoBlankSquares() //This method will check if the board has any blank spaces left or not
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (twoDimensionalGrid[i, j] == 0) return false;
            }
        }
        return true;
    }

    public void showCurrentBoardStatus() // For each row of the grid, simply print in each line line showing each members of the row
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write("[" + twoDimensionalGrid[i, j] + "]\t");
            }
            Console.Write("\n");
        }

    }

    public int getWinningValue() // Get the value which is needed to win the game in the board when row, column or diagonal is completely added.
    {
        return size * ((int)Math.Pow(size, 2) + 1) / 2;
    }

    public List<(int, int)> getAllEmptySquares() // Method that will get all empty squares in the board.
    {
        List<(int, int)> emptySquareList = new List<(int, int)>();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (twoDimensionalGrid[i, j] == 0)
                {
                    emptySquareList.Add((i, j));
                }
            }
        }
        return emptySquareList;
    }

    public void removeNumberOnBoard(int row, int column)
    {
        int number = twoDimensionalGrid[row, column];
        twoDimensionalGrid[row, column] = 0;
        numbersOnBoard.Remove(number);
    }


}