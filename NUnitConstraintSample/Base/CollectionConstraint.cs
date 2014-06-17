using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Rain.NUnitConstraint.Base
{
    [TestFixture]
    public class CollectionConstraint
    {
        [Test]
        public void should_be_not_none()
        {
            int[] iarray = { 1, 2, 3 };

            // CONSTRAINT
            Assert.That(iarray, Is.All.Not.Null);

            // BASIC
            AssertArrayNull(iarray);
        }

        [Test]
        public void should_be_instance_of_type()
        {
            string[] sarray = {"a", "b", "c"};

            // CONSTRAINT
            Assert.That(sarray, Is.All.InstanceOfType(typeof(string)));

            // BASIC
            AssertInstanceOf(typeof(string), sarray);
        }

        [Test]
        public void should_be_greater_than()
        {
            int[] iarray = {1, 2, 3};

            // CONSTRAINT
            Assert.That(iarray, Is.All.GreaterThan(0));

            // BASIC
            AssertGreaterThan(iarray, 0);
        }

        [Test]
        public void should_compare_equality_of_all_items_in_array()
        {
            string[] sarray = {"a", "b", "c"};

            // CONSTRAINT
            Assert.That(new[] {"c", "a", "b"}, Is.EquivalentTo(sarray));

            // BASIC
            AssertArrayItemEquality(sarray, new[] {"c", "a", "b"});
        }

        [Test]
        public void should_be_subset_of_array()
        {
            int[] iarray = { 1, 2, 3 };

            // CONSTRAINT
            Assert.That(new[] {1, 3}, Is.SubsetOf(iarray));

            // BASIC
            AssertSubset(iarray, new[] {1, 3});
        }

        private void AssertSubset(int[] array, int[] subset)
        {
            foreach (int item in subset)
            {
                if (!array.Contains(item))
                {
                    Assert.Fail();
                }
            }
        }

        private void AssertArrayItemEquality(string[] expected, string[] actual)
        {
            var first = expected.GroupBy(s => s).ToDictionary(g => g.Key, g => g.Count());
            var second = actual.GroupBy(s => s).ToDictionary(g => g.Key, g => g.Count());

            bool equals = first.OrderBy(kvp => kvp.Key).SequenceEqual(second.OrderBy(kvp => kvp.Key));
            Assert.IsTrue(equals);
        }

        private void AssertGreaterThan(int[] iarray, int threshold)
        {
            foreach (int item in iarray)
            {
                if (item <= threshold)
                {
                    Assert.Fail();
                }
            }
        }

        private void AssertInstanceOf<T>(Type type, T[] array)
        {
            foreach (T item in array)
            {
                if (item.GetType() != type)
                {
                    Assert.Fail();
                }
            }
        }

        private void AssertArrayNull<T>(T[] array)
        {
            foreach (T item in array)
            {
                if (item == null)
                {
                    Assert.Fail();
                }
            }
        }
    }
}
