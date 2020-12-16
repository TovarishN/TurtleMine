using TurtleMine;
using Microsoft.AspNetCore.Builder;
using System;

namespace TurtleMine
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var game = Game.LoadFromFile("turtleConfig.txt");
				var result = Game.Play(game.scene, game.solution, OutOfTheBoardStrategy.IgnoreAndMove);

				Console.WriteLine(result);
			}
			catch(Exception ex)
            {
				Console.Write(ex);
            }
		}
	}
}
