// The interface for player class. A player makes moves on the board. A player can be human or a computer.
// All player has a certain name and available numbers to play with them. They way they move can be different depending on if it is a Human or a Computer.
public interface PlayerInterface
{
    Move MakeAMove(Board board); // interface method to make a move on the board.
}