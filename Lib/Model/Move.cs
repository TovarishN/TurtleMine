using System;
using System.Diagnostics.CodeAnalysis;

namespace TurtleMine
{
    public enum MoveType
    {
        LeftTurn,
        RightTurn,
        Move
    }
    public readonly struct Move
    {
        public MoveType MoveType { get; }
        public Move(MoveType moveType) => MoveType = moveType;
        public Turtle MakeMove(Turtle oldTurtle)
        {
            return MoveType switch
            {
                MoveType.LeftTurn   => new Turtle(oldTurtle.Position, oldTurtle.Orientation.Rotate(RotationType.Left)),
                MoveType.RightTurn  => new Turtle(oldTurtle.Position, oldTurtle.Orientation.Rotate(RotationType.Right)),
                
                MoveType.Move       => new Turtle(oldTurtle.Position.Move(oldTurtle.Orientation), oldTurtle.Orientation),
            };
        }
    }

    public static class MoveEx
    {
        public static Move FromString(string str)
        {
            var moveType = str switch
            {
                "M" => MoveType.Move,
                "L" => MoveType.LeftTurn,
                "R" => MoveType.RightTurn,
                _ => throw new NotImplementedException(),
            };

            return new Move(moveType);
        }

    }

}