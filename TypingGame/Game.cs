using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TypingGame
{
    class Game
    {
        private static Mutex mutex = new Mutex();
        private List<string> allWords = new List<string>();
        public Dictionary<TextBlock, string> wordsOnScreen;
        private MainWindow Form;
        private int numberOfWordsOnScreen = 0;
        private bool gameOver = false;
        private int score = 0;

        public List<TextBlock> textBlocks = new List<TextBlock>();
        public Game()
        {
            FillArrayOfWords();
            wordsOnScreen = new Dictionary<TextBlock, string>();
        }

        public async void Run()
        {
            Form = (MainWindow)Application.Current.Windows[0];

            while(gameOver == false)
            {
                mutex.WaitOne();
                KeyValuePair<TextBlock, string> kvp = RandomWord();
                wordsOnScreen.Add(kvp.Key, kvp.Value);
                Form.Canvas.Children.Add(kvp.Key);
                mutex.ReleaseMutex();
                await Task.Delay(1000);
            }
        }

        public async void ChangePositions()
        {
            Form = (MainWindow)Application.Current.Windows[0];

            while (gameOver == false)
            {
                mutex.WaitOne();
                foreach (TextBlock txt in wordsOnScreen.Keys)
                {
                    Thickness thickness = txt.Margin;
                    double oldX = thickness.Left;
                    double oldY = thickness.Top;
                    if (++oldY > 640)
                    {
                        gameOver = true;
                        return;
                    }
                    txt.Margin = new Thickness(oldX, ++oldY, 0, 0);
                }
                mutex.ReleaseMutex();
                await Task.Delay(100);
            }
        }

        public void FillArrayOfWords()
        {
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\barte\source\repos\TypingGame\words.txt")) 
            {
                allWords.Add(line);
            }
        }
        public KeyValuePair<TextBlock, string> RandomWord()
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 3000);
            TextBlock txt = new TextBlock();
            txt.Text = allWords[number];
            txt.FontSize = 18;
            int number2 = rnd.Next(0, 700);
            txt.Margin = new Thickness(number2, -20, 0, 0);
            KeyValuePair<TextBlock, string> kvp = new KeyValuePair<TextBlock, string>(txt, allWords[number]);
            numberOfWordsOnScreen++;;
            return kvp;
        }

        public int NumberOfWords()
        {
            return wordsOnScreen.Count;
        }

        public void ScoreUp()
        {
            score += 10;
        }
    }
}
