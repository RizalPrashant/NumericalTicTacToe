// This is an abstract Player class. Each player has their name and a list of cards available to play.
// However, the way the player moves depending on human or computer is different so that will be an abstract method.

using System.Dynamic;

public abstract class Player : PlayerInterface
{
    public string Name { get; set; }
    public List<int> NumbersInHand { get; set; }

    public Player(string name, List<int> numbersList)
    {
        this.Name = name;
        this.NumbersInHand = numbersList;
    }

    public abstract Move MakeAMove(Board board); // abstract method since it will differ based on human or computer.
}