﻿using System;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        public Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vin;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public string Make
        {
            get => make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }

                make = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }

                model = value;
            }
        }
            

        public string VIN
        {
            get => vin;
            private set
            {
                if (value.Length < 17 || value.Length > 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }

                vin = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }

                horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => fuelAvailable;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }

                fuelConsumptionPerRace = value;
            }
        }

        public void Drive()
        {
            if (this.GetType().Name == "TunedCar")
            {
                double horsePowerReduction = (this.HorsePower * 3) / 100;
                this.HorsePower = (int)Math.Floor(HorsePower - horsePowerReduction);
                this.FuelAvailable -= this.FuelConsumptionPerRace;
            }
            else
            {
                this.FuelAvailable -= this.FuelConsumptionPerRace;
            }
        }
    }
}
