
using System.Reflection.Metadata.Ecma335;

//This is the class for Computer Player.
public class Computer : Player
{
    public Computer(string name, List<int> numbersList) : base(name, numbersList)
    {

    }

    public string getName()
    {
        return this.Name;
    }

    public override Move MakeAMove(Board board) //Method to make a winning move otherwise a valid move
    {
        Console.WriteLine("Computer is now making the move ...");
        Move winningMove = possibleWinningMove(board);
        if (winningMove != null)
        {
            return winningMove;
        }
        List<(int, int)> emptySquareList = board.getAllEmptySquares();
        Random rand = new Random();
        (int row, int column) = emptySquareList[rand.Next(emptySquareList.Count)]; // getting random row and colum that is empty.
        int number = NumbersInHand[rand.Next(NumbersInHand.Count)]; // getting random number in the hand that is available
        NumbersInHand.Remove(number);
        return new Move(row, column, number);
    }

    private Move possibleWinningMove(Board board) // Method to make a winning move if it exists
    {
        List<(int, int)> emptySquareList = board.getAllEmptySquares();
        foreach ((int row, int column) in emptySquareList)
        {
            foreach (int number in NumbersInHand)
            {
                board.placeNumberOnBoard(row, column, number);
                if (board.confirmIfWon())
                {
                    board.removeNumberOnBoard(row, column);
                    return new Move(row, column, number);
                }
                else
                {
                    board.removeNumberOnBoard(row, column);
                }
            }

        }
        return null;
    }
}