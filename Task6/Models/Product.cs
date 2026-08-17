using System;

namespace Task6.Models

{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get;  set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
