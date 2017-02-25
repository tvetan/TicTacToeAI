namespace TicTacToe
{
    public class Program
    {
        public static void Main()
        {
            var gridConsolePrinter = new ConsolePrinter();
            var gameStateChecker = new GameStateChecker();
            var minMaxSolver = new MinMaxSolver(gameStateChecker);

            var gameManager = new GameManager(gridConsolePrinter, gameStateChecker, minMaxSolver);

            gameManager.Start();
        }
    }
}
