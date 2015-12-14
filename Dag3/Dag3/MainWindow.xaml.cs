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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            input.Focus();
            input.SelectAll();
            
        }

        public int[] getDirection(char c)
        {
            int[] returnvalue = new int[] {0,0};
            switch(c)
            {
                case '<':
                    returnvalue[0] = -1;
                    return returnvalue;
                case '>':
                    returnvalue[0] = +1;
                    return returnvalue;
                case '^':
                    returnvalue[1] = +1;
                    return returnvalue;
                case 'v':
                    returnvalue[1] = -1;
                    return returnvalue;
                default:
                    return returnvalue;
            }            
        }
        public int[] getSum(int[] a, int[] b)
        {
            int[] returnvalue=new int[]{0,0};
            returnvalue[0] = a[0] + b[0];
            returnvalue[1] = a[1] + b[1];
            return returnvalue;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                var inputData = input.Text;
                int resultat =1;
                int resultat2 = 0;
                int iteration =0;
                bool first = false;
                bool unique;
                int[] direction;
                int[] current = new int[] {0,0};
                List<int[]> positions = new List<int[]>();
                positions.Add(current);
                foreach (char c in inputData)
                {                    
                    direction = getDirection(c);
                    if (!first)
                        current = getSum(positions[iteration], direction);
                    else
                        current = getSum(positions[(iteration-1)], direction);
                    unique = true;
                    if (!first)
                        first = true;
                    foreach (int[] i in positions)
                    {
                        if (i[0] == current[0] && i[1] == current[1])
                            unique = false;
                    }
                    if (unique)
                    {
                        resultat++;
                    }
                    positions.Add(current);
                    iteration++;
                }
                output.Text = resultat.ToString();
            }
        }
    }
}
