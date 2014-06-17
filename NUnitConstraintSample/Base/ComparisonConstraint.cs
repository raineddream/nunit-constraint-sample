using NUnit.Framework;

namespace Rain.NUnitConstraint.Base
{
    [TestFixture]
    public class ComparisonConstraint
    {
        [Test]
        public void should_be_greater_than()
        {
            // CONSTRAINT
            Assert.That(7, Is.GreaterThan(3));

            // BASIC
            Assert.Greater(7, 3);
        }

        [Test]
        public void should_be_greater_than_or_equal_to()
        {
            // CONSTRAINT
            Assert.That(7, Is.GreaterThanOrEqualTo(3));
            Assert.That(7, Is.AtLeast(3));

            // BASIC
            Assert.GreaterOrEqual(7, 3);
        }

        [Test]
        public void should_be_less_than()
        {
            // CONSTRAINT
            Assert.That(3, Is.LessThan(7));

            // BASIC
            Assert.Less(3, 7);
        }

        [Test]
        public void should_be_less_than_or_equal_to()
        {
            // CONSTRAINT
            Assert.That(3, Is.LessThanOrEqualTo(7));
            Assert.That(3, Is.AtMost(7));

            // BASIC
            Assert.LessOrEqual(3, 7);
        }
    }
}
