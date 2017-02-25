using TicTacToe.Contracts;

namespace TicTacToe
{
    public class MinMaxSolver : ITicTacToeSolver
    {
        private GameStateChecker stateChecker;
        private TileTypes startingPlayerTile;

        public MinMaxSolver(GameStateChecker stateChecker)
        {
            this.stateChecker = stateChecker;
        }

        public Position GetNextPosition(Grid grid, TileTypes currentPlayerTile)
        {
            this.startingPlayerTile = currentPlayerTile;

            var gridUtilityModel = Maximize(grid, currentPlayerTile, int.MinValue, int.MaxValue);
            return gridUtilityModel.Position;
        }

        public MinMaxModel Minimize(Grid grid, TileTypes currentPlayerTile, int alpha, int beta)
        {
            var gameState = this.stateChecker.GetGameState(grid);
            if (gameState != GameState.Running)
            {
                var utility = Utility(gameState);
                return new MinMaxModel(grid, utility, null);
            }

            int minUtility = int.MaxValue;
            Position minPosition = null;

            var emptyTiles = grid.GetEmptyTiles();
            foreach (var tile in emptyTiles)
            {
                var clonedGrid = grid.Clone();
                clonedGrid.SetValueAtPosition(tile.Position.X, tile.Position.Y, currentPlayerTile);

                var result = this.Maximize(clonedGrid, currentPlayerTile.GetNextTile(), alpha, beta);
                if (minUtility > result.Utility)
                {
                    minUtility = result.Utility;
                    minPosition = new Position { X = tile.Position.X, Y = tile.Position.Y };
                }

                if (minUtility <= alpha)
                {
                    break;
                }

                if (minUtility < beta)
                {
                    beta = minUtility;
                }
            }

            return new MinMaxModel(grid, minUtility, minPosition);
        }

        public MinMaxModel Maximize(Grid grid, TileTypes currentPlayerTile, int alpha, int beta)
        {
            var gameState = this.stateChecker.GetGameState(grid);
            if (gameState != GameState.Running)
            {
                var utility = Utility(gameState);
                return new MinMaxModel(grid, utility, null);
            }

            int maxUtility = int.MinValue;
            Position maxPosition = null;

            var emptyTiles = grid.GetEmptyTiles();
            foreach (var tile in emptyTiles)
            {
                var clonedGrid = grid.Clone();
                clonedGrid.SetValueAtPosition(tile.Position.X, tile.Position.Y, currentPlayerTile);

                var result = this.Minimize(clonedGrid, currentPlayerTile.GetNextTile(), alpha, beta);
                if (maxUtility < result.Utility)
                {
                    maxUtility = result.Utility;
                    maxPosition = new Position { X = tile.Position.X, Y = tile.Position.Y };
                }

                if (maxUtility >= beta)
                {
                    break;
                }

                if (maxUtility > alpha)
                {
                    alpha = maxUtility;
                }
            }

            return new MinMaxModel(grid, maxUtility, maxPosition);
        }

        private int Utility(GameState gameState)
        {
            if ((gameState == GameState.OWinner && this.startingPlayerTile == TileTypes.O)
                || (gameState == GameState.XWinner && this.startingPlayerTile == TileTypes.X))
            {
                return 1;
            }

            if ((gameState == GameState.OWinner && this.startingPlayerTile == TileTypes.X)
                || (gameState == GameState.XWinner && this.startingPlayerTile == TileTypes.O))
            {
                return -1;
            }

            return 0;
        }
    }
}
