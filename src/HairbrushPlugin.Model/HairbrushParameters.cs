namespace Model
{
    /// <summary>
    /// Класс, описывающий параметры расчески.
    /// </summary>
    public class HairbrushParameters
    {
        /// <summary>
        /// Словарь параметров расчески.
        /// </summary>
        public Dictionary<ParameterType, Parameter> Parameters { get; set; } =
            new Dictionary<ParameterType, Parameter>
            {
                { ParameterType.HandleLength, new Parameter(50, 200, 100) },
                { ParameterType.NumberOfTeeth, new Parameter(20, 50, 25) },
                { ParameterType.LengthOfTeeth, new Parameter(20, 50, 30) },
                { ParameterType.DistanceBetweenTeeth, new Parameter(1, 10, 5) },
                { ParameterType.WidthOfTeeth, new Parameter(1, 3, 2) }
            };
    }
}
