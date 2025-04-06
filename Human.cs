
// This is the class for Human Player
public class Human : Player
{
    public Human(string name, List<int> numbersList) : base(name, numbersList)
    {
    }

    public string getName()
    {
        return this.Name;
    }

    public override Move MakeAMove(Board board) // Method to make a move by human
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"{Name}, Lets make a move now!");
                Console.Write("Enter which row : ");
                int row = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Enter which Column : ");
                int column = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Enter which number :");
                int number = int.Parse(Console.ReadLine());

                if (!NumbersInHand.Contains(number))
                {
                    Console.WriteLine("You do not have this number in your hand. Try again!");
                    Console.WriteLine("The numbers that you have right now are : " + string.Join(", ", NumbersInHand));
                    continue;
                }
                if (!board.isSquareBlank(row, column))
                {
                    Console.WriteLine("This square is already taken. Try another one!");
                    continue;
                }
                NumbersInHand.Remove(number);
                return new Move(row, column, number);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Input. Enter rows and columns starting from 1. Please try again");
            }
        }
    }
}