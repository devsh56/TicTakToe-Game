using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        public int Size { get; }
        public PlayingPiece[,] BoardGrid { get; }

        // Constructor
        public Board(int size)
        {
            Size = size;
            BoardGrid = new PlayingPiece[size, size];
        }

        // Add a piece to the board at the specified position
        public bool AddPiece(int row, int column, PlayingPiece playingPiece)
        {
            if (BoardGrid[row, column] != null)
            {
                return false; // If the cell is already occupied, return false
            }

            BoardGrid[row, column] = playingPiece; // Place the piece
            return true;
        }

        // Get all free (empty) cells on the board
        public List<(int, int)> GetFreeCells()
        {
            var freeCells = new List<(int, int)>();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (BoardGrid[i, j] == null)
                    {
                        freeCells.Add((i, j)); // Add the free cell's coordinates
                    }
                }
            }

            return freeCells;
        }

        // Print the current board state to the console
        public void PrintBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (BoardGrid[i, j] != null)
                    {
                        Console.Write($"{BoardGrid[i, j].PieceType}   ");
                    }
                    else
                    {
                        Console.Write("    "); // Empty cell
                    }
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
    }
}
