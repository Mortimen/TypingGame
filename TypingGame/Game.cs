using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TypingGame
{
    class Game
    {
        private List<string> allWords = new List<string>();
        private List<string> wordsOnScreen = new List<string>();
        private MainWindow Form;
        private int numberOfWordsOnScreen = 0;

        public List<TextBlock> textBlocks = new List<TextBlock>();
        public Game()
        {
            FillArrayOfWords();
        }

        public void Run()
        {
            Form = (MainWindow)Application.Current.Windows[0];
            TextBlock txt = new TextBlock();
            txt.Text = RandomWord();
            textBlocks.Add(txt);
            Form.Canvas.Children.Add(txt);
        }

        public void FillArrayOfWords()
        {
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\barte\source\repos\TypingGame\words.txt")) 
            {
                allWords.Add(line);
            }
        }
        public string RandomWord()
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 3000);
            wordsOnScreen.Add(allWords[number]);
            numberOfWordsOnScreen++;
            return wordsOnScreen[numberOfWordsOnScreen - 1];
        }

        public int NumberOfWords()
        {
            return wordsOnScreen.Count;
        }

        public string GetWord(int index)
        {
            return wordsOnScreen[index];
        }
    }
}
