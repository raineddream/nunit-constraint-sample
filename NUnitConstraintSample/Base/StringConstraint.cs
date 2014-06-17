using System.ComponentModel.Design.Serialization;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Rain.NUnitConstraint.Base
{
    [TestFixture]
    public class StringConstraint
    {
        private string _phrase;

        [SetUp]
        public void Setup()
        {
            _phrase = "Make your tests fail before passing!";
        }

        [Test]
        public void should_contain_sub_string()
        {
            // CONSTRAINT
            Assert.That(_phrase, Is.StringContaining("tests fail"));
            Assert.That(_phrase, Is.StringContaining("TESTS FAIL").IgnoreCase);

            // BASIC
            Assert.IsTrue(_phrase.Contains("tests fail"));
            Assert.IsTrue(_phrase.ToLower().Contains("tests fail"));
        }

        [Test]
        public void should_start_with_string()
        {
            // CONSTRAINT
            Assert.That(_phrase, Is.StringStarting("Make"));
            Assert.That(_phrase, Is.Not.StringStarting("Break"));

            // BASIC
            Assert.IsTrue(_phrase.StartsWith("Make"));
            Assert.IsFalse(_phrase.StartsWith("Break"));
        }

        [Test]
        public void should_end_with_string()
        {
            // CONSTRAINT
            Assert.That(_phrase, Is.StringEnding("!"));
            Assert.That(_phrase, Is.StringEnding("PASSING!").IgnoreCase);

            // BASIC
            Assert.IsTrue(_phrase.EndsWith("!"));
            Assert.IsTrue(_phrase.ToUpper().EndsWith("PASSING!"));
        }

        [Test]
        public void should_match_regex()
        {
            // CONSTRAINT
            Assert.That(_phrase, Is.StringMatching("Make.*tests.*pass"));

            // BASIC
            Assert.IsTrue(Regex.IsMatch(_phrase, "Make.*tests.*pass"));
        }
    }
}
