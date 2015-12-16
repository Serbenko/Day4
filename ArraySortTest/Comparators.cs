using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArraySort;

namespace ArraySortTest
{
    public class SumComparator : ICompare
    {
        public int Compare(int[] a, int[] b)
        {
            if (a == null && b == null)
                return 0;
            if (a == null)
                return -1;
            if (b == null)
                return 1;
            int sumA = a.Sum();
            int sumB = b.Sum();
            if (sumA > sumB)
                return 1;
            if (sumA == sumB)
                    return 0;
            return -1;
        }
    }

    public class MaxElementComparator : ICompare
    {
        public int Compare(int[] a, int[] b)
        {
            if (a == null && b == null)
                return 0;
            if (a == null)
                return -1;
            if (b == null)
                return 1;
            int maxA = a.Max();
            int maxB = b.Max();
            if (maxA > maxB)
                return 1;
            if (maxA == maxB)
                return 0;
            return -1;
        }
    }
}
