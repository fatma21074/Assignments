using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interface;

namespace Task2
{
    public class Rectangle: Shape,IDrawable,IResizable
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public override double Area()
        {
            return Width * Height;
        }
        public void Draw()
        {
            Console.WriteLine($"Drawing a rectangle with width: {Width} and height: {Height}");
            Console.WriteLine("******");
            Console.WriteLine("*    *");
            Console.WriteLine("*    *");
            Console.WriteLine("******");
        }
        public void Scale(double factor)
        {
            Width *= factor;
            Height *= factor;
        }
      
    }
}
