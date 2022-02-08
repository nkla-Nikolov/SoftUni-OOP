using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double ACWithPeople = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            
        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + ACWithPeople;

    }
}
