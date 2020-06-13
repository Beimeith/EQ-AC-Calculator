using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ_AC_Calculator
{
    class SoftCap
    {
        public int ClassNumber { set; get; }
        public int Level { set; get; }
        public int Cap { set; get; }
        public decimal Multiplier { set; get; }

        public SoftCap(int CN, int L, int C, decimal M)
        {
            ClassNumber = CN;
            Level = L;
            Cap = C;
            Multiplier = M;
        }
    }
}
