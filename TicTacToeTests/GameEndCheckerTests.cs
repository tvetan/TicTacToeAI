using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeTests
{
    [TestClass]
    public class GameEndCheckerTests
    {
        [TestMethod]
        public void WhenGridIsEmptyShouldReturnTrue()
        {
            var grid = new Grid();
            var gameEndChecker = new GameStateChecker();

            var isEnded = gameEndChecker.IsEnd(grid);
            Assert.IsFalse(isEnded);
        }

        [TestMethod]
        public void WhenDiagonalIsFilledShouldReturnTrue()
        {
            var grid = new Grid();

            grid.SetValueAtPosition(0, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 1, TileTypes.X);
            grid.SetValueAtPosition(2, 2, TileTypes.X);

            var gameEndChecker = new GameStateChecker();

            var isEnded = gameEndChecker.IsEnd(grid);
            Assert.IsTrue(isEnded);
        }

        [TestMethod]
        public void WhenReversedDiagonalIsFilledShouldReturnTrue()
        {
            var grid = new Grid();

            grid.SetValueAtPosition(0, 2, TileTypes.X);
            grid.SetValueAtPosition(1, 1, TileTypes.X);
            grid.SetValueAtPosition(2, 0, TileTypes.X);

            var gameEndChecker = new GameStateChecker();

            var isEnded = gameEndChecker.IsEnd(grid);
            Assert.IsTrue(isEnded);
        }

        [TestMethod]
        public void WhenReversedDiagonalIsFilledWithDifferentShouldReturnFalse()
        {
            var grid = new Grid();

            grid.SetValueAtPosition(0, 2, TileTypes.X);
            grid.SetValueAtPosition(1, 1, TileTypes.X);
            grid.SetValueAtPosition(2, 0, TileTypes.O);

            var gameEndChecker = new GameStateChecker();

            var isEnded = gameEndChecker.IsEnd(grid);
            Assert.IsFalse(isEnded);
        }

        [TestMethod]
        public void GetGameShouldReturnTieWhenAllTilesAreSet()
        {
            var grid = new Grid();

            grid.SetValueAtPosition(0, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 1, TileTypes.O);
            grid.SetValueAtPosition(0, 1, TileTypes.O);
            grid.SetValueAtPosition(0, 2, TileTypes.X);
            grid.SetValueAtPosition(1, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 2, TileTypes.O);
            grid.SetValueAtPosition(2, 0, TileTypes.O);
            grid.SetValueAtPosition(2, 1, TileTypes.X);
            grid.SetValueAtPosition(2, 2, TileTypes.X);

            var gameEndChecker = new GameStateChecker();

            var gameState = gameEndChecker.GetGameState(grid);
            Assert.AreEqual(GameState.Tie, gameState);
        }

        [TestMethod]
        public void GetGameShouldReturnWinnerXWhenXHasSetDiagonal()
        {
            var grid = new Grid();

            grid.SetValueAtPosition(0, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 1, TileTypes.X);
            grid.SetValueAtPosition(0, 1, TileTypes.O);
            grid.SetValueAtPosition(0, 2, TileTypes.X);
            grid.SetValueAtPosition(1, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 2, TileTypes.O);
            grid.SetValueAtPosition(2, 0, TileTypes.O);
            grid.SetValueAtPosition(2, 2, TileTypes.X);

            var gameEndChecker = new GameStateChecker();

            var gameState = gameEndChecker.GetGameState(grid);
            Assert.AreEqual(GameState.XWinner, gameState);
        }

        [TestMethod]
        public void GetGameShouldReturnWinnerOWhenXHasSetThirdColumn()
        {
            var grid = new Grid();

            grid.SetValueAtPosition(0, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 1, TileTypes.X);
            grid.SetValueAtPosition(0, 1, TileTypes.O);
            grid.SetValueAtPosition(0, 2, TileTypes.O);
            grid.SetValueAtPosition(1, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 2, TileTypes.O);
            grid.SetValueAtPosition(2, 0, TileTypes.O);
            grid.SetValueAtPosition(2, 2, TileTypes.O);

            var gameEndChecker = new GameStateChecker();

            var gameState = gameEndChecker.GetGameState(grid);
            Assert.AreEqual(GameState.OWinner, gameState);
        }
    }
}
