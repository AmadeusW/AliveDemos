using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveDemos.Intro2
{
    class Program
    {
        static void Main(string[] args)
        {
            var greeting = $"Hello {args[0]}";
















            var tenures = new[] { .5, 2, 1, 1.5, 2, 1, 1 };
            var developers = tenures.Count();

            var averageTenure = tenures.Average();

            var result = $"Average tenure: {averageTenure:f1}";

            foreach (var developersTenure in tenures)
            {
                var delta = developersTenure - averageTenure;
                var deltaString = delta.ToString("f1");
            }
        }













        private void sample()
        {
            var zero = 0;
            var one = 1;
            try
            {
                var surprise = one / zero;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
