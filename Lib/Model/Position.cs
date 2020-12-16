using System;

namespace TurtleMine
{
    public readonly struct Position : IEquatable<Position>
    {
        public int X { get; }
        public int Y { get; }
        public Position(int x, int y) => (X, Y) = (x, y);
        public override int GetHashCode() => (X, Y).GetHashCode();
        public override bool Equals(object other) => other is Position l && Equals(l);
        public bool Equals(Position other) => X == other.X && Y == other.Y;
        public static bool operator ==(Position p1, Position p2) => p1.Equals(p2);
        public static bool operator !=(Position p1, Position p2) => !p1.Equals(p2);

        public Position Move(Orientation orientation)
        {
            return orientation switch
            {
                Orientation.North => new Position(X, Y - 1),
                Orientation.South => new Position(X, Y + 1), // Y axis is directed towards South
                Orientation.West => new Position(X - 1, Y), 
                Orientation.East => new Position(X + 1, Y),
                _ => throw new NotImplementedException(),
            };
        }
    }

    public static class PositionEx
    {
        public static Position FromString(string str, string delimiter)
        {
            var (maxX, maxY) = str.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            return new Position(maxX, maxY);
        }
    }
}


