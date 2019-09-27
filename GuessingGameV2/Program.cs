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
                    Console.WriteLine("Congratulations! You Win! The answer was in fact: " + answer);
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
            int compGuess = -5000;
            int min = 0;
            int max = 0;

            switch (difficulty)
            {
                case 1:
                    totalGuesses = 20;
                    answer = randNum.Next(0, 100);
                    min = 0;
                    max = 100;
                    break;
                case 2:
                    totalGuesses = 15;
                    answer = randNum.Next(0, 500);
                    min = 0;
                    max = 500;
                    break;
                case 3:
                    totalGuesses = 7;
                    answer = randNum.Next(-1000, 1000);
                    min = -1000;
                    max = 1000;
                    break;
            }

            try
            {
                while (guessesMade != totalGuesses)
                {
                    compGuess = randNum.Next(min, max);
                    Console.WriteLine("Is it " + compGuess + "?");
                    int userResponse = AnswerResponse();

                    if (userResponse == 1)
                    {
                        //Too high
                        max = compGuess;
                        guessesMade++;
                        Console.WriteLine("Too high? Hmmm...");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else if (userResponse == 2)
                    {
                        //Too low
                        min = compGuess;
                        guessesMade++;
                        Console.WriteLine("Too low? Hmmm...");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        //Correct answer
                        Console.WriteLine("Wooh! You're bad at this man!");
                        break;
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Haha! You're either changing your number or I win ;)");
            }
        }

        public static int ValidateChoice(int choice)
        {
            while (choice < 1 || choice > 3)
            {
                Console.WriteLine("Please choose an appropriate value of 1, 2 or 3");
                choice = Convert.ToInt32(Console.ReadLine());
            }

            return choice;
        }

        public static int AnswerResponse()
        {
            Console.WriteLine("Select the most appropriate response:\n1. Too high!\n2. Too Low!\n 3. Thats the answer!");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            int validChoice = ValidateChoice(userChoice);

            return validChoice;
        }
    }
}
