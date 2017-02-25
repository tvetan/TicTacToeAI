namespace TicTacToe
{
    public class MinMaxModel
    {
        public MinMaxModel(Grid grid, int utility, Position position)
        {
            this.Grid = grid;
            this.Utility = utility;
            this.Position = position;
        }

        public Grid Grid { get; set; }

        public Position Position { get; set; }

        public int Utility { get; set; }
    }
}
