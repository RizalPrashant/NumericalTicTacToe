/* This class is the Game Generator that initializes the game and handles the flow of the game.
*/
using System.Net;

public class GameGenerator
{
    private Board board;
    private PlayerInterface player1;
    private PlayerInterface player2;

    private PlayerInterface currentPlayer;
    private int boardSize;
    private int gameMode;

    public void Start() // Very first method the entrypoint of the game generator. This is where user chooses new game, load game or seeing help menu.
    {
        try
        {
            Console.WriteLine("Welcome to the Numerical Tic Tac Toe");
            Console.WriteLine("Enter (1) for New Game (2) for Load Game and (3) for Help Menu");
            int startMode = int.Parse(Console.ReadLine());
            if (startMode == 1)
            {
                NewGame();
            }
            else if (startMode == 2)
            {
                LoadGame();
            }
            else if (startMode == 3)
            {
                HelpMenu();
                NewGame();
            }
            else
            {
                Console.WriteLine("You must choose 1, 2, or 3. Terminating Application");

            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid Input. You must choose 1,2 or 3");
        }
    }

    private void NewGame() // This is the initialisation of a new game
    {
        try
        {
            Console.WriteLine("Enter the size of the board : ");
            boardSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter (1) for Two player competition or (2) for Human Versus Computer : ");
            gameMode = int.Parse(Console.ReadLine());

            board = new Board(boardSize);

            List<int> player1list = new List<int>();
            List<int> player2list = new List<int>();
            for (int i = 1; i <= boardSize * boardSize; i++)
            {
                if (i % 2 == 0)
                {
                    player2list.Add(i);
                }
                else
                {
                    player1list.Add(i);
                }
            }

            if (gameMode == 1)
            {
                player1 = new Human("Player 1", player1list);
                player2 = new Human("Player 2", player2list);
            }
            else if (gameMode == 2)
            {
                player1 = new Human("Player 1", player1list);
                player2 = new Computer("Player 2", player2list);
            }
            else
            {
                Console.WriteLine("Please follow the instructions when choosing GameMode no need to act all crazy. Starting a Human vs Computer Game for now.");
                gameMode = 2;
                player1 = new Human("Player 1", player1list);
                player2 = new Computer("Player 2", player2list);
            }

            Console.WriteLine("Player 1 has Numbers :" + string.Join(", ", player1list));
            Console.WriteLine("Player 2 has Numbers :" + string.Join(", ", player2list));
            Console.WriteLine("Winning goal number is :" + board.getWinningValue());

            currentPlayer = player1;
            GameFlow();
        }
        catch (Exception e)
        {
            Console.WriteLine("Size of the board has to be more than 1 and Game mode is either 1 or 2.");
            NewGame();
        }
    }

    private void LoadGame() //method to load the game
    {

    }

    private void GameFlow() // after new game is initiatlized, this method will be the flow of the game
    {
        board.showCurrentBoardStatus();
        Move currentMove = currentPlayer.MakeAMove(board);
        board.placeNumberOnBoard(currentMove.Row, currentMove.Column, currentMove.Number);
        if (board.confirmIfWon())
        {
            if (gameMode == 1)
            {
                if (currentPlayer == player1)
                {
                    Console.WriteLine("The game is over, Player 1 has won");
                }
                else
                {
                    Console.WriteLine("The game is over, Player 2 has won");
                }

            }
            else
            {
                if (currentPlayer == player1)
                {
                    Console.WriteLine("The game is over, Player 1 has won");
                }
                else
                {
                    Console.WriteLine("The game is over, Computer has won");
                }

            }
            board.showCurrentBoardStatus();
        }
        else if (board.hasNoBlankSquares())
        {
            Console.WriteLine("The game is a tie");
            board.showCurrentBoardStatus();
        }
        else
        {
            ChangePlayerTurn();
            GameFlow();
        }

    }

    private void ChangePlayerTurn() // simple method to switch player's turn
    {
        currentPlayer = currentPlayer == player1 ? player2 : player1;
    }

    private void SaveGame() // method to automatically save the game
    {

    }

    private void HelpMenu() //method to show a help guide to user.
    {
        Help.showHelp();
    }



}