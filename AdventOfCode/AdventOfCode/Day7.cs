using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day7
    {
        
        List<Line> Instructions = new List<Line>();
        Array temp;
        string resultat = "";
        public Day7(string input)
        {

            temp = input.Split('\n');
            foreach (string s in temp)
                Instructions.Add(new Line(s));
        }
        public string Result()
        {
            string dump = "";
            foreach (Line l in Instructions)
                dump = dump + l.dumpAll();
            return dump;
        }
    }
}
