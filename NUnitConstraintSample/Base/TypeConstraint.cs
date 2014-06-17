using NUnit.Framework;

namespace Rain.NUnitConstraint.Base
{
    [TestFixture]
    public class TypeConstraint
    {
        [Test]
        public void should_match_exact_type()
        {
            // CONSTRAINT
            Assert.That("Hello", Is.TypeOf(typeof(string)));
            Assert.That("Hello", Is.Not.TypeOf(typeof(object)));

            // NO BASIC USAGE
        }

        [Test]
        public void should_be_instance_of_type()
        {
            // CONSTRAINT
            Assert.That("Hello", Is.InstanceOf<string>());
            Assert.That("Hello", Is.InstanceOf(typeof(string)));
            Assert.That("Hello", Is.InstanceOf<object>());

            // BASIC
            Assert.IsInstanceOf(typeof(string), "Hello");
            Assert.IsInstanceOf(typeof(object), "Hello");
        }

        [Test]
        public void should_be_assignable_from_another()
        {
            // Unknown usage
//            short i = 100;
//            Assert.That(i, Is.AssignableFrom(typeof(short)));
//            Assert.That(i, Is.AssignableFrom(typeof(double)));
        }
    }
}
