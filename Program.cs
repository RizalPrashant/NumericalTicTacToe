/* This class is the class that holds the main method. The only job of this class
 is to initialize the Game generator and start the console game application */
public class Program
{
    // This is the main method of the Numerical Tic Tac Toe Application.
    public static void Main()
    {
        GameGenerator generator = new GameGenerator();
        generator.Start();
    }

}