using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveDemos.Intro1
{
    class Program
    {
        static void Main(string[] args)
        {
            var greeting = $"Hello {args[0]}";



















            const double SLICES_PER_PIZZA = 8.0;

            var desiredSlices = new[] { 0 };
            var developers = desiredSlices.Count();
            var totalDesiredSlices = desiredSlices.Sum();

            var pizzas = Math.Ceiling(totalDesiredSlices / SLICES_PER_PIZZA);

            var totalSlices = pizzas * SLICES_PER_PIZZA;
            var averageSlicesPerDev = totalSlices / developers;

            var result = $"Average {averageSlicesPerDev:f1} slices per dev";


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
