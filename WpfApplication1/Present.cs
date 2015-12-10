using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    class Present
    {
        private int x;
        private int y;
        private int z;
        public Present(List<int> dimensions)
        {
            dimensions.Sort();
            this.x = dimensions[0];
            this.y = dimensions[1];
            this.z = dimensions[2];
        }
        public int PaperAmount()
        {
            return x*2+y*2+x*y*z;
        }

    }
}
