using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverages
    {
        private const decimal coffeePrice = 3.50m;
        private const double milliliters = 50;
        public Coffee(string name, double caffeine)
            : base(name, coffeePrice, milliliters)
        {
            Caffeine = caffeine;
        }
        
        public double Caffeine { get; set; }
    }
}
