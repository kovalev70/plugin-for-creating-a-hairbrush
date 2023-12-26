namespace HairbrushPlugin.Tests
{
    using HairbrushPlugin.Model;
    using NUnit.Framework;
    
    /// <summary>
    /// Юнит тесты для класса Pararmeter.
    /// </summary>
    [TestFixture]
    public class ParameterTests
    {
        [TestCase(10, 50, 20,
            Description = "Тестирование инициализации параметра с допустимыми значениями")]
        [TestCase(2, 5, 3,
            Description = "Тестирование инициализации параметра с другими допустимыми значениями")]
        [TestCase(10, 40, 20,
            Description = "Тестирование инициализации параметра с различными допустимыми значениями")]
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

        [TestCase(0, 10.0, 20,
            Description = "Тестирование инициализации параметра с currentValue больше, чем maxValue")]
        [TestCase(150, 200, 50,
            Description = "Тестирование инициализации параметра с minValue больше, чем currentValue")]
        [TestCase(3, 20, 2,
            Description = "Тестирование инициализации параметра с currentValue меньше, чем minValue")]
        public void Parameter_Initialization_CurrentValueOutOfRange_ThrowArgumentException(
            double minValue,
            double maxValue,
            double currentValue)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
                new Parameter(minValue, maxValue, currentValue));
        }

        [TestCase(8, 5, 7, 
            Description = "Тестирование инициализации параметра с minValue больше, чем maxValue")]
        [TestCase(30, 20, 25, 
            Description = "Тестирование инициализации параметра с другими значениями, где minValue больше, чем maxValue")]
        [TestCase(250, 200, 225, 
            Description = "Тестирование инициализации параметра с различными значениями, где minValue больше, чем maxValue")]
        public void Parameter_Initialization_MinValueGreaterThanMaxValue_ThrowArgumentException(
            double minValue,
            double maxValue,
            double currentValue)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
                new Parameter(minValue, maxValue, currentValue));
        }

        [TestCase(0, 9, -6,
            Description = "Тестирование инициализации параметра с отрицательным currentValue")]
        [TestCase(0, 40, -20,
            Description = "Тестирование инициализации параметра с другим отрицательным currentValue")]
        [TestCase(0, 1000, -100,
            Description = "Тестирование инициализации параметра с другим отрицательным currentValue")]
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