namespace HairbrushPlugin.Wrapper
{
    using HairbrushPlugin.Model;
    using Kompas6API5;

    /// <summary>
    /// Класс для построения расчески.
    /// </summary>
    public class HairbrushBuilder
    {
        /// <summary>
        /// Расстояние между внешней стенкой и зубьями.
        /// </summary>
        private const double OuterWall = 10;

        /// <summary>
        /// Объект KompasWrapper.
        /// </summary>
        private readonly KompasWrapper _wrapper = new ();

        /// <summary>
        /// Строит расческу на основе заданных параметров.
        /// </summary>
        /// <param name="parameters">Параметры, необходимые для построения расчески.</param>
        public void BuildHairbrush(HairbrushParameters parameters)
        {
            _wrapper.ConnectToCAD();
            _wrapper.CreateDocument3D();
            var handleLength = parameters.Parameters[ParameterType.HandleLength].Value;
            var numberOfTeeth = (int)parameters.Parameters[ParameterType.NumberOfTeeth].Value;
            var lengthOfTeeth = parameters.Parameters[ParameterType.LengthOfTeeth].Value;
            var distanceBetweenTeeth = parameters.Parameters[ParameterType.DistanceBetweenTeeth].Value;
            var widthOfTeeth = parameters.Parameters[ParameterType.WidthOfTeeth].Value;
            var handleWidth = parameters.Parameters[ParameterType.HandleWidth].Value;
            var lengthOfBase = (numberOfTeeth * (distanceBetweenTeeth + widthOfTeeth))
                + distanceBetweenTeeth + ((2 * widthOfTeeth) + 2);
            var xPosition = (lengthOfTeeth + OuterWall) / 2;

            var hairbrushSketch = _wrapper.CreateSketch();
            var document2d = (ksDocument2D)hairbrushSketch.BeginEdit();
            document2d.ksPolyline(1);

            BuildBody(
                document2d,
                xPosition,
                lengthOfTeeth,
                widthOfTeeth,
                lengthOfBase);

            BuildTeeth(
                document2d,
                numberOfTeeth,
                lengthOfTeeth,
                widthOfTeeth,
                distanceBetweenTeeth,
                xPosition,
                lengthOfBase);

            BuildHandle(
                document2d,
                handleLength,
                xPosition,
                lengthOfTeeth,
                widthOfTeeth,
                handleWidth);

            document2d.ksEndObj();
            hairbrushSketch.EndEdit();

            _wrapper.MakeExtrusion(5);
        }

        /// <summary>
        /// Строит внешнюю и верхнюю часть расчески на основе заданных параметров.
        /// </summary>
        /// <param name="document2d">Объект 2д документа.</param>
        /// <param name="xPosition">X координата, относительно которой мы строим расческу.</param>
        /// <param name="lengthOfTeeth">Длина зубца расчески.</param>
        /// <param name="widthOfTeeth">Ширина зубца расчески.</param>
        /// <param name="lengthOfBase">Длина основания расчески.</param>
        private void BuildBody(
                ksDocument2D document2d,
                double xPosition,
                double lengthOfTeeth,
                double widthOfTeeth,
                double lengthOfBase)
        {
            document2d.ksPoint(
                xPosition,
                0,
                default);
            document2d.ksPoint(
                xPosition,
                lengthOfBase,
                default);
            document2d.ksPoint(
                xPosition - lengthOfTeeth - OuterWall + 1,
                lengthOfBase - widthOfTeeth - 1,
                default);
            document2d.ksPoint(
                xPosition - lengthOfTeeth - OuterWall,
                lengthOfBase - widthOfTeeth - 1 - (widthOfTeeth / 3),
                default);
            document2d.ksPoint(
                xPosition - lengthOfTeeth - OuterWall,
                lengthOfBase - widthOfTeeth - 2 - (2 * (widthOfTeeth / 3)),
                default);
            document2d.ksPoint(
                xPosition - lengthOfTeeth - OuterWall + 1,
                lengthOfBase - (2 * widthOfTeeth) - 2,
                default);
            document2d.ksPoint(
                xPosition - OuterWall,
                lengthOfBase - (2 * widthOfTeeth) - 2,
                default);
        }

        /// <summary>
        /// Строит зубцы на основании заданных параметров.
        /// </summary>
        /// <param name="document2d">Объект 2д документа.</param>
        /// <param name="numberOfTeeth">Количество зубцов у расчески.</param>
        /// <param name="lengthOfTeeth">Длина зубца расчески.</param>
        /// <param name="widthOfTeeth">Ширина зубца расчески.</param>
        /// <param name="distanceBetweenTeeth">Расстояние между зубцами расчески.</param>
        /// <param name="xPosition">X координата, относительно которой мы строим расческу.</param>
        /// <param name="lengthOfBase">Длина основания расчески.</param>
        private void BuildTeeth(
            ksDocument2D document2d,
            int numberOfTeeth,
            double lengthOfTeeth,
            double widthOfTeeth,
            double distanceBetweenTeeth,
            double xPosition,
            double lengthOfBase)
        {
            var yOffset = distanceBetweenTeeth;

            document2d.ksPoint(
                xPosition - OuterWall,
                lengthOfBase - (2 * widthOfTeeth) - 2,
                default);

            for (int i = 0; i < numberOfTeeth; i++)
            {
                document2d.ksPoint(
                    xPosition - OuterWall,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset,
                    default);
                document2d.ksPoint(
                    xPosition - OuterWall - lengthOfTeeth + 1,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset,
                    default);
                document2d.ksPoint(
                    xPosition - OuterWall - lengthOfTeeth,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset - (widthOfTeeth / 3),
                    default);
                document2d.ksPoint(
                    xPosition - OuterWall - lengthOfTeeth,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset - (2 * (widthOfTeeth / 3)),
                    default);
                document2d.ksPoint(
                    xPosition - OuterWall - lengthOfTeeth + 1,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset - widthOfTeeth,
                    default);
                document2d.ksPoint(
                    xPosition - OuterWall,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset - widthOfTeeth,
                    default);
                yOffset -= -widthOfTeeth - distanceBetweenTeeth;
            }

            document2d.ksPoint(
                    xPosition - OuterWall,
                    0,
                    default);
        }

        /// <summary>
        /// Строит ручку расчески на основе заданных параметров.
        /// </summary>
        /// <param name="document2d">Объект 2д документа.</param>
        /// <param name="handleLength">Длина ручки расчески.</param>
        /// <param name="xPosition">X координата, относительно которой мы строим расческу.</param>
        /// <param name="lengthOfTeeth">Длина зубца расчески.</param>
        /// <param name="widthOfTeeth">Ширина зубца расчески.</param>
        private void BuildHandle(
            ksDocument2D document2d,
            double handleLength,
            double xPosition,
            double lengthOfTeeth,
            double widthOfTeeth,
            double handleWidth)
        {
            document2d.ksPoint(
                    xPosition - OuterWall,
                    0,
                    default);
            document2d.ksPoint(
                    xPosition - OuterWall - lengthOfTeeth + 1,
                    0,
                    default);
            document2d.ksPoint(
                    xPosition - OuterWall - lengthOfTeeth,
                    -widthOfTeeth / 3,
                    default);
            document2d.ksPoint(
                    xPosition - OuterWall - lengthOfTeeth,
                    -2 * (widthOfTeeth / 3),
                    default);
            document2d.ksPoint(
                    xPosition - OuterWall - lengthOfTeeth + 1,
                    -widthOfTeeth,
                    default);
            document2d.ksPoint(
                    xPosition - handleWidth,
                    -(3 * widthOfTeeth) + 2,
                    default);
            document2d.ksPoint(
                    xPosition - handleWidth,
                    -(3 * widthOfTeeth) - handleLength + 2,
                    default);
            document2d.ksPoint(
                    xPosition - handleWidth - (lengthOfTeeth / 2),
                    -(3 * widthOfTeeth) - handleLength - 23,
                    default);
            document2d.ksPoint(
                    xPosition - handleWidth - (lengthOfTeeth / 2),
                    -(3 * widthOfTeeth) - handleLength - 28,
                    default);
            document2d.ksPoint(
                    xPosition,
                    -(3 * widthOfTeeth) - handleLength - 28,
                    default);
            document2d.ksPoint(
                    xPosition,
                    0,
                    default);
        }
    }
}