using System;
//using TicTakToe;  // Correct namespace for your game logic

namespace TicTacToe // Removed space in the namespace name
{
    class Program
    {
        static void Main(string[] args)
        {
            // Corrected class name to match your TicTacToeGame class
            TicTakGame game = new TicTakGame();
            game.InitializeGame();
            Console.WriteLine("Game winner is: " + game.StartGame());
        }
    }
}
