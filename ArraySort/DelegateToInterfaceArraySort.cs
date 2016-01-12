using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    public class ArraySortAdapter<T> : IComparer<T>
    {
        private readonly Comparison<T> Comparator;

        public ArraySortAdapter(Comparison<T> Comparator)
        {
            this.Comparator = Comparator;
        }

        public int Compare(T x, T y)
        {
            if (x != null && y != null)
                return Comparator(x, y);
            if (x == null && y == null)
                return 0;
            if (x == null)
                return 1;
            return -1;
        }
    }

    public class DelegateToInterfaceArraySort : ArraySortClass
    {
        public override void Sort<T>(T[] array, IComparer<T> compare)
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
    }
}
