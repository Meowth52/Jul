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
        public int optype = 0;
        string op;
        string target;
        public bool doable = true;
        public Line(string input)
        {
            content = input.Split(' ').ToList();
            content.Reverse();
            target = (content.First());
            target = target.Replace("\r", "");
            content.RemoveAt(0);
            content.RemoveAt(0);
            try
            {
                op = content[1];
                content.RemoveAt(1);
            }
            catch
            {
                op = "SET";
            }
            if (op == "SET")
                optype = 1;
            if (op == "AND")
                optype = 2;
            if (op == "OR")
                optype = 3;
            if (op == "LSHIFT")
                optype = 4;
            if (op == "RSHIFT")
                optype = 5;
            if (op == "NOT")
                optype = 6;


        }
        public List<Cable> test(List<Cable> Cables)
        {
            doable = true;
            List<ushort> inputs = new List<ushort>();
            foreach (Cable c in Cables)
                foreach (string s in content)
                    if (c.CableName == s)
                        if (c.isAssignd())
                            inputs.Add(c.getValue());
            foreach (string s in content)
            {
                try
                {
                    inputs.Add(ushort.Parse(s));
                }
                catch
                {
                    //nope
                }
            }
            foreach (Cable c in Cables)
                if (c.CableName == target)
                {
                    var debug = Cables.IndexOf(c);
                    try
                    {
                        switch (optype)
                        {
                            case 1:
                                if (inputs.Count() == 1)
                                    c.assignValue(inputs[0]);
                                else
                                    doable = false;
                                break;
                            case 2:
                                if (inputs.Count() == 2)
                                    c.assignValue((ushort)(inputs[0] & inputs[1]));
                                else
                                    doable = false;
                                break;
                            case 3:
                                if (inputs.Count() == 2)
                                    c.assignValue((ushort)(inputs[0] | inputs[1]));
                                else
                                    doable = false;
                                break;
                            case 4:
                                if (inputs.Count() == 2)
                                    c.assignValue((ushort)(inputs[0] << inputs[1]));
                                else
                                    doable = false;
                                break;
                            case 5:
                                if (inputs.Count() == 2)
                                    c.assignValue((ushort)(inputs[0] >> inputs[1]));
                                else
                                    doable = false;
                                break;
                            case 6:
                                if (inputs.Count() == 1)
                                    c.assignValue((ushort)(~inputs[0]));
                                else
                                    doable = false;
                                break;
                            default:
                                //Frack!
                                break;
                        }
                    }
                    catch
                    {
                        doable = false;
                    }
                }
            return Cables;
        }

        public string dumpAll()
        {
            string dump = "";
            dump = op;
            return dump;
        }
    }
}
