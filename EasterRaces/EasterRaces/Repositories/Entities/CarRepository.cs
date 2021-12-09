using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => models.AsReadOnly();

        public ICar GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Model == name);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.Models;
        }

        public void Add(ICar model)
        {
            models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
