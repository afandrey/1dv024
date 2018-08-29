using System;

namespace af222ug_examination_2
{
    public abstract class Shape2D : Shape
    {
        private double _length;
        private double _width;
        public abstract double Area { get; }
        public double Length
        {
            get { return _length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _length = value;
            }
        }
        public abstract double Perimeter { get; }
        public double Width
        {
            get { return _width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _width = value;
            }
        }
        protected Shape2D(ShapeType shapeType, double length, double width) : base(shapeType)
        {
            Length = length;
            Width = width;
        }
        public override string ToString()
        {
            return ToString("G");
        }
        public override string ToString(string format)
        {
            double p = Math.Round(Perimeter, 1);
            double a = Math.Round(Area, 1);
            switch (format)
            {
                case null:
                case "":
                case "G":
                    return $"{ShapeType}\n Längd: {Length}\n Bredd: {Width}\n Omkrets: {p}\n Area: {a}";
                case "R":
                    return $"{ShapeType} {Length} {Width} {p} {a}";
                default:
                    throw new FormatException();
            }
        }
    }
}