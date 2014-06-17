using System.Collections.Generic;
using NUnit.Framework;

namespace Rain.NUnitConstraint.Base
{
    [TestFixture]
    public class ConditionConstraint
    {
        [Test]
        public void should_be_null()
        {
            object a = null;

            // CONSTRAINT
            Assert.That(a, Is.Null);

            // BASIC
            Assert.Null((a));
        }

        [Test]
        public void should_NOT_be_null()
        {
            var a = new object();

            // CONSTRAINT
            Assert.That(a, Is.Not.Null);

            // BASIC
            Assert.NotNull(a);
        }

        [Test]
        public void should_be_true()
        {
            var a = true;

            // CONSTRAINT
            Assert.That(a, Is.True);

            // BASIC
            Assert.IsTrue(a);
        }

        [Test]
        public void should_be_false()
        {
            var a = false;

            // CONSTRAINT
            Assert.That(a, Is.False);

            // BASIC
            Assert.IsFalse(a);
        }

        [Test]
        public void should_NOT_be_a_number()
        {
            var a = double.NaN;

            // CONSTRAINT
            Assert.That(a, Is.NaN);

            // BASIC
            Assert.IsNaN(a);
        }

        [Test]
        public void should_be_an_empty_string()
        {
            var a = "";

            // CONSTRAINT
            Assert.That(a, Is.Empty);

            // BASIC
            Assert.IsEmpty(a);
        }

        [Test]
        public void should_be_an_empty_collection()
        {
            var list = new List<object>();

            // CONSTRAINT
            Assert.That(list, Is.Empty);

            // BASIC
            Assert.IsEmpty(list);
        }

        [Test]
        public void should_be_an_unique_collection()
        {
            var list = new List<object>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // CONSTRAINT
            Assert.That(list, Is.Unique);

            // BASIC
            AssertUnique(list);
        }

        private void AssertUnique(IList<object> list)
        {
            var keys = new HashSet<object>();
            foreach (object item in list)
            {
                if (keys.Contains(item))
                {
                    Assert.Fail();
                }
                keys.Add(item);
            }
        }
    }
}
