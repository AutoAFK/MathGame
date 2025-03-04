using System.Threading.Channels;

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Math Game");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. List Results");
            Console.WriteLine("0. Exit");
            bool isRunning = true;
            while (isRunning)
            {
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
                        Console.WriteLine("You chose 1");
                        break;
                    case 2:
                        Console.WriteLine("2");
                        break;
                    case 0:
                        Console.WriteLine("Goodbye!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose one of the numbers of the list.");
                        break;
                }
            }
        }
    }
}
