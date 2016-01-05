using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    public abstract class ArraySortClass
    {
        #region Public Methods

        public abstract void Sort<T>(T[] array, IComparer<T> compare);
     
        #endregion

        #region Protected Metods
        protected void Swamp<T>(ref T a, ref T b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
        #endregion
    }
}
