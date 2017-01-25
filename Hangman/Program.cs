using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //DisplayIntro();

            Hangman gameHangman = new Hangman();

            DisplayAvailableLettersBox(gameHangman);


            Console.ReadLine();


            while (false)             // Game Loop
            {

            }

        }


        static char TakePlayerInput() // Checks player input, returns that char if valid letter (aA-zZ) only
        {
            char playerInput;
            bool isInputValid = false;

            while (!isInputValid)
            {
                isInputValid = char.TryParse(Console.ReadLine(), out playerInput);
                if (((Convert.ToInt32(playerInput) >= 65) && (Convert.ToInt32(playerInput) <= 90)) || ((Convert.ToInt32(playerInput) >= 97) && (Convert.ToInt32(playerInput) <= 122)))
                {
                    return playerInput;
                }
                else
                {
                    isInputValid = false;
                }
            }
            return '0';
        }

        static void DisplayIntro()
        {
            Console.WriteLine(" Welcome to Hangman, This will be an Intro Screen Eventually");
            Console.WriteLine(" Press enter to continue");
            Console.ReadLine();
        }

        static void DisplayMenu()
        {
            Console.WriteLine(" [1] Generate a random face.");
            Console.WriteLine(" [2] Change your face's Hair.");
            Console.WriteLine(" [3] Change your face's Eyes.");
            Console.WriteLine(" [4] Change your face's Nose.");
            Console.WriteLine(" [5] Change your face's Mouth.");
            Console.WriteLine(" [6] Change your face's Chin.");
            Console.WriteLine(" [7] Start over with a blank face.");
        }

        static void DisplayAvailableLettersBox(Hangman gameHangman)
        {
            Console.WriteLine("   _____________________________________________________");
            Console.WriteLine(" /|                                                     |\\");
            Console.WriteLine($" || {gameHangman.AvailableLettersToGuess} ||");
            Console.WriteLine(" \\|_____________________________________________________|/");
        }
    }
}