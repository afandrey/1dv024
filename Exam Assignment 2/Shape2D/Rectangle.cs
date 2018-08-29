using System;

namespace af222ug_examination_2
{
    class Rectangle : Shape2D
    {
        public override double Area
        {
            get { return Length * Width; }
        }
        public override double Perimeter
        {
            get { return 2 * Length + 2 * Width; }
        }
        public Rectangle(double length, double width) : base(ShapeType.Rectangle, length, width)
        {
            Length = length;
            Width = width;
        }
    }
}