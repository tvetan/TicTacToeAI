using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Grid
    {
        private int size;
        public int Size
        {
            get
            {
                return this.size;
            }
        }
        private List<Tile> tiles;

        public Grid()
        {
            this.tiles = new List<Tile>();
            this.size = 3;

            this.InitializeGridWithEmptyTiles();
        }

        public Grid(List<Tile> tiles, int size)
        {
            this.tiles = tiles;
            this.size = size;
        }

        public bool IsValidPosition(int x, int y)
        {
            if (x < 0 || x >= this.size || y < 0 || y >= this.size)
            {
                return false;
            }

            var tile = this.GetTileAtPosition(x, y);
            if (tile.TileType != TileTypes.Empty)
            {
                return false;
            }

            return true;
        }

        public Tile GetTileAtPosition(int x, int y)
        {
            return this.tiles.FirstOrDefault(t => t.Position.X == x && t.Position.Y == y);
        }

        public void SetValueAtPosition(int x, int y, TileTypes value)
        {
            var tile = this.GetTileAtPosition(x, y);
            tile.TileType = value;
        }

        public int GetEmptyTilesCount()
        {
            return this.tiles.Count(x => x.TileType == TileTypes.Empty);
        }

        public List<Tile> GetEmptyTiles()
        {
            return this.tiles.Where(x => x.TileType == TileTypes.Empty).ToList();
        }

        private void InitializeGridWithEmptyTiles()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.tiles.Add(new Tile(i, j, TileTypes.Empty));
                }
            }
        }

        public Grid Clone()
        {
            var clonedTiles = new List<Tile>();
            foreach (var tile in this.tiles)
            {
                clonedTiles.Add(new Tile(tile.Position.X, tile.Position.Y, tile.TileType));
            }

            var clonedGrid = new Grid(clonedTiles, this.size);
            return clonedGrid;
        }
    }
}
