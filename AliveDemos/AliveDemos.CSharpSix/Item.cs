using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveDemos.CSharpSix
{
    public class Item
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
