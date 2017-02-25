using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeTests
{
    [TestClass]
    public class MinMaxSolverTests
    {
        [TestMethod]
        public void WhenEmptyGridThe0x0PositionShouldBeSet()
        {
            var grid = new Grid();
            var gameStateChecker = new GameStateChecker();
            var minMaxSolver = new MinMaxSolver(gameStateChecker);

            var actualPosition = minMaxSolver.GetNextPosition(grid, TileTypes.X);
            var expectedPosition = new Position { X = 0, Y = 0 };

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
        }

        [TestMethod]
        public void WhenTwoPosiblePositionsTheBetterShouldBeSet()
        {
            var grid = new Grid();

            grid.SetValueAtPosition(0, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 1, TileTypes.O);
            grid.SetValueAtPosition(0, 1, TileTypes.O);
            grid.SetValueAtPosition(0, 2, TileTypes.X);
            grid.SetValueAtPosition(1, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 2, TileTypes.O);
            grid.SetValueAtPosition(2, 0, TileTypes.O);

            var gameStateChecker = new GameStateChecker();
            var minMaxSolver = new MinMaxSolver(gameStateChecker);

            var actualPosition = minMaxSolver.GetNextPosition(grid, TileTypes.X);
            var expectedPosition = new Position { X = 2, Y = 1 };

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
        }
    }
}
