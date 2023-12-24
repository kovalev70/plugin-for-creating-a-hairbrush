namespace Wrapper
{
    using Kompas6API5;
    using Model;

    /// <summary>
    /// ads.
    /// </summary>
    public class HairbrushBuilder
    {
        /// <summary>
        /// Расстояние между внешней стенкой и зубьями.
        /// </summary>
        private const double OUTERWALL = 10;

        /// <summary>
        /// Ширина ручки.
        /// </summary>
        private const double HANDLEWIDTH = OUTERWALL * 2;

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
            var lengthOfBase = (numberOfTeeth * (distanceBetweenTeeth + widthOfTeeth))
                + distanceBetweenTeeth + ((2 * widthOfTeeth) + 2);
            var xPosition = (lengthOfTeeth + OUTERWALL) / 2;

            var hairbrushScetch = _wrapper.CreateSketch();
            var document2d = (ksDocument2D)hairbrushScetch.BeginEdit();
            document2d.ksPolyline(1);

            BuildBody(
                document2d,
                xPosition,
                lengthOfTeeth,
                widthOfTeeth,
                lengthOfBase);

            BuildTeeths(
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
                widthOfTeeth);

            document2d.ksEndObj();
            hairbrushScetch.EndEdit();

            _wrapper.MakeExtrusion(5);
        }

        /// <summary>
        /// Строит внешнюю и верхнюю на основе заданных параметров.
        /// </summary>
        /// <param name="document2d">Объект 2д документа.</param>
        /// <param name="xPosition">X координата, относительно которой мы строим расческу.</param>
        /// <param name="lengthOfTeeth">Длина зубца расчески.</param>
        /// <param name="widthOfTeeth">Ширина зубца расчески.</param>
        /// <param name="lengthOfBase">Длина основания расчески.</param>
        public void BuildBody(
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
                xPosition - lengthOfTeeth - OUTERWALL + 1,
                lengthOfBase - widthOfTeeth - 1,
                default);
            document2d.ksPoint(
                xPosition - lengthOfTeeth - OUTERWALL,
                lengthOfBase - widthOfTeeth - 1 - (widthOfTeeth / 3),
                default);
            document2d.ksPoint(
                xPosition - lengthOfTeeth - OUTERWALL,
                lengthOfBase - widthOfTeeth - 2 - (2 * (widthOfTeeth / 3)),
                default);
            document2d.ksPoint(
                xPosition - lengthOfTeeth - OUTERWALL + 1,
                lengthOfBase - (2 * widthOfTeeth) - 2,
                default);
            document2d.ksPoint(
                xPosition - OUTERWALL,
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
        public void BuildTeeths(
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
                xPosition - OUTERWALL,
                lengthOfBase - (2 * widthOfTeeth) - 2,
                default);

            for (int i = 0; i < numberOfTeeth; i++)
            {
                document2d.ksPoint(
                    xPosition - OUTERWALL,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset,
                    default);
                document2d.ksPoint(
                    xPosition - OUTERWALL - lengthOfTeeth + 1,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset,
                    default);
                document2d.ksPoint(
                    xPosition - OUTERWALL - lengthOfTeeth,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset - (widthOfTeeth / 3),
                    default);
                document2d.ksPoint(
                    xPosition - OUTERWALL - lengthOfTeeth,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset - (2 * (widthOfTeeth / 3)),
                    default);
                document2d.ksPoint(
                    xPosition - OUTERWALL - lengthOfTeeth + 1,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset - widthOfTeeth,
                    default);
                document2d.ksPoint(
                    xPosition - OUTERWALL,
                    lengthOfBase - (2 * widthOfTeeth) - 2 - yOffset - widthOfTeeth,
                    default);
                yOffset -= -widthOfTeeth - distanceBetweenTeeth;
            }

            document2d.ksPoint(
                    xPosition - OUTERWALL,
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
        public void BuildHandle(
            ksDocument2D document2d,
            double handleLength,
            double xPosition,
            double lengthOfTeeth,
            double widthOfTeeth)
        {
            document2d.ksPoint(
                    xPosition - OUTERWALL,
                    0,
                    default);
            document2d.ksPoint(
                    xPosition - OUTERWALL - lengthOfTeeth + 1,
                    0,
                    default);
            document2d.ksPoint(
                    xPosition - OUTERWALL - lengthOfTeeth,
                    -widthOfTeeth / 3,
                    default);
            document2d.ksPoint(
                    xPosition - OUTERWALL - lengthOfTeeth,
                    -2 * (widthOfTeeth / 3),
                    default);
            document2d.ksPoint(
                    xPosition - OUTERWALL - lengthOfTeeth + 1,
                    -widthOfTeeth,
                    default);
            document2d.ksPoint(
                    xPosition - HANDLEWIDTH,
                    -(3 * widthOfTeeth) + 2,
                    default);
            document2d.ksPoint(
                    xPosition - HANDLEWIDTH,
                    -(3 * widthOfTeeth) - handleLength + 2,
                    default);
            document2d.ksPoint(
                    xPosition - HANDLEWIDTH - (lengthOfTeeth / 2),
                    -(3 * widthOfTeeth) - handleLength - 23,
                    default);
            document2d.ksPoint(
                    xPosition - HANDLEWIDTH - (lengthOfTeeth / 2),
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