using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double consumptionAC = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {

        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + consumptionAC;
    }
}
