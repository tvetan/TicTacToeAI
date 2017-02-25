using System;
using TicTacToe.Contracts;

namespace TicTacToe
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(Grid grid)
        {
            for (int i = 0; i < grid.Size ; i++)
            {
                for (int j = 0; j < grid.Size; j++)
                {
                    Console.Write(grid.GetTileAtPosition(i, j).TileType + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintEndGame(GameState gameState, TileTypes winnerTileType)
        {
            if (GameState.Tie == gameState)
            {
                Console.WriteLine("Tie");
                return;
            }

            Console.WriteLine("Winner is {0}", winnerTileType);
        }
    }
}
