using System;

namespace af222ug_examination_2
{
    public abstract class Shape3D : Shape
    {
        protected Shape2D _baseShape;
        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _height = value;
            }
        }
        public double Length { get; set; }
        public double Width { get; set; }
        public virtual double MantelArea
        {
            get
            {
                return _baseShape.Perimeter * Height;
            }
        }
        public virtual double TotalSurfaceArea
        {
            get
            {
                return MantelArea + 2 * _baseShape.Area;
            }
        }
        public virtual double Volume
        {
            get
            {
                return _baseShape.Area * Height;
            }
        }
        protected Shape3D(ShapeType shapeType, Shape2D baseShape, double height) : base(shapeType)
        {
            _baseShape = baseShape;
            Height = height;
        }
        public override string ToString()
        {
            return ToString("G");
        }

        public override string ToString(string format)
        {
            double m = Math.Round(MantelArea, 1);
            double t = Math.Round(TotalSurfaceArea, 1);
            double v = Math.Round(Volume, 1);
            switch (format)
            {
                case null:
                case "":
                case "G":
                    return $"{ShapeType}\n Längd: {Length}\n Bredd: {Width}\n Höjd: {Height}\n Mantelarea: {m}\n Begränsningsarea: {t}\n Volym: {v}";
                case "R":
                    return $"{ShapeType} {Length} {Width} {Height} {m} {t} {v}";
                default:
                    throw new FormatException();

            }
        }
    }
}