using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interface;

namespace Task2
{
    public class Triangle: Shape, IDrawable
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
        public override double Area()
        {
            return 0.5 * Base * Height;
        }
        public void Draw()
        {
            Console.WriteLine($"Drawing a triangle with base: {Base} and height: {Height}");
        }
    }
}
