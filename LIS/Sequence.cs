using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS
{
    public class Sequence
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int Length
        {
            get
            {
                return EndIndex - StartIndex + 1;
            }
        }
    }
}
