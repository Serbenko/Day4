using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    public class InterfaceToDelegateArraySort : ArraySortClass
    {
        #region Public Methods

        public override void Sort<T>(T[] array, IComparer<T> compare)
        {
            Sort(array, compare.Compare);
        }

        public void Sort<T>(T[] array, Comparison<T> compare)
        {
            if (array == null || compare == null)
                throw new ArgumentNullException();
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < array.GetLength(0) - i - 1; j++)
                {
                    if (compare(array[j], array[j + 1]) > 0)
                        Swamp(ref array[j], ref array[j + 1]);
                }
            }
        }
        #endregion
    }
}
