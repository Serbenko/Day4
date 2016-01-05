using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NUnit.Framework;
using ArraySort;
namespace ArraySortTest
{
    [TestFixture]
    public class ArraySortClassTest
    {
        int[][] jaggedArray = {
                                new []{1, 2, 3, 4, 5, 6 },
                                new [] {0, 0, 0},
                                null,
                                new [] {-195, 200, 25, 18, -140},
                                new [] {15, 20, 18, 10},
                                null
                              };
        [Test]
        [TestCaseSource(typeof(DataClass), "SortData")]
        public void SortTest(int[][] array, IComparer<int[]> comp, ArraySortClass sort)
        {
            sort.Sort(jaggedArray, comp);
            CollectionAssert.AreEqual(array, jaggedArray);
        }

        public class DataClass
        {
            public IEnumerable<TestCaseData> SortData
            {
                get
                {
                    yield return new TestCaseData(new [] {null, null, new[] { 0, 0, 0 }, new[] { 1, 2, 3, 4, 5, 6 },
                        new[] { 15, 20, 18, 10 }, new [] {-195, 200, 25, 18, -140} }, new MaxElementComparator(), new InterfaceToDelegateArraySort());
                    yield return new TestCaseData(new[] {null, null, new [] {-195, 200, 25, 18, -140}, new[] { 0, 0, 0 },
                        new[] { 1, 2, 3, 4, 5, 6 }, new[] { 15, 20, 18, 10 }}, new SumComparator(), new InterfaceToDelegateArraySort());
                    yield return new TestCaseData(new[] { new [] {-195, 200, 25, 18, -140},  new[] { 15, 20, 18, 10 },
                        new[] { 1, 2, 3, 4, 5, 6 }, new[] { 0, 0, 0 }, null, null }, new MaxElementComparatorDec(), new InterfaceToDelegateArraySort());
                    yield return new TestCaseData(new[] {new[] { 15, 20, 18, 10 }, new[] { 1, 2, 3, 4, 5, 6 }, new[] { 0, 0, 0 },
                        new [] {-195, 200, 25, 18, -140}, null, null }, new SumComparatorDec(), new InterfaceToDelegateArraySort());


                    yield return new TestCaseData(new[] { new[] { 0, 0, 0 }, new[] { 1, 2, 3, 4, 5, 6 },
                        new[] { 15, 20, 18, 10 }, new [] {-195, 200, 25, 18, -140}, null, null, }, new ArraySortAdapter<int[]>((a, b) => Math.Abs(a.Max()) - Math.Abs(b.Max())),
                        new DelegateToInterfaceArraySort());
                    yield return new TestCaseData(new[] { new [] {-195, 200, 25, 18, -140}, new[] { 0, 0, 0 },
                        new[] { 1, 2, 3, 4, 5, 6 }, new[] { 15, 20, 18, 10 }, null, null,}, new ArraySortAdapter<int[]>((a, b) => a.Sum() - b.Sum()),
                        new DelegateToInterfaceArraySort());

                }
            }
        }
    }
}
