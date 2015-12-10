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

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                var inputData = input.Text;
                int resultat =0;
                int iteration =0;
                char packetsplitter = '\n';
                char dimensionsplitter = 'x'; 
                string[] packets = inputData.Split(packetsplitter);
                string[] dimensionstring;
                List<int> dimensions = new List<int>();
                List<Present> presentList = new List<Present>();
                foreach (string s in packets)
                {
                    if (s !="")
                    {
                        dimensionstring = s.Split(dimensionsplitter);

                        foreach (string ss in dimensionstring)
                        {
                            dimensions.Add(Int32.Parse(ss));
                        }
                        presentList.Add(new Present(dimensions));
                        dimensions.Clear();
                        iteration++;
                    }
                }
                foreach (Present p in presentList)
                {
                    resultat = resultat + p.PaperAmount();
                }
                //foreach (char c in inputData)
                //{
                //    if (c=='\n')
                //    {
                //        resultat++;

                //        stringlenght = 0;
                //    }
                //    stringlenght++;
                //    iteration++;
                //}
                output.Text = resultat.ToString();
            }
        }
    }
}
