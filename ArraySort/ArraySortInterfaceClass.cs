using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    public static class ArraySortInterfaceClass
    {
        #region Public Methods
        public static void Sort(int[][] array, IComparer<int[]> compare)
        {
            if (array == null || compare == null)
                throw new ArgumentNullException();
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < array.GetLength(0) - i - 1; j++)
                {
                    if (compare.Compare(array[j], array[j + 1]) > 0)
                        Swamp(ref array[j], ref array[j + 1]);
                }
            }
        }
        #endregion

        #region Private Metods
        private static void Swamp(ref int[] a, ref int[] b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
        #endregion
    }

    public class Comparation : IComparer<int[]>
    {
        Comparator comparator;

        public Comparation(Comparator comparator)
        {
            this.comparator = comparator;
        }
        public int Compare(int[] a, int[] b)
        {
            return comparator(a, b);
        }
    }
}
