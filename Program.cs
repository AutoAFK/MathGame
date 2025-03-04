namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(Difficulty.Easy);
            while (true)
            {
                Console.Clear();
                DisplayMenu();

                Console.WriteLine();
                Console.Write("Please choose a number:");
                bool success = int.TryParse(Console.ReadLine(), out int userOption);
                if (!success)
                {
                    Console.WriteLine("Please input only numbers.");
                    continue;
                }
                switch (userOption)
                {
                    case 1:
                        game.CreateQuestion();
                        break;
                    case 2:
                        // TODO: Implement show result.
                        break;
                    case 3:
                        // TODO: Implement change difficulty.
                        break;
                    case 0:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Please choose one of the numbers of the list.");
                        break;
                }
                Console.ReadKey();
            }
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
    }
}
