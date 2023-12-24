namespace Wrapper
{
    using System;
    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// Обёртка для компаса.
    /// </summary>
    public class KompasWrapper
    {
        /// <summary>
        /// ID Компаса 3D в COM реестре.
        /// </summary>
        private const string KOMPASID = "KOMPAS.Application.5";

        /// <summary>
        /// Объект Компас 3D.
        /// </summary>
        private KompasObject? _kompasObject;

        /// <summary>
        /// 3D документ компаса.
        /// </summary>
        private ksDocument3D? _document3D;

        /// <summary>
        /// Часть документа.
        /// </summary>
        private ksPart? _part;

        /// <summary>
        /// Эскиз.
        /// </summary>
        private ksEntity? _sketch;

        /// <summary>
        /// Определение эскиза.
        /// </summary>
        private ksSketchDefinition? _sketchDefinition;

        /// <summary>
        /// Метод для подключения к КОМПАС-3D.
        /// </summary>
        /// <returns>Успешное подключение к КОМПАС-3D.</returns>
        public bool ConnectToCAD()
        {
            try
            {
                _kompasObject = Marshal.GetActiveObject(KOMPASID) as KompasObject;
            }
            catch
            {
                var compassType = Type.GetTypeFromProgID(KOMPASID);
                if (compassType != null)
                {
                    _kompasObject = Activator.CreateInstance(compassType) as KompasObject;
                }

                if (_kompasObject == null)
                {
                    throw new Exception("Не удалось подключиться к КОМПАС-3D");
                }

                _kompasObject.Visible = true;
            }

            return true;
        }

        /// <summary>
        /// Метод для создания 3D документа.
        /// </summary>
        public void CreateDocument3D()
        {
            _document3D = _kompasObject.Document3D();
            _document3D.Create();
            _part = _document3D.GetPart((int)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Метод для создания эскиза.
        /// </summary>
        /// <returns>Определение созданного эскиза.</returns>
        public ksSketchDefinition CreateSketch()
        {
            ksEntity plane = _part.GetDefaultEntity((int)Obj3dType.o3d_planeXOZ);
            _sketch = _part.NewEntity((int)Obj3dType.o3d_sketch);
            _sketchDefinition = _sketch.GetDefinition();
            _sketchDefinition.SetPlane(plane);
            _sketch.Create();
            return _sketchDefinition;
        }

        /// <summary>
        /// Создаёт выдавливание на заданном наброске.
        /// </summary>
        /// <param name="depth">Глубина выдавливания.</param>
        /// <param name="side">Направление выдавливания.</param>
        public void MakeExtrusion(
            double depth,
            bool side = true)
        {
            var extrusion = _part.NewEntity((short)Obj3dType.o3d_bossExtrusion) as ksEntity;
            var extrusionDefinition = extrusion?.GetDefinition() as ksBossExtrusionDefinition;
            if (extrusionDefinition != null)
            {
                extrusionDefinition.SetSideParam(side, (short)End_Type.etBlind, depth);
                extrusionDefinition.directionType =
                    side ? (short)Direction_Type.dtNormal : (short)Direction_Type.dtReverse;
                extrusionDefinition.SetSketch(_sketch);
            }

            extrusion?.Create();
        }
    }
}