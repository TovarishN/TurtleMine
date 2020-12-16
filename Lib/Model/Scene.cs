using System;
using System.Collections.Generic;
using System.Linq;

namespace TurtleMine
{
    public class Scene
    {
        public Board Board { get; }
        public HashSet<Position> MinePositions { get; }
        public Position ExitPosition { get; }
        public Scene(Board board, HashSet<Position> minePositions, Position exitPosition) 
                => (Board, MinePositions, ExitPosition) = (board, minePositions, exitPosition);

        public Result CheckSolution(Solution solution, IOutOfBoardStrategy outOfBoardStrategy)
        {
            var (result, turtle) = CheckTurtle(solution.InitialTurtle, solution.InitialTurtle, outOfBoardStrategy);
            switch (result)
            {
                case Result.MineHit: return Result.MineHit;
                case Result.ExitSuccess: return Result.ExitSuccess;
            }
            
            foreach(var move in solution.Moves)
            {
                (result, turtle) = CheckTurtle(turtle, move.MakeMove(turtle), outOfBoardStrategy);
                
                switch (result)
                {
                    case Result.MineHit: return Result.MineHit;
                    case Result.ExitSuccess: return Result.ExitSuccess;
                }
            }

            return Result.StillInDanger;
        }

        private (Result, Turtle) CheckTurtle(Turtle oldTurtle, Turtle newTurtle, IOutOfBoardStrategy outOfBoardStrategy)
        {
            if (!TurtleIsOnTheBoard(newTurtle))
                newTurtle = outOfBoardStrategy.Execute(oldTurtle, newTurtle);

            if (MinePositions.Contains(newTurtle.Position))
                return (Result.MineHit, newTurtle);

            if (ExitPosition == newTurtle.Position)
                return (Result.ExitSuccess, newTurtle);

            return (Result.StillInDanger, newTurtle);
        }

        private bool TurtleIsOnTheBoard(Turtle turtle)
        {
            return Board.MaximumPosition.X >= turtle.Position.X
                    && Board.MaximumPosition.Y >= turtle.Position.Y
                    && turtle.Position.X >= 0
                    && turtle.Position.Y >= 0;
        }
    }

    public static class SceneEx
    {
        public static Scene FromStringArray(string[] arr)
        {
            var board = BoardEx.FromString(arr[0]);
            var minePositions = new HashSet<Position>(arr[1]
                                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(x => PositionEx.FromString(x, ",")));
           
            var exitPosition = PositionEx.FromString(arr[2], " ");

            return new Scene(board, minePositions, exitPosition);
        }
    }

}