namespace TicTacToe
{
    public class Tile
    {
        public Tile(int x, int y, TileTypes tileType)
        {
            this.Position = new Position { X = x, Y = y };
            this.TileType = tileType;
        }

        public Position Position { get; set; }

        public TileTypes TileType { get; set; }

        public override bool Equals(object obj)
        {
            var otherTile = (Tile)obj;
            return otherTile.TileType == this.TileType;
        }

        public static bool operator !=(Tile p1, Tile p2)
        {
            return !p1.Equals(p2);
        }

        public static bool operator ==(Tile p1, Tile p2)
        {
            return p1.Equals(p2);
        }

        public override int GetHashCode()
        {
            return this.Position.X ^ this.Position.Y;
        }
    }
}
