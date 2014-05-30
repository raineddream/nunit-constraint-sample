using NUnit.Framework;

namespace Rain.NUnitConstraint.Base
{
    [TestFixture]
    public class EqualConstraint
    {
        [Test]
        public void Should_simply_assert_string()
        {
            const string part1 = "ab", part2 = "cd";

            // CONSTRAINT
            Assert.That(part1 + part2, Is.EqualTo("abcd"));

            // BASIC
            Assert.AreEqual("abcd", part1 + part2);
        }

        [Test]
        public void Should_simply_assert_integer()
        {
            const int a = 2, b = 3;

            // CONSTRAINT
            Assert.That(a + b, Is.EqualTo(5));

            // BASIC
            Assert.AreEqual(5, a + b);
        }

        [Test]
        public void Should_simply_assert_unequal()
        {
            const int a = 2, b = 3;

            // CONSTRAINT
            Assert.That(a + b, Is.Not.EqualTo(4));

            // BASIC
            Assert.AreNotEqual(4, a + b);
        }

        [Test]
        public void Should_simply_assert_double_with_tolerance()
        {
            const double a = 2.1, b = 1.2;

            // CONSTRAINT
            Assert.That(a + b, Is.EqualTo( 3.3 ).Within(.0005));

            // BASIC
            Assert.AreEqual(3.3, a + b, .0005);
        }

        [Test]
        public void Should_assert_array_equal()
        {
            int[] i1 = { 1, 2, 3 };
            double[] d1 = { 1.0, 2.0, 3.0 };

            // CONSTRAINT
            Assert.That(i1, Is.EqualTo(d1));

            // BASIC
            Assert.AreEqual(d1, i1);
        }

        [Test]
        public void Should_assert_array_unequal()
        {
            int[] i1 = { 1, 2, 3 };
            int[] i2 = { 1, 3, 2 };

            // CONSTRAINT
            Assert.That(i1, Is.Not.EqualTo(i2));

            // BASIC
            Assert.AreNotEqual(i2, i1);
        }

        [Test]
        public void Should_assert_multi_dimension_array_equal()
        {
            int[,] array2X2 = { { 1, 2 }, { 3, 4 } };
            int[] array4 = { 1, 2, 3, 4 };

            // CONSTRAINT
            Assert.That(array2X2, Is.EqualTo(array4).AsCollection);

            // BASIC
            // Assert.AreEqual(array4, array2X2);  // Does not work

            int[] tempArray = new int[4];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tempArray[i*2 + j] = array2X2[i, j];
                }
            }
            Assert.AreEqual(array4, tempArray);
        }

        [Test]
        public void Should_assert_string_with_case_insensitive()
        {
            // CONSTRAINT
            Assert.That("Hello!", Is.EqualTo("HELLO!").IgnoreCase);

            // BASIC
            Assert.AreEqual("hello!", "Hello!".ToLower());
        }

        [Test]
        public void Should_assert_string_array_with_case_insensitive()
        {
            string[] expected = { "Hello", "World" };
            string[] actual = { "HELLO", "world" };

            // CONSTRAINT
            Assert.That(actual, Is.EqualTo(expected).IgnoreCase);

            // BASIC
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].ToLower(), actual[i].ToLower());
            }
        }
    }
}
