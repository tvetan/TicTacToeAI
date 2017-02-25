using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeTests
{
    [TestClass]
    public class TileTests
    {
        [TestMethod]
        public void IsEqualReturnsTrueWhenEqualValuesTiles()
        {
            var firstTile = new Tile(1, 1, TileTypes.X);
            var secondTile = new Tile(2, 2, TileTypes.X);

            Assert.AreEqual(firstTile, secondTile);
            Assert.IsTrue(firstTile == secondTile);
        }

        [TestMethod]
        public void IsEqualReturnsFalseWhenNotEqualValuesTiles()
        {
            var firstTile = new Tile(1, 1, TileTypes.X);
            var secondTile = new Tile(2, 2, TileTypes.O);

            Assert.AreNotEqual(firstTile, secondTile);
            Assert.IsTrue(firstTile != secondTile);
        }
    }
}
