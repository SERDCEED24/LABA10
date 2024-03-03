using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA10
{
    public class SortByYear : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Car b1 = (Car)x;
            Car b2 = (Car)y;
            if (b1.Year < b2.Year) return -1;
            else
                if (b1.Year == b2.Year) return 0;
            else
                return 1;
        }
    }
}
