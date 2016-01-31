using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Line
    {
        List<string> content = new List<string>();
        string op;
        string target;
        public Line(string input)
        {
            content = input.Split(' ').ToList();
            content.Reverse();
            target = content.First();
            content.RemoveAt(0);
            content.RemoveAt(0);
            try
            {
                op = content[1];
            }
            catch
            {
                op = "SET";
            }
        }
        public string dumpAll()
        {
            string dump = "";
            foreach (string s in content)
                  dump = dump + s;
            return dump;
        }
    }
}
