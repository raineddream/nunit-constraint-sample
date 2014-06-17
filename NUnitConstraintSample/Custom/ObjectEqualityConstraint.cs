using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Rain.NUnitConstraint.Custom
{
    [TestFixture]
    public class PetTest
    {
        [Test]
        public void should_equal()
        {
            var cat = new Pet("Tom", PetType.Cat, 6);

            Assert.That(cat, Should.EqualTo(new Pet("Tom", PetType.Cat, 6)));
        }
    }

    #region Domain

    public class Pet
    {
        public Pet(string name, PetType type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }

        public string Name { get; private set; }
        public PetType Type { get; private set; }
        public int Age { get; private set; }
    }

    public enum PetType
    {
        Cat, Dog
    }
    
    #endregion

    #region Custom Constraint

    public class Should
    {
        public static IResolveConstraint EqualTo(Pet expected)
        {
            return new PetEqualityConstraint(expected);
        }
    }

    public class PetEqualityConstraint : Constraint
    {
        private readonly Pet _expectedPet;
        private object _actual;
        private ConstraintType issue;

        public PetEqualityConstraint(Pet expectedPet)
        {
            _expectedPet = expectedPet;
        }

        public override bool Matches(object actual)
        {
            _actual = actual;
            var actualPet = _actual as Pet;
            if (actualPet == null)
            {
                issue = ConstraintType.MismatchedType;
                return false;
            }

            if (!_expectedPet.Name.Equals(actualPet.Name) || _expectedPet.Type != actualPet.Type ||
                _expectedPet.Age != actualPet.Age)
            {
                issue = ConstraintType.Unequality;
                return false;
            }

            return true;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            if (issue == ConstraintType.MismatchedType)
            {
                writer.WriteLine(_expectedPet.GetType());
            }
            else if (issue == ConstraintType.Unequality)
            {
                writer.WriteLine(ConvertToString(_expectedPet));
            }
        }

        private string ConvertToString(Pet pet)
        {
            return String.Format("Pet [Name = {0}, Type = {1}, Age = {2}]", _expectedPet.Name, _expectedPet.Type,
                _expectedPet.Age);
        }

        public override void WriteActualValueTo(MessageWriter writer)
        {
            if (issue == ConstraintType.MismatchedType)
            {
                writer.WriteLine(_actual.GetType());
            }
            else if (issue == ConstraintType.Unequality)
            {
                writer.WriteLine(ConvertToString((Pet)_actual));
            }
        }

        private enum ConstraintType
        {
            MismatchedType,
            Unequality
        }
    }

    #endregion
}
