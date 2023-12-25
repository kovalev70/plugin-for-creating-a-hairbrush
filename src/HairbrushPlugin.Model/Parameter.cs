namespace Model
{
    /// <summary>
    /// Представляет параметр с определенным диапазоном значений.
    /// </summary>
    public class Parameter
    {
        // TODO: XML
        private double _value;

        /// <summary>
        /// Инициализирует новый экземпляр класса Parameter с указанными значениями.
        /// </summary>
        /// <param name="minValue">Минимальное допустимое значение.</param>
        /// <param name="maxValue">Максимальное допустимое значение.</param>
        /// <param name="value">Значение параметра.</param>
        /// <exception cref="ArgumentException">Не удается создать экземпляр класса Parameter,
        /// если значение минимума больше значения максимума.</exception>
        public Parameter(double minValue, double maxValue, double value)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException(
                    "Значение минимума не может быть больше максимума.");
            }

            MinValue = minValue;
            MaxValue = maxValue;
            Value = value;
        }

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public double Value
        {
            get => _value;

            set
            {
                _value = value;
                if (!Validator.Validate(_value, MinValue, MaxValue))
                {
                    throw new ArgumentException(
                        $"Значение выделенного параметра " +
                            $"должно быть в диапозоне от {MinValue} " +
                            $"до {MaxValue}.");
                }
            }
        }
    }
}