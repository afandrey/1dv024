using System;

namespace af222ug_examination_2
{
    public abstract class Shape
    {
        public bool Is3D 
        { 
            get
            {
                if (ShapeType == ShapeType.Cuboid || ShapeType == ShapeType.Cylinder || ShapeType == ShapeType.Sphere)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }
        public ShapeType ShapeType { get; private set; }
        protected Shape(ShapeType shapeType)
        {
            ShapeType = shapeType;
        }

        public abstract string ToString(string format);
    }
}