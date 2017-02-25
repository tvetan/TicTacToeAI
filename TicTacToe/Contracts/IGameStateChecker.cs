namespace TicTacToe.Contracts
{
    public interface IGameStateChecker
    {
        bool IsEnd(Grid grid);

        GameState GetGameState(Grid grid);
    }
}
