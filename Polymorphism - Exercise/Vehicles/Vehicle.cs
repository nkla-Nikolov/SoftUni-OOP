using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public int TankCapacity { get; private set; }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }

        public virtual double FuelConsumptionPerKm { get; private set; }

        public string Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumptionPerKm) <= 0)
            {
                return $"{GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * FuelConsumptionPerKm;

            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                FuelQuantity += liters;
            }
        }

        public string DriveEmpty(double distance)
        {
            var neededFuel = (this.FuelConsumptionPerKm - 1.4) * distance;

            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
