using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day5
    {
        private string input;
        public Day5(string inputArg)
        {
             input = inputArg;
        }
        public string Result()
        {
            var inputData = input;
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
            return "del 1 blev " + resultat.ToString() + " del 2 blev " + resultat2.ToString();
        }
                int day = 5;
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
            string suspectChecker = suspect;
            string PairToBeChecked;
            foreach (char c in suspect)
            {
                if (!((iteration - 2) < 0))
                {
                    if (c == suspect[iteration - 2])
                        containsDubbelChar = true;
                }
                if (!(c == '\r'))
                {
                    PairToBeChecked = c + suspect[iteration + 1].ToString();
                    if (suspectChecker.Contains(PairToBeChecked))
                    {
                        suspectChecker = suspectChecker.Remove(suspectChecker.IndexOf(PairToBeChecked), 2);
                        if (suspectChecker.Contains(PairToBeChecked))
                            charCounter++;
                        suspectChecker = suspect;
                    }
                }
                iteration++;                
            }
            numberOfPairs = charCounter;
            nice = (numberOfPairs >= 2) && containsDubbelChar;
            return nice;
          }  
    }
}
