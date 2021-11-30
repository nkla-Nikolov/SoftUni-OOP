using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers.Contracts
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;


        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }


        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }

                username = value;
            }
        }

        public string RacingBehavior
        {
            get => racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }

                racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => drivingExperience;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }

                drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }

                car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable > 0)
            {
                return true;
            }

            return false;
        }

        public void Race()
        {
            if (this.GetType().Name == "ProfessionalRacer")
            {
                this.DrivingExperience += 10;
            }
            else
            {
                this.DrivingExperience += 5;
            }
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"{GetType().Name}: {this.Username}");
        //    sb.AppendLine($"--Driving behavior: {this.RacingBehavior}");
        //    sb.AppendLine($"--Driving experience: {this.DrivingExperience}");
        //    sb.AppendLine($"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})");
        //    return sb.ToString().TrimEnd();
        //}
    }
}
