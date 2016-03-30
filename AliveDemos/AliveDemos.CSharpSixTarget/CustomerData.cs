using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveDemos.CSharpSixTarget
{
    public class CustomerData
    {
        public string Name { get; set; }
        public string CreditCard { get; set; }

        public override string ToString() => Name ?? "<no name>";
    }
}
