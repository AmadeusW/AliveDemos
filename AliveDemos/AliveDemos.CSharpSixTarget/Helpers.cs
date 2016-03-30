using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveDemos.CSharpSixTarget
{
    public class Helpers
    {
        public static string CreateEmail(Order order)
        {
            string name = order?.Customer?.Name?.Trim();
            return $"Dear {name ?? "Valued Customer"},";
        }
    }
}
