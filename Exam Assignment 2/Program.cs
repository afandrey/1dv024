using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace af222ug_examination_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Start()
        {
            int numberOfShapes;
            bool is3d;
            List<string> shapes;

            is3d = MenuList();

            Console.WriteLine("Enter number of shapes:");
            numberOfShapes = Convert.ToInt32(Console.ReadLine());

            shapes = ListShapes(is3d, numberOfShapes);

            foreach (var s in shapes)
            {
                Console.WriteLine(s);
            }
        }
        public static bool MenuList()
        {
            while (true)
            {
                int menuOptions = MainMenu();

                switch (menuOptions)
                {
                    case (int)MenuOptions.TwoDim:
                        return false;
                    case (int)MenuOptions.ThreeDim:
                        return true;
                    default:
                        break;
                }
            }
        }
        private static int MainMenu()
        {
            int index;
            do
            {
                Console.WriteLine("1: Exit");
                Console.WriteLine("2: Random 2D Shapes");
                Console.WriteLine("3: Random 3D Shapes");

                if (int.TryParse(Console.ReadLine(), out index) && index >= 1 && index <= 3)
                {
                    return index;
                }
                else
                {
                    Console.WriteLine("Enter a number 1-3");
                }
            }
            while (true);
        }
        private static List<string> ListShapes(bool is3D, int numberOfShapes)
        {
            RandomNumbers rnd = new RandomNumbers();
            List<Shape2D> shapes2d = new List<Shape2D>();
            List<Shape3D> shapes3d = new List<Shape3D>();
            List<string> shapes = new List<string>();
            ShapeType shapeType;
            Shape2D shape2d;
            Shape3D shape3d;
            int min = 1;
            int max = 100;

            for (int i = 0; i < numberOfShapes; i++)
            {
                shapeType = (ShapeType)rnd.GetRandomShape(is3D);

                switch (shapeType)
                {
                    case ShapeType.Ellipse:
                        shape2d = new Ellipse(rnd.GetRandomNumber(min, max), rnd.GetRandomNumber(min, max));
                        shapes2d.Add(shape2d);
                        break;
                    case ShapeType.Rectangle:
                        shape2d = new Rectangle(rnd.GetRandomNumber(min, max), rnd.GetRandomNumber(min, max));
                        shapes2d.Add(shape2d);
                        break;
                    case ShapeType.Cuboid:
                        shape3d = new Cuboid(rnd.GetRandomNumber(min, max), rnd.GetRandomNumber(min, max), rnd.GetRandomNumber(min, max));
                        shapes3d.Add(shape3d);
                        break;
                    case ShapeType.Cylinder:
                        shape3d = new Cylinder(rnd.GetRandomNumber(min, max), rnd.GetRandomNumber(min, max), rnd.GetRandomNumber(min, max));
                        shapes3d.Add(shape3d);
                        break;
                    case ShapeType.Sphere:
                        shape3d = new Sphere(rnd.GetRandomNumber(min, max));
                        shapes3d.Add(shape3d);
                        break;
                }
            }

            if (is3D)
            {
                shapes3d = shapes3d.OrderBy(x => x.ShapeType)
                                    .ThenBy(x => x.Volume)
                                    .ToList();
                foreach (var s in shapes3d)
                {
                    shapes.Add(s.ToString("R"));
                }
            }
            else
            {
                shapes2d = shapes2d.OrderBy(x => x.ShapeType)
                                    .ThenBy(x => x.Area)
                                    .ToList();
                foreach (var s in shapes2d)
                {
                    shapes.Add(s.ToString("R"));
                }
            }
            return shapes;
        }
    }
}