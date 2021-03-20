using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW1
{
    class NodHelper
    {
        public static int calculateNode2(int val1, int val2)
        {
            val1 = Math.Abs(val1);
            val2 = Math.Abs(val2);
            if (val2 == 0)
                return val1;
            else
                return calculateNode2(val2, val1 % val2);
        }

        public static int calculateNod3(int val1, int val2, int val3)
        {
            val1 = Math.Abs(val1);
            val2 = Math.Abs(val2);
            val3 = Math.Abs(val3);
            if (val2 == 0)
                return calculateNode2(val1, val3);
            else if (val3 == 0 || val1 == 0)
                return calculateNode2(val2, val3);
            else
                return calculateNod3(val3, val2 % val3, val1 % val3);
        }

        public static int calculateNod3ByNod2(int val1, int val2, int val3)
        {
            val1 = Math.Abs(val1);
            val2 = Math.Abs(val2);
            val3 = Math.Abs(val3);
            int d = calculateNode2(val1, val2);
            return calculateNode2(val3, d);

        }
    }
}
