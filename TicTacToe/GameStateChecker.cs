using TicTacToe.Contracts;

namespace TicTacToe
{
    public class GameStateChecker : IGameStateChecker
    {
        public bool IsEnd(Grid grid)
        {
            var gameState = this.GetGameState(grid);
            return gameState != GameState.Running;
        }

        public GameState GetGameState(Grid grid)
        {
            // First column
            if (grid.GetTileAtPosition(0, 0).TileType != TileTypes.Empty
                && grid.GetTileAtPosition(0, 0) == grid.GetTileAtPosition(1, 0)
                && grid.GetTileAtPosition(1, 0) == grid.GetTileAtPosition(2, 0))
            {
                return this.GetGameStateFromTileType(grid.GetTileAtPosition(0, 0).TileType);
            }

            // Second column
            if (grid.GetTileAtPosition(0, 1).TileType != TileTypes.Empty
                && grid.GetTileAtPosition(0, 1) == grid.GetTileAtPosition(1, 1)
                && grid.GetTileAtPosition(1, 1) == grid.GetTileAtPosition(2, 1))
            {
                return this.GetGameStateFromTileType(grid.GetTileAtPosition(0, 1).TileType);
            }

            // Third column
            if (grid.GetTileAtPosition(0, 2).TileType != TileTypes.Empty
                && grid.GetTileAtPosition(0, 2) == grid.GetTileAtPosition(1, 2)
                && grid.GetTileAtPosition(1, 2) == grid.GetTileAtPosition(2, 2))
            {
                return this.GetGameStateFromTileType(grid.GetTileAtPosition(0, 2).TileType);
            }

            // First row
            if (grid.GetTileAtPosition(0, 0).TileType != TileTypes.Empty
                && grid.GetTileAtPosition(0, 0) == grid.GetTileAtPosition(0, 1)
                && grid.GetTileAtPosition(0, 1) == grid.GetTileAtPosition(0, 2))
            {
                return this.GetGameStateFromTileType(grid.GetTileAtPosition(0, 0).TileType);
            }

            // Second row
            if (grid.GetTileAtPosition(1, 0).TileType != TileTypes.Empty
                && grid.GetTileAtPosition(1, 0) == grid.GetTileAtPosition(1, 1)
                && grid.GetTileAtPosition(1, 1) == grid.GetTileAtPosition(1, 2))
            {
                return this.GetGameStateFromTileType(grid.GetTileAtPosition(1, 0).TileType);
            }

            // Third row
            if (grid.GetTileAtPosition(2, 0).TileType != TileTypes.Empty
                && grid.GetTileAtPosition(2, 0) == grid.GetTileAtPosition(2, 1)
                && grid.GetTileAtPosition(2, 1) == grid.GetTileAtPosition(2, 2))
            {
                return this.GetGameStateFromTileType(grid.GetTileAtPosition(2, 0).TileType);
            }

            //Diagonal
            if (grid.GetTileAtPosition(0, 0).TileType != TileTypes.Empty
                && grid.GetTileAtPosition(0, 0) == grid.GetTileAtPosition(1, 1)
                && grid.GetTileAtPosition(1, 1) == grid.GetTileAtPosition(2, 2))
            {
                return this.GetGameStateFromTileType(grid.GetTileAtPosition(0, 0).TileType);
            }

            //Reverse diagonal
            if (grid.GetTileAtPosition(0, 2).TileType != TileTypes.Empty
                && grid.GetTileAtPosition(0, 2) == grid.GetTileAtPosition(1, 1)
                && grid.GetTileAtPosition(1, 1) == grid.GetTileAtPosition(2, 0))
            {
                return this.GetGameStateFromTileType(grid.GetTileAtPosition(0, 2).TileType);
            }

            if (grid.GetEmptyTilesCount() == 0)
            {
                return GameState.Tie;
            }

            return GameState.Running;
        }

        private GameState GetGameStateFromTileType(TileTypes tileType)
        {
            if (tileType == TileTypes.X)
            {
                return GameState.XWinner;
            }

            if (tileType == TileTypes.O)
            {
                return GameState.OWinner;
            }

            return GameState.Tie;
        }
    }
}
