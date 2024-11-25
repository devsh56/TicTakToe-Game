using System;
using System.Collections.Generic;
//using GridBoard;
//using PlayerCreation;
//using PlayingPT;

namespace TicTacToe
{
    public class TicTakGame
{
    private Queue<Player> players;
    private Board gameBoard;

    public TicTakGame() // Add a constructor to initialize fields
    {
        players = new Queue<Player>();
        gameBoard = new Board(3); // Initialize gameBoard with size 3
    }

    public void InitializeGame()
    {
        // Initialize game and players here
        PlayingPieceX crossPiece = new PlayingPieceX();
        Player player1 = new Player("Player1", crossPiece);

        PlayingPieceO noughtsPiece = new PlayingPieceO();
        Player player2 = new Player("Player2", noughtsPiece);

        players.Enqueue(player1);
        players.Enqueue(player2);
    }
public string StartGame()
{
    bool noWinner = true;
    while (noWinner)
    {
        // Take out the player whose turn it is and add them back later
        Player playerTurn = players.Dequeue();

        // Get the free space from the board
        gameBoard.PrintBoard();
        List<(int, int)> freeSpaces = gameBoard.GetFreeCells();
        if (freeSpaces.Count == 0)
        {
            noWinner = false;
            continue;
        }

        // Read the user input
        Console.WriteLine($"Player: {playerTurn.Name} Enter row,column: ");
        string input = Console.ReadLine();
        string[] values = input.Split(',');
        int inputRow = int.Parse(values[0]);
        int inputColumn = int.Parse(values[1]);

        // Place the piece
        bool pieceAddedSuccessfully = gameBoard.AddPiece(inputRow, inputColumn, playerTurn.PlayingPi); // Access PlayingPi instead of PlayingPiece
        if (!pieceAddedSuccessfully)
        {
            // Player cannot insert the piece into this cell, try another one
            Console.WriteLine("Incorrect position chosen, try again.");
            players.Enqueue(playerTurn); // Player goes back to the queue
            continue;
        }

        players.Enqueue(playerTurn); // Player goes to the back of the queue

        bool winner = IsThereWinner(inputRow, inputColumn, playerTurn.PlayingPi.PieceType); // Access PlayingPi instead of PlayingPiece
        if (winner)
        {
            return playerTurn.Name;
        }
    }

    return "Tie";
}
 public bool IsThereWinner(int row, int column, PlayingPieceType pieceType)
{
    bool rowMatch = true;
    bool columnMatch = true;
    bool diagonalMatch = true;
    bool antiDiagonalMatch = true;

    // Check row
    for (int i = 0; i < gameBoard.Size; i++)
    {
        if (gameBoard.BoardGrid[row, i] == null || gameBoard.BoardGrid[row, i].PieceType != pieceType)
        {
            rowMatch = false;
        }
    }

    // Check column
    for (int i = 0; i < gameBoard.Size; i++)
    {
        if (gameBoard.BoardGrid[i, column] == null || gameBoard.BoardGrid[i, column].PieceType != pieceType)
        {
            columnMatch = false;
        }
    }

    // Check diagonal
    for (int i = 0, j = 0; i < gameBoard.Size; i++, j++)
    {
        if (gameBoard.BoardGrid[i, j] == null || gameBoard.BoardGrid[i, j].PieceType != pieceType)
        {
            diagonalMatch = false;
        }
    }

    // Check anti-diagonal
    for (int i = 0, j = gameBoard.Size - 1; i < gameBoard.Size; i++, j--)
    {
        if (gameBoard.BoardGrid[i, j] == null || gameBoard.BoardGrid[i, j].PieceType != pieceType)
        {
            antiDiagonalMatch = false;
        }
    }

    return rowMatch || columnMatch || diagonalMatch || antiDiagonalMatch;
}


    }
}
