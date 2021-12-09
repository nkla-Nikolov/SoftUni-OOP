using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fishRepo;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            decorations = new List<IDecoration>();
            fishRepo = new List<IFish>();
        }
        
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public int Comfort
        {
            get
            {
                int sum = 0;
                foreach (var item in Decorations)
                {
                    sum += item.Comfort;
                }

                return sum;
            }
        }

        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();

        public ICollection<IFish> Fish => fishRepo.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (fishRepo.Count == capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            fishRepo.Add(fish);
        }

        public void Feed()
        {
            this.fishRepo.ForEach(x => x.Eat());
        }

        public string GetInfo()
        {   
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (fishRepo.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                List<string> fishNames = new List<string>();

                foreach (var fish in fishRepo)
                {
                    fishNames.Add(fish.Name);
                }

                sb.AppendLine($"Fish: {string.Join(", ", fishNames)}");
            }

            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => fishRepo.Remove(fish);
    }
}
