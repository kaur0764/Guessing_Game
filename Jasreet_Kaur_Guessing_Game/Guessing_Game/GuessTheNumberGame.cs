/*
 * Jasreet Kaur
 * Completed on April 14, 2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_Game
{
    class GuessTheNumberGame
    {
        private int guessCount = 0; //this field is used to keep track of the total number of guesses a player makes in a single game
        private string? input = string.Empty; //this field captures the player input

        private const int MAX_MENU = 3; //this constant represents the menus maximum valid value 
        private const int MIN_MENU = 0; //this constant represents the menus minimum valid value 

        // composition = "has a"
        private RangedRandomInteger secretNumberGenerator = new(); // It is used to generate (pseudo) random number to be guessed

        // private methods:

        private void Play(int secretNumber)
        {
            Console.Clear();

            int guessedNumber = 0; //Captures the guess made by the player
            guessCount = 0; //the guess counter is set back to zero before each game

            Console.Write($"\nPlease enter a number between {secretNumberGenerator.GetMinimum()} and {secretNumberGenerator.GetMaximum()}\n");

            while (true) // loop until correct guess is made
            {
                Console.WriteLine();

                //try catch structure to make sure that the input is in the correct format
                try
                {
                    Console.Write("Guess the number: ");

                    input = Console.ReadLine();//Capture the guess made by the player

                    guessedNumber = Convert.ToInt32(input);//Convert the string to integer

                    //With every guess the guess counter will be incremented
                    guessCount++;

                    Console.Clear();
                    Console.WriteLine();

                    if (guessedNumber == secretNumber)
                    {//Once the correct guess is made the method will return

                        Console.Write("Congratulations!\t\t\t\t\t\t");
                        //Total number of guesses are shown to the player
                        Console.WriteLine("Total number of guesses: " + guessCount);

                        return;
                    }
                    else if (guessedNumber < secretNumber)
                    {
                        Console.Write("Too low!\t\t\t\t\t\t");
                    }
                    else
                    {
                        Console.Write("Too High!\t\t\t\t\t\t");
                    }

                    //Total number of guesses are shown to the player
                    Console.WriteLine("Total Guesses: " + guessCount);
                }
                catch (Exception e)
                {
                    if (e is FormatException)
                    {
                        Console.Write("\nInvalid input: " + e.Message);
                    }
                    else if (e is OverflowException)
                    {
                        Console.Write("\nNumber too large: " + e.Message);
                    }
                    else
                    {
                        Console.Write("\nError: " + e.Message);
                    }
                }

            }

        }

        private int Setup(int rangeOption)
        {
            //Returns 0 if player chose 0 to exit
            //else generates a random integer using the range values on the menu based on the player's choice

            switch (rangeOption)
            {
                case 0:
                    return 0;
                case 1:
                    secretNumberGenerator.SetMaximum(20);
                    break;
                case 2:
                    secretNumberGenerator.SetMaximum(100);
                    break;
                case 3:
                    secretNumberGenerator.SetMaximum(1000);
                    break;
            }

            // Return the generated random number
            return secretNumberGenerator.GenerateRandomNumber();
        }

        private int ShowMenu()
        {
            //Change the console window colours
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            //Clear the screen
            Console.Clear();

            //Show the menu
            Console.WriteLine(" ____________________________________________________ ");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| The Guessing Game                                  |");
            Console.WriteLine("|____________________________________________________|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|  Please Choose:                                    |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|  1: Easy: Guess a number between 1 and 20          |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|  2: Normal: Guess a number between 1 and 100       |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|  3: Hard: Guess a number between 1 and 1000        |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|  0: Exit                                           |");
            Console.WriteLine("|____________________________________________________|");

            int chosenOptionNumber = 100; //this variable is used to capture the player's menu choice 
            bool validInput; //this variable is used to check if the input is valid

            Console.WriteLine();
            Console.Write($"Please enter a number between {MIN_MENU} and {MAX_MENU}");

            do
            {
                Console.WriteLine();

                //try catch structure to make sure that the input is in the correct format
                try
                {

                    input = Console.ReadLine(); //capture the player's menu choice 

                    chosenOptionNumber = Convert.ToInt32(input); //covert the string to an integer

                }
                catch (Exception e)
                {
                    if (e is FormatException)
                    {
                        Console.Write("\nInvalid input: " + e.Message);
                    }
                    else if (e is OverflowException)
                    {
                        Console.Write("\nNumber too large: " + e.Message);
                    }
                    else
                    {
                        Console.Write("\nError: " + e.Message);
                    }
                }

                validInput = (chosenOptionNumber >= MIN_MENU) && (chosenOptionNumber <= MAX_MENU); // verify the range (Integer value between 0 and 3)

                if (!validInput)
                {
                    Console.Write($"\nPlease enter a number between {MIN_MENU} and {MAX_MENU}");
                }

            } while (!validInput); // loop until valid input is given

            //Once a valid choice is made this method returns by calling the Setup method
            //And pass the player choice as an argument
            return Setup(chosenOptionNumber);

        }


        // public methods:

        // default constructor:
        public GuessTheNumberGame()
        {

        }

        public void Start()
        {
            //This loop will exit if the user enters either a lowercase or an uppercase “n”
            do
            {
                int secretNumber = ShowMenu();
                if (secretNumber == 0)
                {//if zero is returned exit the do while loop
                    break;
                }
                else
                {//else the generated random number returned is passed to the Play method
                    Play(secretNumber);
                }

                Console.WriteLine("\n\nPlay Again? (N/n= no)");

                input = Console.ReadLine() ?? "n";

            } while (!input.Equals("n", StringComparison.CurrentCultureIgnoreCase)); 

            Console.WriteLine("\nThanks for playing!");
        }

    }
}
