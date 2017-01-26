using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Hangman
    {
        Guesses guess = new Guesses(8);

        public string AvailableLettersToGuess { get; set; } = string.Empty;
        List<char> SecretWordFull { get; set; } = new List<char>();
        List<char> SecretWordHidden { get; set; } = new List<char>();


        public void StartGame()
        {
            //DisplayIntro();
            SetAvailableLettersToGuessToDefault();
            SetSecretWord();

            while (true)
            {
                char guessLetter;

                if (AllChancesAreUsed() || PlayerHasWon())
                {
                    break;
                }

                DisplayHangmanVisual();

                guessLetter = GetPlayerGuess();

                if (IsLetterGuessInSecretWord(guessLetter))
                {
                    RevealCorrectLetter(guessLetter);
                }
                else if (AvailableLettersToGuess.Contains(guessLetter))
                {
                    guess.DecreaseChancesLeft();
                }

                UpdateRemainingLetters(guessLetter);
            }
        }

        public void DisplayIntro()
        {
            Console.WriteLine(" Welcome to Hangman, This will be an Intro Screen Eventually");
            Console.WriteLine(" Press enter to continue");
            Console.ReadLine();
        }

        public void SetAvailableLettersToGuessToDefault()
        {
            AvailableLettersToGuess = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z"; //length 51
        }

        public void SetSecretWord()
        {
            Console.WriteLine("Enter secret word (letters only): ");
            string secretWordString = Console.ReadLine();

            for (int i = 0; i < secretWordString.Length; i++)
            {
                this.SecretWordFull.Add(Convert.ToChar(secretWordString[i].ToString().ToUpper()));
                this.SecretWordHidden.Add('_');
            }
        }

        public char GetPlayerGuess()
        {
            Console.WriteLine("Enter next letter to guess: ");
            return guess.TakePlayerLetterInput();
        }

        public bool IsLetterGuessInSecretWord(char playerLetterGuess)
        {
            if (SecretWordFull.Contains(playerLetterGuess))
            {
                return true;
            }
            return false;
        }

        public void UpdateRemainingLetters(char playerLetterGuess)
        {
            AvailableLettersToGuess = AvailableLettersToGuess.Replace(playerLetterGuess, '_');
        }

        public void RevealCorrectLetter(char playerLetterGuess)
        {
            for (int i = 0; i < SecretWordFull.Count; i++)
            {
                if (playerLetterGuess == SecretWordFull[i])
                {
                    SecretWordHidden[i] = SecretWordFull[i];
                }
            }
        }

        public string PrintHiddenWord()
        {
            string hiddenWordString = string.Empty;

            for (int i = 0; i < SecretWordHidden.Count; i++)
            {
                hiddenWordString += SecretWordHidden[i];
                hiddenWordString += " ";
            }
            return hiddenWordString;

        }

        public bool AllChancesAreUsed()
        {
            if (guess.ChancesLeft == 0)
            {
                return true;
            }
            return false;
        }

        public bool PlayerHasWon()
        {
            if (!SecretWordHidden.Contains('_'))
            {
                return true;
            }
            return false;
        }

        public void DisplayHangmanVisual()
        {
            Console.Clear();

            Console.WriteLine("\n          /=======\\                  ");
            Console.WriteLine("          ||      |                  ");
            Console.WriteLine("          ||     \\O/                   ");
            Console.WriteLine("          ||      |                   ");
            Console.WriteLine("          ||     / \\                ");
            Console.WriteLine("          ||                         ");
            Console.WriteLine("   _______||__________               ");
            Console.WriteLine("  |                   |              ");
            Console.WriteLine($"  |   Misses Left: {guess.ChancesLeft}  |   {PrintHiddenWord()}");
            Console.WriteLine("  |___________________|              ");
            Console.WriteLine("\n   _____________________________________________________");
            Console.WriteLine(" /|                                                     |\\");
            Console.WriteLine($" || {this.AvailableLettersToGuess} ||");
            Console.WriteLine(" \\|_____________________________________________________|/\n");
        }
    }
}
