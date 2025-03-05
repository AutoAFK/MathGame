using System;
namespace MathGame
{
	enum Difficulty
	{
		Easy = 0,
		Medium = 1,
		Hard = 2
	}
	class Game
	{
		private int wrongAnswers;

		public int WrongAnswers
		{
			get { return wrongAnswers; }
			set { wrongAnswers = value; }
		}

		private int correctAnswers;

		public int CorrectAnswers
		{
			get { return correctAnswers; }
			set { correctAnswers = value; }
		}

		private Difficulty difficulty;

		public Difficulty GameDifficulty
		{
			get { return difficulty; }
			set
			{
				difficulty = value;
				SetDifficultyValues();
			}
		}

		private int minValue;
		private int maxValue;

		public Game(Difficulty difficulty)
		{
			GameDifficulty = difficulty;
			SetDifficultyValues();
			CorrectAnswers = 0;
			WrongAnswers = 0;
		}

		public void CreateQuestion()
		{
			var random = new Random();
			int first_number = random.Next(minValue, maxValue);
			int second_number = random.Next(minValue, maxValue);
			int result = 0;
			char op = ' ';
			// Set operation for the math equation.
			switch (random.Next(4))
			{
				case 0:
					op = '+';
					result = first_number + second_number;
					break;
				case 1:
					op = '-';
					result = first_number - second_number;
					break;
				case 2:
					op = '*';
					result = first_number * second_number;
					break;
				case 3:
					op = '/';
					// To provide only equations with whole number as result.
					while (first_number % second_number != 0)
					{
						first_number = random.Next(minValue, maxValue);
						second_number = random.Next(minValue, maxValue);
					}
					result = first_number / second_number;

					break;
			}
			// Ask user to answer the equation.
			bool success;
			int userAnswer;
			do
			{
				Console.Write($"{first_number} {op} {second_number} = ");
				success = int.TryParse(Console.ReadLine(), out userAnswer);
				if (!success)
				{
					Console.WriteLine("Please enter only numbers.");
				}
			} while (!success);
			if (userAnswer != result)
			{
				WrongAnswers++;
				Console.WriteLine("Wrong answer.");
			}
			else
			{
				CorrectAnswers++;
				Console.WriteLine("Correct!");

			}
		}

		public void ShowResults()
		{
			Console.WriteLine($"Correct answers: {CorrectAnswers}");
			Console.WriteLine($"Wrong answers: {WrongAnswers}");
			Console.ReadKey();

		}

		private void SetDifficultyValues()
		{
			switch (GameDifficulty)
			{
				case Difficulty.Easy:
					minValue = 0;
					maxValue = 10 + 1;
					break;
				case Difficulty.Medium:
					minValue = 10;
					maxValue = 50 + 1;
					break;
				case Difficulty.Hard:
					minValue = 50;
					maxValue = 100 + 1;
					break;
			}
		}

		public void SetProblemsDifficulty()
		{
			Console.Clear();
			Console.WriteLine($"Current Difficulty: {GameDifficulty}");
			Console.WriteLine("Choose one of the difficulties below:");
			var enumValues = Enum.GetValues(typeof(Difficulty));
			for (var i = 0; i < enumValues.Length; i++)
			{
				Console.WriteLine($"{i + 1}. {enumValues.GetValue(i)}");
			}

			do
			{
				var key = Console.ReadKey();
				switch (key.KeyChar)
				{
					case (char)ConsoleKey.D1:
						GameDifficulty = Difficulty.Easy;
						break;
					case (char)ConsoleKey.D2:
						GameDifficulty = Difficulty.Medium;
						break;
					case (char)ConsoleKey.D3:
						GameDifficulty = Difficulty.Hard;
						break;
					default:
						Console.WriteLine("Choose from the options above.");
						continue;
				}
				return;
			} while (true);
		}
	}
}
