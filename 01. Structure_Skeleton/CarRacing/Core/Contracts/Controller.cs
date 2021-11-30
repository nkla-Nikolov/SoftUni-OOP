using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Repositories;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {
        CarRepository cars = new CarRepository();
        RacerRepository racers = new RacerRepository();
        private IMap map;

        public Controller()
        {

        }


        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {

            if (type == "SuperCar")
            {
                cars.Add(new SuperCar(make, model, VIN, horsePower));
            }
            else if (type == "TunedCar")
            {
                cars.Add(new TunedCar(make, model, VIN, horsePower));
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }

            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.Models.FirstOrDefault(x => x.VIN == carVIN);

            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            if (type == "ProfessionalRacer")
            {
                racers.Add(new ProfessionalRacer(username, car));
            }
            else if (type == "StreetRacer")
            {
                racers.Add(new StreetRacer(username, car));
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }

            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racers.Models.FirstOrDefault(x => x.Username == racerOneUsername);
            var racerTwo = racers.Models.FirstOrDefault(x => x.Username == racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            IMap map = new Map();
            return map.StartRace(racerOne, racerTwo);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var racer in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
