using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    public static class ArraySortClass
    {
        public static void Sort(int[][] array, ICompare compare)
        {
            if (array == null || compare == null)
                throw new ArgumentNullException();
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < array.GetLength(0)- i - 1; j++)
                {
                    if (compare.Compare(array[j], array[j + 1]) > 0)
                        Swamp(ref array[j], ref array[j + 1]);
                }
            }
        }

        private static void Swamp(ref int[] a, ref int[] b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }

    public interface ICompare
    {
        int Compare(int[] a, int[] b);
    }
}
