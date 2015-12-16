﻿using System;
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
        public void SortTest(int[][] array, ICompare comp)
        {
            ArraySortClass.Sort(jaggedArray, comp);
            CollectionAssert.AreEqual(array, jaggedArray);
        }

        public class DataClass
        {
            public IEnumerable<TestCaseData> SortData
            {
                get
                {
                    yield return new TestCaseData(new [] {null, null, new[] { 0, 0, 0 }, new[] { 1, 2, 3, 4, 5, 6 },
                        new[] { 15, 20, 18, 10 }, new [] {-195, 200, 25, 18, -140} }, new MaxElementComparator());
                    yield return new TestCaseData(new[] {null, null, new [] {-195, 200, 25, 18, -140}, new[] { 0, 0, 0 },
                        new[] { 1, 2, 3, 4, 5, 6 }, new[] { 15, 20, 18, 10 }}, new SumComparator());
                }
            }
        }
    }
}