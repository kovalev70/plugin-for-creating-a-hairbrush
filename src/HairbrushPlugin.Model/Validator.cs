namespace Model
{
    /// <summary>
    /// Представляет инструменты для проверки допустимости значений.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проверяет, что указанное значение находится в допустимом диапазоне.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="minValue">Минимальное допустимое значение.</param>
        /// <param name="maxValue">Максимальное допустимое значение.</param>
        /// <returns>True, если значение находится в указанном диапазоне; в противном случае — False.</returns>
        public static bool Validate(double value, double minValue, double maxValue)
        {
            return value >= minValue && value <= maxValue;
        }
    }
}