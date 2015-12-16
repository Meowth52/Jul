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

namespace AdventOfCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int day = 5;
        public MainWindow()
        {
            InitializeComponent();
            input.Focus();
            input.SelectAll();
            ValdDag.Content = day.ToString();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Day5 chosenDay = new Day5(input.Text);
                output.Text = chosenDay.Result();
            }
        }
        private void onClick5(object sender, RoutedEventArgs e)
        {
            day = 5;
            ValdDag.Content = day.ToString();
        }

        private void onClick6(object sender, RoutedEventArgs e)
        {
            day = 6;
            ValdDag.Content = day.ToString();
        }
    }
}
