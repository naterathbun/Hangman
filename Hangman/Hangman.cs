﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Hangman
    {
        Guesses guess = new Guesses(5);

        public string AvailableLettersToGuess { get; set; } = string.Empty;
        List<char> SecretWordFull { get; set; } = new List<char>();
        List<char> SecretWordHidden { get; set; } = new List<char>();

        public void StartGame()
        {
            DisplayIntro();
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

                RevealLetterIfGuessIsInSecretWord(guessLetter);

                UpdateRemainingLetters(guessLetter);
            }

            DisplayGameOverMessages();
        }

        public void RevealLetterIfGuessIsInSecretWord(char guessLetter)
        {
            if (LetterGuessIsInSecretWord(guessLetter))
            {
                RevealCorrectLetter(guessLetter);
            }
            else if (AvailableLettersToGuess.Contains(guessLetter))
            {
                guess.DecreaseChancesLeft();
            }
        }

        public void DisplayIntro()
        {

            Console.WriteLine(" _   _    ___    _   _   ____   ___  ___   ___    _   _ ");
            Console.WriteLine("| | | |  / _ \\  | \\ | | | __ \\  |  \\/  |  / _ \\  | \\ | |");
            Console.WriteLine("| |_| | / /_\\ \\ |  \\| | | | \\/  | .  . | / /_\\ \\ |  \\| |");
            Console.WriteLine("|  _| | |  _  | | . ` | | | __  | |\\/| | |  _  | | . ` |");
            Console.WriteLine("| | | | | | | | | |\\  | | |_\\ \\ | |  | | | | | | | |\\  |");
            Console.WriteLine("\\_| |_/ \\_| |_/ \\_| \\_/ \\_____/ \\_|  |_/ \\_| |_/ \\_| \\_/");
            Console.WriteLine("                   BY  NATHAN RATHBUN                   ");
            Console.WriteLine("                   ENTER TO  CONTINUE                   ");
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

                if (secretWordString[i] == ' ')
                {
                    this.SecretWordHidden.Add(' ');
                }
                else
                {
                    this.SecretWordHidden.Add('_');
                }
            }
        }

        public char GetPlayerGuess()
        {
            Console.WriteLine("Enter next letter to guess: ");
            return guess.TakePlayerInputReturnValidCharacter();
        }

        public bool LetterGuessIsInSecretWord(char playerLetterGuess)
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

        public string DisplayHiddenWordOnScreen()
        {
            string hiddenWord = string.Empty;

            for (int i = 0; i < SecretWordHidden.Count; i++)
            {
                hiddenWord += SecretWordHidden[i];
                hiddenWord += " ";
            }
            return hiddenWord;

        }

        public bool AllChancesAreUsed()
        {
            if (guess.ChancesLeft < 0)
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

        public void DisplayGameOverMessages()
        {

            if (AllChancesAreUsed())
            {
                RevealSecretWordAfterLoss();
                DisplayHangmanVisual();
                DisplayYouLoseMessage();
            }
            else
            {
                DisplayHangmanVisual();
                DisplayYouWinMessage();
            }
        }

        public static void DisplayYouWinMessage()
        {
            Console.WriteLine("YOU WIN, WINNER");
            Console.ReadLine();
        }

        public static void DisplayYouLoseMessage()
        {
            Console.WriteLine("YOU LOSE, LOSER");
            Console.ReadLine();
        }

        public void RevealSecretWordAfterLoss()
        {
            SecretWordHidden = SecretWordFull;
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
            Console.WriteLine($"  |   Misses Left: {guess.ChancesLeft}  |   {DisplayHiddenWordOnScreen()}");
            Console.WriteLine("  |___________________|              ");
            Console.WriteLine("\n   _____________________________________________________");
            Console.WriteLine(" /|                                                     |\\");
            Console.WriteLine($" || {this.AvailableLettersToGuess} ||");
            Console.WriteLine(" \\|_____________________________________________________|/\n");
        }
    }
}
