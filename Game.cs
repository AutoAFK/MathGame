using System.Runtime.InteropServices;

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
            set { difficulty = value; }
        }

        private int minValue;
        private int maxValue;

        public Game(Difficulty difficulty)
        {
            GameDifficulty = difficulty;
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
            CorrectAnswers = 0;
            WrongAnswers = 0;
        }   

        public void CreateQuestion()
        {
            var random = new Random();
            int first_number = random.Next(minValue,maxValue);
            int second_number = random.Next(minValue,maxValue);
            int result = 0;
            char op = ' ';
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
                    while(first_number % second_number != 0)
                    {
                        first_number = random.Next(minValue,maxValue);
                        second_number = random.Next(minValue,maxValue);
                    }
                    result = first_number / second_number;
                   
                    break;
            }
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
            if(userAnswer != result)
            {
                WrongAnswers++;
                Console.WriteLine("Wrong answer.");
            } 
            else
            {
                CorrectAnswers++;
                Console.WriteLine("Correct!");
                
            }

            Console.WriteLine($"Wrong answers: {WrongAnswers}");
            Console.WriteLine($"Correct answers: {CorrectAnswers}");
        }


    }
}
