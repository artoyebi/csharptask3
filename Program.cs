using System;

namespace Guessing
{
    class Program
    {
        static void Main(string[] args)
        {

            int secretNum, triesAllowed;
            int guessCount = 0;

            // Generate num
            int getSecretNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }

            // Use selected level to generate secret number and also set number of trials.
            int selectLevel(string num)
            {
                if (num == "1")
                {
                    triesAllowed = 6;
                    secretNum = getSecretNumber(1, 11);
                }
                else if (num == "2")
                {
                    triesAllowed = 4;
                    secretNum = getSecretNumber(1, 21);
                }
                else
                {
                    triesAllowed = 3;
                    secretNum = getSecretNumber(1, 51);
                }
                return secretNum;
            }


            // Game play
            void playGame(string level) {
                int guess;
                selectLevel(level);
                Console.WriteLine($"You Selected Level {level}");
                Console.WriteLine($"You have {triesAllowed} tries.");

                // Check guess entry
                while (guessCount < triesAllowed)
                {
                    Console.WriteLine("Enter Your Guess.");
                    guess = Convert.ToInt32(Console.ReadLine());
                    if (guess == secretNum)
                    {
                        Console.WriteLine("That Was Right!");
                        break;
                    }
                    else {
                        guessCount++;
                        Console.WriteLine("Nope, that was WRONG!!!");
                        
                        if (guessCount - triesAllowed != 0)
                        {
                            Console.WriteLine($"You Have {triesAllowed - guessCount} Left");
                        }
                        else
                        {
                            Console.WriteLine("You Have Exhausted Your Tries.");
                            Console.WriteLine("GAME OVER!");
                            Console.WriteLine($"The Right Number Was {secretNum}");
                        }
                    }

                }

            }


            Console.WriteLine("NUMBER GUESSING GAME");
            Console.WriteLine("Please Select Difficulty Level Between From 1-3");
            // User select level
            var levelPicked = Console.ReadLine();
            if (levelPicked != null)
            {
                // Start game
                playGame(levelPicked);
            }
        }
    }
}
