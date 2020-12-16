using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TurtleMine
{
    public class Game
    {
        public static Result Play(Scene scene, Solution solution, IOutOfBoardStrategy outOfBoardStrategy)
        {
            return scene.CheckSolution(solution, outOfBoardStrategy);
        }
        public static (Scene scene, Solution solution) LoadFromFile(string fileName)
        {
            try
            {
                var lines = File.ReadLines(fileName).ToList();

                // first line: board size
                // second line: mine positions
                // third line: exit position
                var scene = SceneEx.FromStringArray(new[] { lines[0], lines[1], lines[2] });

                // fourth line: turtle position and orientation
                // rest lines: moves
                var solution = SolutionEx.FromStringArray(lines.Skip(3).ToArray());

                return (scene, solution);
            }
            catch(Exception ex)
            {
                throw new IncorrectInputFileFormatException("Input file has incorrect format", ex);
            }
        }
    }
}