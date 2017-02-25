using TicTacToe.Contracts;

namespace TicTacToe
{
    public class GameManager
    {
        private Grid grid;
        private IPrinter printer;
        private GameState gameState;
        private TileTypes currentPlayerTileType;
        private IGameStateChecker gameStateChecker;
        private ITicTacToeSolver solver;

        public GameManager(IPrinter printer, IGameStateChecker gameStateChecker, ITicTacToeSolver solver)
        {
            this.grid = new Grid();
            this.printer = printer;
            this.gameStateChecker = gameStateChecker;
            this.solver = solver;
        }

        public void Start()
        {
            printer.Print(this.grid);

            this.gameState = GameState.Running;
            this.currentPlayerTileType = TileTypes.O;

            RunGame();

            printer.PrintEndGame(this.gameState, this.currentPlayerTileType);
        }

        private void RunGame()
        {
            while (this.gameState == GameState.Running)
            {
                this.currentPlayerTileType = this.currentPlayerTileType.GetNextTile();

                var nextPosition = this.GetNextPosition();
                this.grid.SetValueAtPosition(nextPosition.X, nextPosition.Y, this.currentPlayerTileType);

                printer.Print(this.grid);

                this.gameState = this.gameStateChecker.GetGameState(this.grid);
            }
        }

        public Position GetNextPosition()
        {
            //if (this.currentPlayerTile == TileTypes.X)
            //{
            //    var humanNextPosition = GetNextPositionFromConsole();
            //    return new Position { X = humanNextPosition[0], Y = humanNextPosition[1] };
            //}

            var nextPosition = this.solver.GetNextPosition(this.grid, this.currentPlayerTileType);
            return nextPosition;
        }
    }
}
