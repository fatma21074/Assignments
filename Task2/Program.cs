using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interface;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Circle circle = new Circle(5);
            //circle.Describe();
            //circle.Draw();
            //Console.WriteLine("-------------------------------");
            //Rectangle rectangle = new Rectangle(4, 6);
            //rectangle.Describe();
            //rectangle.Draw();


            Shape[] shapes = new Shape[3];
            shapes[0] = new Circle(5);
            shapes[1] = new Rectangle(4, 6);
            shapes[2] = new Triangle(4,5);
            foreach (Shape shape in shapes)
            {
                Console.Write("Description: ");
                shape.Describe();
                if (shape is IDrawable drawableShape)
                {
                    drawableShape.Draw();
                }
                else
                {
                    Console.WriteLine("This shape cannot be drawn.");
                }
                if (shape is IResizable resizableShape)
                {
                    Console.WriteLine("Scaling shape by a factor of 2.");
                    resizableShape.scale(2);
                    Console.Write("New description after scaling: ");
                    shape.Describe();
                }
                else
                {
                    Console.WriteLine("This shape cannot be resized.");
                }
                Console.WriteLine("-------------------------------");
            }
        }
    }
}
