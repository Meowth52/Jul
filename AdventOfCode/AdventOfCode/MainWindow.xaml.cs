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
using System.Security.Cryptography;

namespace AdventOfCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool stringJudger(string suspect)
        {
            bool nice = false;
            int numberOfVowels=0;
            bool containsDubbelChar = false;
            bool containsForbiddenString = false;
            char lastChar=suspect[0];
            string vowels = "aeiou";
            bool first = true;
            List<string> forbiddenStrings = new List<string>();
            forbiddenStrings.Add("ab");
            forbiddenStrings.Add("cd");
            forbiddenStrings.Add("pq");
            forbiddenStrings.Add("xy");

            foreach (char c in suspect)
            {
                if (c == lastChar && !first)
                    containsDubbelChar = true;
                lastChar = c;
                first = false;
                if (vowels.Contains(c))
                    numberOfVowels++;
            }
            foreach (string s in forbiddenStrings)
            {
                if (suspect.Contains(s))
                    containsForbiddenString = true;
            }
            nice = (numberOfVowels >= 3) && containsDubbelChar && !containsForbiddenString;
            return nice;
        }
        public bool stringJudger2(string suspect)
        {
            bool nice = false;
            int numberOfPairs = 0;
            int charCounter = 0;
            bool containsDubbelChar = false;
            int iteration = 0;
            foreach (char c in suspect)
            {
                if (!((iteration - 2) < 0))
                {
                    if (c == suspect[iteration - 2])
                        containsDubbelChar = true;
                }
                if (suspect.Contains(c + suspect[iteration].ToString()))
                    numberOfPairs++;
                iteration++;                
            }
            numberOfPairs = numberOfPairs + charCounter / 2;
            nice = (numberOfPairs >= 2) && containsDubbelChar;
            return nice;
        }
        public MainWindow()
        {
            InitializeComponent();
            input.Focus();
            input.SelectAll();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var inputData = input.Text;
                inputData.Replace("\r", "");
                string[] strings = inputData.Split('\n');
                int resultat = 0;
                int resultat2 = 0;
                int iteration = 0;
                bool nice = true;
                foreach (string s in strings)
                {
                    if (!(s == ""))
                    {
                        if (stringJudger(s) == nice)
                            resultat++;
                    }
                }
                foreach (string s in strings)
                {
                    if (!(s == ""))
                    {
                        if (stringJudger2(s) == nice)
                            resultat2++;
                    }
                }
                output.Text = "del 1 blev " + resultat.ToString() + " del 2 blev " + resultat2.ToString();
            }
        }
    }
}
