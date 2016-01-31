using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day6
    {
        private string input;
        public Day6(string inputArg)
        {
             input = inputArg;
        }
        public string Result()
        {
            int resultat = 0;
            int resultat2 = 0;
            int xStart=0;
            int yStart=0;
            int xStopp=0;
            int YStopp=0;
            var inputData = input;
            string[] strings = inputData.Split('\n');
            bool[,] lights = new bool[999, 999];
            foreach (string s in strings)
            {

                if (s.StartsWith("turn on"))
                {
                    for (int i = xStart; i <= xStopp; i++)
                        for (int j = yStart; j <= YStopp; j++)
                        {
                            lights[i,j] = true;
                        }
                }
                if (s.StartsWith("turn off"))
                {
                    for (int i = xStart; i <= xStopp; i++)
                        for (int j = yStart; j <= YStopp; j++)
                        {
                            lights[i, j] = false;
                        }
                }
                if (s.StartsWith("toggle"))
                {
                    for (int i = xStart; i <= xStopp; i++)
                        for (int j = yStart; j <= YStopp; j++)
                        {
                            lights[i, j] = !lights[i, j];
                        }
                }
            }
            foreach(bool b in lights)
            {
                if (b)
                    resultat++;
            }
            return "del 1 blev " + resultat.ToString() + " del 2 blev " + resultat2.ToString();
        }
    }
}
