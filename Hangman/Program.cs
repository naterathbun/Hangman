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
            Hangman gameHangman = new Hangman();
            gameHangman.StartGame();
        }
    }
}