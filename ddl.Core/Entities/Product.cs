using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Core.Entities
{
    public class Product
    {
        static int id = 1;
        public int Id { get; }
        public string Name { get; set; }
        public float Price { get; set; }
        
        public Product(string name, float price)
        {
            Id = id++;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Price}";
        }
    }
}
