namespace Tests
{
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class ParameterTests
    {
        [TestCase(10, 50, 20)]
        [TestCase(2, 5, 3)]
        [TestCase(10, 40, 20)]
        public void Parameter_Initialization_SetPropertiesCorrectly(
            double minValue,
            double maxValue,
            double currentValue)
        {
            // Arrange, Act
            var parameter = new Parameter(minValue, maxValue, currentValue);

            // Assert
            Assert.That(parameter.Value, Is.EqualTo(currentValue));
            Assert.That(parameter.MaxValue, Is.EqualTo(maxValue));
            Assert.That(parameter.MinValue, Is.EqualTo(minValue));
        }

        [TestCase(0, 10.0, 20)]
        [TestCase(150, 200, 50)]
        [TestCase(3, 20, 2)]
        public void Parameter_Initialization_CurrentValueOutOfRange_ThrowArgumentException(
            double minValue,
            double maxValue,
            double currentValue)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
                new Parameter(minValue, maxValue, currentValue));
        }

        [TestCase(8, 5, 7)]
        [TestCase(30, 20, 25)]
        [TestCase(250, 200, 225)]
        public void Parameter_Initialization_MinValueGreaterThanMaxValue_ThrowArgumentException(
            double minValue,
            double maxValue,
            double currentValue)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
                new Parameter(minValue, maxValue, currentValue));
        }

        [TestCase(0, 9, -6)]
        [TestCase(0, 40, -20)]
        [TestCase(0, 1000, -100)]
        public void Parameter_Initialization_WithNegativeValues_ShouldThrowArgumentException(
            double minValue,
            double maxValue,
            double currentValue)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
                new Parameter(minValue, maxValue, currentValue));
        }
    }
}