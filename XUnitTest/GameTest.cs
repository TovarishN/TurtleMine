using System.Collections.Generic;
using System.Linq;
using TurtleMine;
using Xunit;

namespace XUnitTest
{
    public class GameTest
    {
        Scene scene;
        public GameTest()
        {
            var board = new Board(new Position(5, 4));
            var mines = new HashSet<Position>(
                new[] { (1, 1), (1, 3), (3, 1) }
                .Select(x => new Position(x.Item1, x.Item2)));

            var exit = new Position(4, 2);

            scene = new Scene(board, mines, exit);
        }
        [Fact]
        public void MineHitGame()
        {
            var moves = new[] { MoveType.RightTurn
                                , MoveType.Move
                                , MoveType.LeftTurn
                                , MoveType.Move
                                , MoveType.Move }
                .Select(x => new Move(x))
                .ToList();

            var init = new Turtle(new Position(0,1), Orientation.North);

            var solution = new Solution(init, moves);

            Assert.True(Game.Play(scene, solution, OutOfTheBoardStrategy.IgnoreNoMove) == Result.MineHit);
        }

        [Fact]
        public void ExitSuccessGame()
        {
            var moves = new[] { MoveType.Move
                                , MoveType.RightTurn
                                , MoveType.Move
                                , MoveType.Move
                                , MoveType.RightTurn
                                , MoveType.Move
                                , MoveType.RightTurn // rotate 360 right on place
                                , MoveType.RightTurn
                                , MoveType.RightTurn
                                , MoveType.RightTurn
                                , MoveType.Move 
                                , MoveType.LeftTurn
                                , MoveType.Move
                                , MoveType.LeftTurn // rotate 360 left on place
                                , MoveType.LeftTurn
                                , MoveType.LeftTurn
                                , MoveType.LeftTurn
                                , MoveType.Move}
                .Select(x => new Move(x))
                .ToList();

            var init = new Turtle(new Position(0, 1), Orientation.North);

            var solution = new Solution(init, moves);

            Assert.True(Game.Play(scene, solution, OutOfTheBoardStrategy.IgnoreNoMove) == Result.ExitSuccess);
        }

        [Fact]
        public void ShouldThrowOnOutOfTheBoardWhenUsingThrowStrategy()
        {
            var moves = new[] { MoveType.Move
                               , MoveType.Move
                                , MoveType.LeftTurn
                                , MoveType.Move
                                , MoveType.Move}
                .Select(x => new Move(x))
                .ToList();

            var init = new Turtle(new Position(0, 1), Orientation.North);

            var solution = new Solution(init, moves);

            Assert.Throws<OutOfBoardException>(() => Game.Play(scene, solution, OutOfTheBoardStrategy.Throw));
        }

        [Fact]
        public void ExitSuccessWithIgnoreAndMoveStrategyGame()
        {
            var moves = new[] { MoveType.Move
                                , MoveType.Move // move out of the board
                                , MoveType.RightTurn
                                , MoveType.Move
                                , MoveType.Move
                                , MoveType.RightTurn
                                , MoveType.Move // back to the board
                                , MoveType.Move
                                , MoveType.Move
                                , MoveType.LeftTurn
                                , MoveType.Move
                                , MoveType.Move}
                .Select(x => new Move(x))
                .ToList();

            var init = new Turtle(new Position(0, 1), Orientation.North);

            var solution = new Solution(init, moves);

            Assert.True(Game.Play(scene, solution, OutOfTheBoardStrategy.IgnoreAndMove) == Result.ExitSuccess);
        }

        [Fact]
        public void ExitSuccessWithIgnoreNoMoveStrategyGame()
        {
            var moves = new[] { MoveType.Move
                                , MoveType.Move // try move out of the board
                                , MoveType.RightTurn
                                , MoveType.Move
                                , MoveType.Move
                                , MoveType.RightTurn
                                , MoveType.Move
                                , MoveType.RightTurn
                                , MoveType.RightTurn
                                , MoveType.RightTurn
                                , MoveType.RightTurn
                                , MoveType.Move
                                , MoveType.LeftTurn
                                , MoveType.Move
                                , MoveType.LeftTurn
                                , MoveType.LeftTurn
                                , MoveType.LeftTurn
                                , MoveType.LeftTurn
                                , MoveType.Move}
                .Select(x => new Move(x))
                .ToList();

            var init = new Turtle(new Position(0, 1), Orientation.North);

            var solution = new Solution(init, moves);

            Assert.True(Game.Play(scene, solution, OutOfTheBoardStrategy.IgnoreNoMove) == Result.ExitSuccess);
        }

    }
}
