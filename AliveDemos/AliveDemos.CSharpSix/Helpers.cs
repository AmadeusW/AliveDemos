using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveDemos.CSharpSix
{
    public class Helpers
    {
        public static string CreateEmail(Order order)
        {
            string name;
            if (order != null && order.Customer != null)
            {
                name = order.Customer.Name.Trim();
            }
            else
            {
                name = "Valued Customer";
            }
            return String.Format("Dear {0},", name);
        }
    }
}
