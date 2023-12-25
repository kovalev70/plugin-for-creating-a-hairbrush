namespace Tests
{
    using Model;
    using NUnit.Framework;

    // TODO: XML
    [TestFixture]
    public class ValidatorTests
    {
        // TODO: описание
        [TestCase(100, -100, 100)]
        [TestCase(-100, -100, 100)]
        [TestCase(0, -100, 100)]
        [TestCase(100, 100, 100)]
        public void TestIsValueInRange_ValueInRange_ResultEqual(
            double currentValue,
            double minValue,
            double maxValue)
        {
            // Setup
            var expected = true;

            // Act
            var actual = Validator.Validate(currentValue, minValue, maxValue);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(101, -100, 100)]
        [TestCase(-100.01, -100, 100)]
        public void TestIsValueInRange_ValueNotInRange_ResultEqual(
            double currentValue,
            double minValue,
            double maxValue)
        {
            // Setup
            var expected = false;

            // Act
            var actual = Validator.Validate(currentValue, minValue, maxValue);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
