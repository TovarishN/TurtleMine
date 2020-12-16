namespace TurtleMine
{
    public readonly struct Turtle
    {
        public Position Position { get; }
        public Orientation Orientation { get; }
        public Turtle(Position position, Orientation orientation) => (Position, Orientation) = (position, orientation);

        public Turtle MakeMove(MoveType moveType)
        {
            return moveType switch
            {
                MoveType.LeftTurn   => new Turtle(Position, Orientation.Rotate(RotationType.Left)),
                MoveType.RightTurn  => new Turtle(Position, Orientation.Rotate(RotationType.Right)),
                MoveType.Move       => new Turtle(Position.Move(Orientation), Orientation),
                _ => throw new System.NotImplementedException(),
            };
        }
    }

    public static class TurtleEx
    {
        public static Turtle FromString(string str)
        {
            var (turtleX, turtleY, orientationStr) = str.Split(' ');
            return new Turtle(new Position(turtleX, turtleY), OrientationEx.FromString(orientationStr));
        }
    }
}