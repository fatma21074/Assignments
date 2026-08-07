using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interface;

namespace Task2
{
    public class Circle : Shape, IDrawable ,IResizable
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
        public void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius: {Radius}");
            Console.WriteLine(" *** ");
            Console.WriteLine("*   *");
            Console.WriteLine(" *** ");
        }
        public void Scale(double factor)
        {
            Radius *= factor;
        }
    }
}
 
