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

namespace NoughtsAndCrosses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int turnCount = 0;
        int[,] noughts = new int[,]
        {
            {0,0,0 },
            {0,0,0 },
            {0,0,0 },
        };
        int[,] crosses = new int[,]
        {
            {0,0,0 },
            {0,0,0 },
            {0,0,0 },
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPressed(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (turnCount % 2 == 0)
            {
                button.Content = "⭕";
                button.FontSize = 40;
                playerTurn.Text = "Player 2s Turn!";
                int row = Grid.GetRow(button) - 2;
                int col = Grid.GetColumn(button) - 1;
                noughts[row, col] = 1;
                
            }
            else
            {
                button.Content = "❌";
                button.FontSize = 40;
                playerTurn.Text = "Player 1s Turn!";
                int row = Grid.GetRow(button) - 2;
                int col = Grid.GetColumn(button) - 1;
                crosses[row, col] = 1;
            }
            turnCount++;
            button.IsEnabled = false;

            if (turnCount>4)
            {
                if (turnCount % 2 != 0) CheckForWinner(noughts, turnCount);
                else CheckForWinner(crosses, turnCount);
            }
        }

        public void CheckForWinner(int[,] player, int turnCount)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                count = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += player[i, j];
                }
                if ((count == 3) && (turnCount%2 == 0))
                {
                    playerTurn.Text = "Player 2 Wins!";
                    break;
                }
                else if ((count == 3) && (turnCount % 2 != 0))
                {
                    playerTurn.Text = "Player 1 Wins!";
                    break;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                count = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += player[j, i];
                }
                if ((count == 3) && (turnCount % 2 == 0))
                {
                    playerTurn.Text = "Player 2 Wins!";
                    break;
                }
                else if ((count == 3) && (turnCount % 2 != 0))
                {
                    playerTurn.Text = "Player 1 Wins!";
                    break;
                }
            }

            count = player[0, 0] + player[1, 1] + player[2, 2];
            if ((count == 3) && (turnCount % 2 == 0))
            {
                playerTurn.Text = "Player 2 Wins!";
            }
            else if ((count == 3) && (turnCount % 2 != 0))
            {
                playerTurn.Text = "Player 1 Wins!";
            }

            count = player[2, 0] + player[1, 1] + player[0, 2];
            if ((count == 3) && (turnCount % 2 == 0))
            {
                playerTurn.Text = "Player 2 Wins!";
            }
            else if ((count == 3) && (turnCount % 2 != 0))
            {
                playerTurn.Text = "Player 1 Wins!";
            }
        }
    }
}
