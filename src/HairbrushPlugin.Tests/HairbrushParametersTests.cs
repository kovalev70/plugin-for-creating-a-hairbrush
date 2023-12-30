namespace HairbrushPlugin.Tests
{
    using HairbrushPlugin.Model;
    using NUnit.Framework;

    /// <summary>
    /// Юнит тесты для класса HairbrushParameters.
    /// </summary>
    [TestFixture]
    public class HairbrushParametersTests
    {
        /// <summary>
        /// Тест на инициализация параметров.
        /// </summary>
        [Test]
        public void Parameters_InitializedCorrectly()
        {
            // Arrange
            var hairbrushParameters = new HairbrushParameters();

            // Act

            // Assert
            Assert.That(hairbrushParameters.Parameters, Is.Not.Null);
            Assert.That(hairbrushParameters.Parameters, Is.InstanceOf<Dictionary<ParameterType, Parameter>>());
        }

        /// <summary>
        /// Тесты на методы методы установки и получения параметров.
        /// </summary>
        [Test]
        public void Parameters_SetAndGetMethods_WorkingCorrectly()
        {
            // Arrange
            var hairbrushParameters = new HairbrushParameters();
            var newParameters = new Dictionary<ParameterType, Parameter> {
                { ParameterType.HandleLength, new Parameter(60, 180, 120) },
            };

            // Act
            hairbrushParameters.Parameters = newParameters;
            var retrievedParameters = hairbrushParameters.Parameters;

            // Assert
            Assert.That(retrievedParameters, Is.EqualTo(newParameters));
        }

        [TestCase(ParameterType.HandleLength, 50,
            Description = "Убедитесь, что значение HandleLength находится в пределах заданных минимального и максимального значений")]
        [TestCase(ParameterType.HandleWidth, 20,
            Description = "Убедитесь, что значение HandleWidth находится в пределах заданных минимального и максимального значений")]
        // Add more test cases to cover different parameter types and values
        public void Parameters_ValuesInRange(ParameterType parameterType, int expectedValue)
        {
            // Arrange
            var hairbrushParameters = new HairbrushParameters();

            // Act
            var actualValue = hairbrushParameters.Parameters[parameterType].Value;

            // Assert
            Assert.That(actualValue, Is.GreaterThanOrEqualTo(hairbrushParameters.Parameters[parameterType].MinValue));
            Assert.That(actualValue, Is.LessThanOrEqualTo(hairbrushParameters.Parameters[parameterType].MaxValue));
        }
    }
}
