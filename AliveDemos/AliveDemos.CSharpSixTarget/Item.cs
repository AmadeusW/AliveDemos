using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveDemos.CSharpSixTarget
{
    public class Item
    {
        public string Name { get; }
        public decimal Price { get; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString() => Name;
    }
}
