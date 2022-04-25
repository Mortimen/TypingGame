using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TypingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();
            game.Run();
        }
        
        private void keyDownEventHandler(object senser, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                for (int i = 0; i < game.NumberOfWords(); i++)
                {
                    if (input.Text == game.GetWord(i))
                        text1.Text = " ";
                }
            }
        }
    }
}
