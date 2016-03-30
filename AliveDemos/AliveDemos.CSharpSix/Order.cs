using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveDemos.CSharpSix
{
    public class Order
    {
        // Backing fields
        private readonly DateTime _datePlaced;
        private readonly CustomerData _customer;


        public List<Item> Items { get; set; }
        public CustomerData Customer { get { return _customer; } }
        public DateTime DatePlaced
        {
            get
            {
                return _datePlaced;
            }
        }

        public decimal Total
        {
            get
            {
                return Items.Sum(i => i.Price);
            }
        }

        public decimal Tax
        {
            get
            {
                return Math.Round(Items.Sum(i => i.Price * 0.13m), 2);
            }
        }

        public decimal GrandTotal
        {
            get
            {
                return Total + Tax;
            }
        }

        public Order(Item item, CustomerData customer, DateTime orderDate = default(DateTime))
        {
            if (item == null)
                throw new ArgumentNullException("item", "Order must have an item");
            if (customer == null)
                throw new ArgumentNullException("customer", "Order must have a customer");

            _customer = customer;
            if (orderDate != default(DateTime))
                _datePlaced = orderDate;
            else
                _datePlaced = DateTime.UtcNow;

            Items = new List<Item>()
            {
                item
            };
        }

        public override string ToString()
        {
            return String.Format("${0} order for {1}", Total, Customer.Name);
        }

        public JObject ToJson()
        {
            var result = new JObject();
            result["date"] = DatePlaced.ToString("yyyy-MM-dd");
            result["time"] = DatePlaced.ToString("HH:mm");
            result["customer"] = Customer.Name;
            result["total"] = Total;
            result["tax"] = Tax;
            return result;
        }
    }
}
