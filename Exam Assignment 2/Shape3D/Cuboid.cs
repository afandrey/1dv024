using System;

namespace af222ug_examination_2
{
    class Cuboid : Shape3D
    {
        public Cuboid(double length, double width, double height) : base(ShapeType.Cuboid, new Rectangle(length, width), height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
    }
}