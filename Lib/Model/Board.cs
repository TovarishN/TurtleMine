namespace TurtleMine
{
    public readonly struct Board
    {
        public Position MaximumPosition { get; }
        public Board(Position maxPosition) 
        {
            if (maxPosition.X < 0 || maxPosition.Y < 0)
                throw new IncorrectBoardException("Board maximum dimentions shold be greater or equal to zero");

            MaximumPosition = maxPosition; 
        }
    }

    public static class BoardEx
    {
        public static Board FromString(string str)
        {
            return new Board(PositionEx.FromString(str, " "));
        }
    }
}