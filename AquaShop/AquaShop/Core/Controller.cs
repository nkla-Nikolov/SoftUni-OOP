using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations = new DecorationRepository();
        private IRepository<IAquarium> aquariums = new AquariumRepository();


        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decorations.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                decorations.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = aquariums.Models.First(x => x.Name == aquariumName);

            if (fishType == "FreshwaterFish")
            {
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
                else
                {
                    return $"Water not suitable.";
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                if (aquarium.GetType().Name == "SaltwaterAquarium")
                {
                    aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
                else
                {
                    return $"Water not suitable.";
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.Models.First(x => x.Name == aquariumName);

            decimal sum = aquarium.Fish.Sum(x => x.Price);
            sum += aquarium.Decorations.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {sum:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.Models.First(x => x.Name == aquariumName);
            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariums.Models.FirstOrDefault(x => x.Name == aquariumName);
            var decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums.Models)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
