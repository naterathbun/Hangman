using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Hangman
    {
        public string AvailableLettersToGuess { get; set; } = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z"; //length 51
        public string SecretWordFull { get; set; } = string.Empty; // player input word
        public string SecretWordHidden { get; set; } = string.Empty; // set equal to SecretWordFull in length, but with _



        public bool UpDateRemainingLetters(char playerLetterGuess) // takes input char, returns T if it can use it, F if already done
        {
            if (AvailableLettersToGuess.Contains(playerLetterGuess))
            {
                AvailableLettersToGuess = AvailableLettersToGuess.Replace(playerLetterGuess, '_');
                // need to add method call to reveal letter if it's in secret word
                return true;
            }
            return false;
        }

        // Method: Set secret word
        // Method: Check if given char is in secret word and reveal if so (two arrays, one starts _ _, one has word, slowly update _ _ as letters added)
        // Method: Update/draw hangman on failed letter
        // Method: Declare victory -- check exposed word for any _'s, if none found game over
        // Method: Declare loss -- check hangman for remaining guesses, if < 0 game over
    }
}
