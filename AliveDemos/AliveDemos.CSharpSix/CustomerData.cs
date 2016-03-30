using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveDemos.CSharpSix
{
    public class CustomerData
    {
        public string Name { get; set; }
        public string CreditCard { get; set; }

        public override string ToString()
        {
            return Name ?? "<no name>";
        }
    }
}
