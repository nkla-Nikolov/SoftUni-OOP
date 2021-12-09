using System;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;


namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars = new CarRepository();
        private DriverRepository drivers = new DriverRepository();
        private RaceRepository races = new RaceRepository();

        public ChampionshipController()
        {

        }

        public string CreateDriver(string driverName)
        {
            if (drivers.Models.Any(x => x.Name == driverName))
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            
            drivers.Add(new Driver(driverName));

            return $"Driver {driverName} is created.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.Models.Any(x => x.Model == model))
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            if (type == "Muscle")
            {
                cars.Add(new MuscleCar(model, horsePower));
            }
            else if (type == "Sports")
            {
                cars.Add(new SportsCar(model, horsePower));
            }

            var car = cars.Models.Last();

            return $"{car.GetType().Name} {car.Model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (races.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            races.Add(new Race(name, laps));
            return $"Race {name} is created.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = races.GetByName(raceName);
            var driver = drivers.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driver.Name} added in {race.Name} race.";
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = drivers.GetByName(driverName);
            var car = cars.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);
            return $"Driver {driver.Name} received car {car.Model}.";
        }

        public string StartRace(string raceName)
        {
            var race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }


            var bestDrivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {bestDrivers[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {bestDrivers[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {bestDrivers[2].Name} is third in {race.Name} race.");
            
            return sb.ToString().TrimEnd();
        }
    }
}
