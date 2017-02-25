namespace TicTacToe.Contracts
{
    public interface ITicTacToeSolver
    {
        Position GetNextPosition(Grid grid, TileTypes currentPlayerTile);
    }
}
