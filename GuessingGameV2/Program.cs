using System;

namespace GuessingGameV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my guessing game.");
            Console.WriteLine("Please choose a game mode:\n1. Player Guesses\n2. Computer Guesses\n999. Quit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    PlayerGuessesMode();
                    break;
                case 2:
                    ComputerGuessesMode();
                    break;
                case 999:
                    Console.WriteLine("Thankyou for playing");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu option.");
                    break;
            }
        }

        public static void PlayerGuessesMode()
        {

        }
    }
}
