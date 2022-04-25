using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingGame
{
    class Game
    {
        private String[] words = new string[] { "kot" };

        public void Run()
        {

        }

        public int NumberOfWords()
        {
            return words.Length;
        }

        public String GetWord(int index)
        {
            return words[index];
        }
    }
}
