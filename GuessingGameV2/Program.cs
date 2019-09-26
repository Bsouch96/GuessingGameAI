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
            Random randNum = new Random();
            int difficulty = GetDifficulty();
            int guessesMade = 0;
            int totalGuesses = 0;
            int answer = 0;
            int userGuess = -5000;


            switch (difficulty)
            {
                case 1:
                    totalGuesses = 20;
                    answer = randNum.Next(0, 100);
                    break;
                case 2:
                    totalGuesses = 15;
                    answer = randNum.Next(0, 500);
                    break;
                case 3:
                    totalGuesses = 7;
                    answer = randNum.Next(-1000, 1000);
                    break;
            }

            while(guessesMade != totalGuesses)
            {
                Console.WriteLine("Please make a new guess");
                userGuess = Convert.ToInt32(Console.ReadLine());

                if(userGuess > answer)
                {
                    Console.WriteLine("Your guess is too high!");
                    guessesMade++;
                }
                else if(userGuess < answer)
                {
                    Console.WriteLine("Your guess is too low!");
                    guessesMade++;
                }
                else
                {
                    Console.WriteLine("Congratulations! You Win! the answer was in fact: " + answer);
                    break;
                }
            }
        }

        public static int GetDifficulty()
        {
            int difficulty = 0;

            Console.WriteLine("Please choose a difficulty:\n1. Easy\n2. Medium\n3. Hard");
            int choice = Convert.ToInt32(Console.ReadLine());
            int validChoice = ValidateChoice(choice);

            switch (validChoice)
            {
                case 1:
                    difficulty = 1;
                    break;
                case 2:
                    difficulty = 2;
                    break;
                case 3:
                    difficulty = 3;
                    break;
                default:
                    Console.WriteLine("Please enter a valid diffiulty choice.");
                    break;
            }

            return difficulty;
        }

        public static void ComputerGuessesMode()
        {
            Random randNum = new Random();
            int difficulty = GetDifficulty();
            int guessesMade = 0;
            int totalGuesses = 0;
            int answer = 0;
            int userGuess = -5000;

            switch (difficulty)
            {
                case 1:
                    totalGuesses = 20;
                    answer = randNum.Next(0, 100);
                    break;
                case 2:
                    totalGuesses = 15;
                    answer = randNum.Next(0, 500);
                    break;
                case 3:
                    totalGuesses = 7;
                    answer = randNum.Next(-1000, 1000);
                    break;
            }


        }

        public static int ValidateChoice(int choice)
        {
            while (choice < 1 || choice > 3)
            {
                Console.WriteLine("Please choose a valid difficulty:\n1.Easy\n2.Medium\n3.Hard");
                choice = Convert.ToInt32(Console.ReadLine());
            }

            return choice;
        }
    }
}
