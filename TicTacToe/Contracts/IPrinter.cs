namespace TicTacToe.Contracts
{
    public interface IPrinter
    {
        void Print(Grid grid);

        void PrintEndGame(GameState gameState, TileTypes winnerTileType);
    }
}
