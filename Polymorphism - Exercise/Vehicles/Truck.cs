using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double consumptionAC = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {

        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + consumptionAC;

        public override void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }

            base.Refuel(liters * 0.95);
        }
    }
}
