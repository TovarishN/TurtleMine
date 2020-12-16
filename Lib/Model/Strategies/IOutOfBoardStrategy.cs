namespace TurtleMine
{
    public interface IOutOfBoardStrategy
    {
        Turtle Execute(Turtle oldTurtle, Turtle newTurtle);
    }

    public class IgnoreOutOfTheBoardAndMove : IOutOfBoardStrategy
    {
        public Turtle Execute(Turtle oldTurtle, Turtle newTurtle)
        {
            return newTurtle;
        }
    }

    public class IgnoreOutOfTheBoardNoMove: IOutOfBoardStrategy
    {
        public Turtle Execute(Turtle oldTurtle, Turtle newTurtle)
        {
            return oldTurtle;
        }
    }

    public class ThrowOnOutOfTheBoard : IOutOfBoardStrategy
    {
        public Turtle Execute(Turtle oldTurtle, Turtle newTurtle)
        {
            throw new OutOfBoardException();
        }
    }

    /// <summary>
    /// Some default out of the board strategies
    /// </summary>
    public static class OutOfTheBoardStrategy 
    {
        public static readonly IOutOfBoardStrategy IgnoreAndMove = new IgnoreOutOfTheBoardAndMove();
        public static readonly IOutOfBoardStrategy IgnoreNoMove = new IgnoreOutOfTheBoardNoMove();
        public static readonly IOutOfBoardStrategy Throw = new ThrowOnOutOfTheBoard();
    }
}