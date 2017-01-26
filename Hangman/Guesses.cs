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

        public char TakePlayerLetterInput() // Checks player input, returns that char if valid letter (aA-zZ) only
        {
            char playerInput;
            bool isInputValid = false;

            while (!isInputValid)
            {
                isInputValid = char.TryParse(Console.ReadLine().ToUpper(), out playerInput);
                if (char.IsLetter(playerInput))
                {
                    isInputValid = true;
                    return playerInput;
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
