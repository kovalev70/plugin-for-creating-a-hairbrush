namespace HairbrushPlugin.Tests
{
    using HairbrushPlugin.Model;
    using NUnit.Framework;

    // TODO: XML
    /// <summary>
    /// Юнит тесты для класса Validator.
    /// </summary>
    [TestFixture]
    public class ValidatorTests
    {
        // TODO: описание
        [TestCase(100, -100, 100, 
            Description = "Проверка вхождения максимального числа в заданный диапазон")]
        [TestCase(-100, -100, 100, 
            Description = "Проверка вхождения минимального числа в заданный диапазон")]
        [TestCase(0, -100, 100, 
            Description = "Проверка вхождения нуля в заданный диапазон")]
        [TestCase(100, 100, 100, 
            Description = "Проверка вхождения максимального и минимального числа в заданный диапазон")]
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

        [TestCase(101, -100, 100, 
            Description = "Проверка выхода заданного числа за максимальный диапазон")]
        [TestCase(-100.01, -100, 100, 
            Description = "Проверка выхода заданного числа за минимальный диапазон")]
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
