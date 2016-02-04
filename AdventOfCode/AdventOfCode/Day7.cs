using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day7
    {
        
        List<Line> Instructions = new List<Line>();
        List<Cable> AllCables = new List<Cable>();
        Array temp;
        Array temp2;
        string resultat = "";
        public Day7(string input)
        {

            temp = input.Split('\n');
            foreach (string s in temp)
                if (!string.IsNullOrWhiteSpace(s))
                    Instructions.Add(new Line(s));
            input = input.Replace("\r", " ");
            input = input.Replace("\n", " ");
            temp2 = input.Split(' ');
            foreach(string s in temp2)
            {

                Match match = Regex.Match(s, "[a-z]");
                if (match.Success)
                    if(!AllCables.Exists(x => x.CableName == s))
                    AllCables.Add(new Cable(s));
            }
            

        }
        public string Result()
        {
            List<Cable> debuglist = new List<Cable>();
            List<Line> Copy = Instructions;
            while (Instructions.Count() > 0)
            {                
                foreach(Line l in Instructions)
                {
                    AllCables= l.test(AllCables);
                    if (l.doable)
                    {
                        Copy.Remove(l);
                        break;
                    }
                                    }
                Instructions = Copy;
            }
            foreach (Cable c in AllCables)
                resultat = resultat + c.getResult() + '\n';
            return resultat;
        }
    }
}