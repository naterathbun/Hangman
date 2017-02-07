using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Guesses
    {
        public int ChancesLeft { get; private set; }
        
        public Guesses(int guesses)
        {
            this.ChancesLeft = guesses;
        } // constructor

        public void DecreaseChancesLeft()
        {
            this.ChancesLeft -= 1;
        }

        public char TakePlayerInputReturnValidCharacter() 
        {
            char playerLetterInput;
            bool isInputValid = false;

            while (!isInputValid)
            {
                isInputValid = char.TryParse(Console.ReadLine().ToUpper(), out playerLetterInput);
                if (char.IsLetter(playerLetterInput))
                {
                    isInputValid = true;
                    return playerLetterInput;
                }
                else
                {
                    isInputValid = false;
                }
            }
            return '0';
        }

    }
}
