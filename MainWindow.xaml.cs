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
        int noughtIndex = 0;
        int crossIndex = 0;
        int[,] noughts = new int[10, 2];
        int[,] crosses = new int[10, 10];
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
                var row = Grid.GetRow(button);
                var col = Grid.GetColumn(button);
                noughts.SetValue(row, noughtIndex, 0);
                noughts.SetValue(col, noughtIndex, 1);
                noughtIndex++;
            }
            else
            {
                button.Content = "❌";
                button.FontSize = 40;
                playerTurn.Text = "Player 1s Turn!";
            }
            turnCount++;
            button.IsEnabled = false;

            if (turnCount>5)
            {

            }
        }
    }
}
