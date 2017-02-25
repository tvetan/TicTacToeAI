namespace TicTacToe.Contracts
{
    public static class TileTypesExtensions
    {
        public static TileTypes GetNextTile(this TileTypes tileType)
        {
            if (tileType == TileTypes.X)
            {
                return TileTypes.O;
            }

            return TileTypes.X;
        }
    }
}
