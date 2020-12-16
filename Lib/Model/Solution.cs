using System.Collections.Generic;
using System.Linq;

namespace TurtleMine
{
    public class Solution
    {
        public Turtle InitialTurtle { get; private set; }
        public List<Move> Moves { get; private set; }
        public Solution(Turtle initialTurtle, List<Move> moves) => (InitialTurtle, Moves) = (initialTurtle, moves);
    }

    public static class SolutionEx
    {
        public static Solution FromStringArray(string[] arr)
        {
            var turtle = TurtleEx.FromString(arr[0]);

            var moves = string.Join(" ", arr.Skip(1))
                              .Split(" ")
                              .Select(x => MoveEx.FromString(x))
                              .ToList();

            return new Solution(turtle, moves);
        }
    }
}