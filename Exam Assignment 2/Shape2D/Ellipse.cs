using System;

namespace af222ug_examination_2
{
    class Ellipse : Shape2D
    {
        public override double Area
        {
            get 
            { 
                double a = Length / 2;
                double b = Width / 2;
                return Math.PI * a * b; 
            }
        }
        public override double Perimeter
        {
            get 
            { 
                double a = Length / 2;
                double b = Width / 2;
                return Math.PI * Math.Sqrt(2 * Math.Pow(a, 2) + 2 * Math.Pow(b, 2)); 
            }
        }
        public Ellipse(double diameter) : this(diameter, diameter)
        {
        }
        public Ellipse(double hdiameter, double vdiameter) : base(ShapeType.Ellipse, hdiameter, vdiameter)
        {
            Length = hdiameter;
            Width = vdiameter;
        }
    }
}