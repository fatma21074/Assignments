using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public abstract class Shape
    {
        public abstract double Area();
        public void Describe()
        {
            Console.WriteLine($"This is a {this.GetType().Name} with area: {Area()}");
        }
    }
}
