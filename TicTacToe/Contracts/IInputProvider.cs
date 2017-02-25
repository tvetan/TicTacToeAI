namespace TicTacToe.Contracts
{
    public interface IInputProvider
    {
        Position GetNextPosition(TileTypes playerTileType, Grid grid);
    }
}
