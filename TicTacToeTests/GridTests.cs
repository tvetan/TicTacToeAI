using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeTests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void GridShouldReturn9EmptyTilesWhenInitialized()
        {
            var grid = new Grid();

            var actualEmtpyTilesCount = grid.GetEmptyTilesCount();

            Assert.AreEqual(9, actualEmtpyTilesCount);
        }

        [TestMethod]
        public void GridShouldReturnCorrectEmptyTilesCount()
        {
            var grid = new Grid();

            grid.SetValueAtPosition(0, 0, TileTypes.X);
            grid.SetValueAtPosition(1, 1, TileTypes.O);
            grid.SetValueAtPosition(2, 2, TileTypes.X);

            var actualEmtpyTilesCount = grid.GetEmptyTilesCount();

            Assert.AreEqual(6, actualEmtpyTilesCount);
        }

        [TestMethod]
        public void IsValidMoveShouldReturnTrueForEmptyTile()
        {
            var grid = new Grid();

            var isValidPosition = grid.IsValidPosition(1, 1);

            Assert.IsTrue(isValidPosition);
        }

        [TestMethod]
        public void IsValidMoveShouldReturnFalseForXTile()
        {
            var grid = new Grid();
            grid.SetValueAtPosition(1, 1, TileTypes.X);

            var isValidPosition = grid.IsValidPosition(1, 1);

            Assert.IsFalse(isValidPosition);
        }

        [TestMethod]
        public void IsValidMoveShouldReturnFalseForInvalidPosition()
        {
            var grid = new Grid();

            var isValidPosition = grid.IsValidPosition(-1, 1);

            Assert.IsFalse(isValidPosition);
        }

        [TestMethod]
        public void CloneReturnsADifferentObject()
        {
            var grid = new Grid();
            var clonedGrid = grid.Clone();

            Assert.AreNotEqual(grid, clonedGrid);
        }

        [TestMethod]
        public void GetEmptyTilesReturnsCorrectTilesWhenInitialized()
        {
            var grid = new Grid();
            var emptyTiles = grid.GetEmptyTiles();

            Assert.AreEqual(9, emptyTiles.Count);
        }

        [TestMethod]
        public void SizeReturnsCorrectValue()
        {
            var grid = new Grid(null, 22);

            Assert.AreEqual(22, grid.Size);
             
        }

        [TestMethod]
        public void CloneReturnsADifferentObjectWithTheSameTiles()
        {
            var grid = new Grid();

            grid.SetValueAtPosition(1, 1, TileTypes.X);
            grid.SetValueAtPosition(2, 2, TileTypes.O);

            var clonedGrid = grid.Clone();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(clonedGrid.GetTileAtPosition(i, j), 
                        grid.GetTileAtPosition(i, j));
                }
            }
        }
    }
}
