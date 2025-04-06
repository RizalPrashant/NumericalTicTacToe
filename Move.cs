/* A data class for player's and computer's move. Each move that is done has a number and a designated row and column in the grid to move to */

public class Move
{
    public int Row { get; set; }
    public int Column { get; set; }
    public int Number { get; set; }

    public Move(int row, int column, int number)
    {
        this.Row = row;
        this.Column = column;
        this.Number = number;
    }
}