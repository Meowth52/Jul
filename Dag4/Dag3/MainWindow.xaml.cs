﻿using System;
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
                inputData = inputData.Replace("\n", "").Replace("\r","");
                string testData = inputData;
                string resultat="fel";
                byte[] byteData;
                int resultat2 = 0;
                int iteration =1;
                int numberofZeros=0;
                bool stringFound = false;
                bool firstStringFound = false;
                MD5 hashis = MD5.Create();
                while (!stringFound)
                {
                    testData = inputData + iteration.ToString();
                    byteData = hashis.ComputeHash(Encoding.UTF8.GetBytes(testData));
                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < byteData.Length; i++)
                    {
                        sBuilder.Append(byteData[i].ToString("x2"));
                    }
                    resultat = sBuilder.ToString();
                    foreach (char c in resultat)
                    {
                        if (c == '0')
                            numberofZeros++;
                        else
                            break;
                    }
                    if (numberofZeros >= 5 && !firstStringFound)
                    {
                        resultat2 = iteration;
                        iteration++;
                        firstStringFound = true;
                    }
                    if (numberofZeros >= 6)
                        stringFound = true;
                    else
                        iteration++;
                    numberofZeros = 0;                    
                }
                output.Text = "del 1 blev " + resultat2.ToString() + " del 2 blev " + iteration.ToString();
            }
        }
    }
}
