using System;

namespace MathGame
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var game = new Game(Difficulty.Easy);
			HandleUserChoise(ref game);
		}

		private static void DisplayMenu()
		{
			Console.WriteLine("Math Game");
			Console.WriteLine("---------");
			Console.WriteLine();
			Console.WriteLine("1. Start Game");
			Console.WriteLine("2. List Results");
			Console.WriteLine("3. Set game difficulty");
			Console.WriteLine("0. Exit");

		}

		private static void HandleUserChoise(ref Game game)
		{
			while (true)
			{
				Console.Clear();
				DisplayMenu();

				Console.WriteLine();
				int userOption = GetUserInputOption(3);
				switch (userOption)
				{
					case 1:
						int rounds = GetInt("Question amount");
						for (var i = 0; i < rounds; i++)
						{
							game.CreateQuestion();
						}
						break;
					case 2:
						game.ShowResults();
						break;
					case 3:
						game.SetProblemsDifficulty();
						break;
					case 0:
						Console.WriteLine("Thank you for playing!");
						return;
				}
			}
		}

		private static int GetUserInputOption(int maxOption, int minOption = 0)
		{
			do
			{
				var userInput = GetInt("Enter option");
				if (userInput < minOption || userInput > maxOption)
				{
					Console.WriteLine("Please choose an option from the list above.");
				}
				else
				{
					return userInput;
				}
			} while (true);
			
		}

		private static int GetInt(string msg)
		{
			do
			{
				Console.Write($"{msg}: ");
				var success = int.TryParse(Console.ReadLine(), out int userInput);
				if (!success)
				{
					Console.WriteLine("Please enter only numbers.");
				}
				else
				{
					return userInput;
				}
			} while (true);
		}
	}
}
