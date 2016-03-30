using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace AliveDemos.CSharpSixTarget
{
    public class Order
    {
        // Autoproperty - great when you have multiple constructors
        public List<Item> Items { get; set; } = new List<Item>();

        // You might be wondering why some properties use equals sign and some the lambda symbol.
        // Autoproperties - with equals - are set when class is initialized,
        // and they have no access to other fields or properties.
        // This won't work:
        //public string ItemCountX { get; } = Items.Count;

        // You can use expression bodied property, 
        // which is evaluated at runtime and has access to other fields and properties
        public int ItemCount => Items.Count;

        public CustomerData Customer { get; }
        // Getter only autoproperty - helps with immutability. Same effect as readonly backing field
        public DateTime DatePlaced { get; } = DateTime.UtcNow;
        public decimal Total => Items.Sum(i => i.Price);
        // using static
        public decimal Tax => Round(Items.Sum(i => i.Price * 0.13m), 2);
        public decimal GrandTotal => Total + Tax;


        public Order(Item item, CustomerData customer, DateTime orderDate = default(DateTime))
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Order must have an item");
            if (customer == null)
                throw new ArgumentNullException(nameof(customer), "Order must have a customer");

            Customer = customer;
            if (orderDate != default(DateTime))
                DatePlaced = orderDate;
            Items.Add(item);
        }

        // String interpolation
        // Expression bodied method
        public override string ToString() => $"${Total} order for {Customer.Name}";

        public JObject ToJson()
        {
            // Index initializers, great when working with JSON
            return new JObject()
            {
                ["date"] = DatePlaced.ToString("yyyy-MM-dd"),
                ["time"] = DatePlaced.ToString("HH:mm"),
                ["customer"] = Customer.Name,
                ["total"] = Total,
                ["tax"] = Tax,
            };
        }
    }
}
