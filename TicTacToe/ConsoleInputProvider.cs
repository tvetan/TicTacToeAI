using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Contracts;

namespace TicTacToe
{
    public class ConsoleInputProvider : IInputProvider
    {
        public Position GetNextPosition(TileTypes playerTileType, Grid grid)
        {
            Console.WriteLine("What is your next position for " + playerTileType);
            var nextPosition = GetNextPosition(grid);

            return new Position { X = nextPosition[0], Y = nextPosition[1] };
        }

        private static List<int> GetNextPosition(Grid grid)
        {
            List<int> nextPosition = null;
            bool isValidPosition = false;
            while (!isValidPosition)
            {
                var nextPositionInput = Console.ReadLine();
                nextPosition = nextPositionInput.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToList();

                isValidPosition = nextPosition.Count == 2 && grid.IsValidPosition(nextPosition[0], nextPosition[1]);
            }

            return nextPosition;
        }
    }
}
