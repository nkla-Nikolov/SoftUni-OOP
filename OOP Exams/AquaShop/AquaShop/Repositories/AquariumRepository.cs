using AquaShop.Models.Aquariums.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories.Contracts
{
    public class AquariumRepository : IRepository<IAquarium>
    {
        private readonly List<IAquarium> aquariums;

        public AquariumRepository()
        {
            aquariums = new List<IAquarium>();
        }

        public IReadOnlyCollection<IAquarium> Models => aquariums.AsReadOnly();

        public void Add(IAquarium model)
        {
            aquariums.Add(model);
        }

        public IAquarium FindByType(string type)
        {
           return aquariums.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IAquarium model) => aquariums.Remove(model);
    }
}
