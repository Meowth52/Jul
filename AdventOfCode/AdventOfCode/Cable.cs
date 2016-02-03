using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Cable
    {
        public string CableName;
        public ushort CableValue;
        public bool Assigned= false;
        public Cable (string Name)
        {
            this.CableName = Name;
        }
        public void assignValue(ushort Value)
        {
            CableValue = Value;
            Assigned = true;
        }
        public ushort getValue()
        {
            return CableValue;
        }
        public string getResult()
        {
            return CableName + ": " + CableValue.ToString();
        }
        public bool isAssignd()
        {
            return Assigned;
        }
    }
}
