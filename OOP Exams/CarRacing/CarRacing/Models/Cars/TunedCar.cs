using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double fuelAvailable = 65;
        private const double fuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, fuelAvailable, fuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            double horsePowerReduction = (this.HorsePower * 3) / 100;
            this.HorsePower = (int)Math.Round(this.HorsePower - horsePowerReduction);
            base.Drive();
        }
    }
}
