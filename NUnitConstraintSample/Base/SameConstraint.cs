using System;
using NUnit.Framework;

namespace Rain.NUnitConstraint.Base
{
    [TestFixture]
    public class SameConstraint
    {
        [Test]
        public void should_be_same()
        {
            Exception ex1 = new Exception();
            Exception ex2 = ex1;

            // CONSTRAINT
            Assert.That(ex2, Is.SameAs(ex1));

            // BASIC
            Assert.AreSame(ex1, ex2);
        }
        [Test]
        public void should_NOT_be_same()
        {
            Exception ex1 = new Exception();
            Exception ex2 = new Exception();

            // CONSTRAINT
            Assert.That(ex2, Is.Not.SameAs(ex1));

            // BASIC
            Assert.AreNotSame(ex1, ex2);
        }
    }
}
