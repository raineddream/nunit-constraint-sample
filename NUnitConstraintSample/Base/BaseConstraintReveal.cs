using NUnit.Framework;

namespace Rain.NUnitConstraint.Base
{
    [TestFixture]
    public class BaseConstraintReveal
    {
        [Test]
        public void Should_simply_assert_string()
        {
            const string part1 = "ab", part2 = "cd";

            Assert.That(part1 + part2, Is.EqualTo("abcd"));
        }

        [Test]
        public void Should_simply_assert_integer()
        {
            const int a = 2, b = 3;

            Assert.That(a + b, Is.EqualTo(5));
        }

        [Test]
        public void Should_simply_assert_unequal()
        {
            const int a = 2, b = 3;

            Assert.That(a + b, Is.Not.EqualTo(4));
        }

        [Test]
        public void Should_simply_assert_double_with_tolerance()
        {
            const double a = 2.1, b = 1.2;

            Assert.That(a + b, Is.EqualTo( 3.3 ).Within(.0005));
        }

        [Test]
        public void Should_assert_array_equal()
        {
            int[] i1 = { 1, 2, 3 };
            double[] d1 = { 1.0, 2.0, 3.0 };

            Assert.That(i1, Is.EqualTo(d1));
        }

        [Test]
        public void Should_assert_array_unequal()
        {
            int[] i1 = { 1, 2, 3 };
            int[] i2 = { 1, 3, 2 };

            Assert.That(i1, Is.Not.EqualTo(i2));
        }

        [Test]
        public void Should_assert_multi_dimension_array_equal()
        {
            int[,] array2X2 = { { 1, 2 }, { 3, 4 } };
            int[] array4 = { 1, 2, 3, 4 };

            Assert.That(array2X2, Is.EqualTo(array4).AsCollection);
        }

        [Test]
        public void Should_assert_string_with_case_insensitive()
        {
            Assert.That("Hello!", Is.EqualTo("HELLO!").IgnoreCase);
        }

        [Test]
        public void Should_assert_string_array_with_case_insensitive()
        {
            string[] expected = { "Hello", "World" };
            string[] actual = { "HELLO", "world" };

            Assert.That( actual, Is.EqualTo( expected ).IgnoreCase);
        }
    }
}
