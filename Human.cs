
public class Human : Player
{
    public Human(string name, List<int> numbersList) : base(name, numbersList)
    {
    }

    public override Move MakeAMove(Board board)
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"{Name}, Lets make a move now!");
                Console.Write("Enter which row : ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Enter which Column : ");
                int column = int.Parse(Console.ReadLine());
                Console.Write("Enter which number :");
                int number = int.Parse(Console.ReadLine());

                if (!NumbersInHand.Contains(number))
                {
                    Console.WriteLine("You do not have this number in your hand. Try again!");
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
                Console.WriteLine("Invalid Input. Please try again");
            }
        }
    }
}