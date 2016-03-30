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
















            var tenures = new[] { 12, 24, 18, 6, 3, 2, 9, 13 };
            var developers = tenures.Count();

            var averageTenure = tenures.Average();

            var result = $"Average tenure: {averageTenure:f0}";

            foreach (var developersTenure in tenures)
            {
                var delta = developersTenure - averageTenure;
                var longer = delta > 0 ? "longer" : "shorter";
                var info = $"{Math.Abs(delta):f0} months {longer}";
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
