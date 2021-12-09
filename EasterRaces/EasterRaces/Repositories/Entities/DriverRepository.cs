using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> models;

        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }

        public IReadOnlyCollection<IDriver> Models => models.AsReadOnly();

        public IDriver GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.Models;
        }

        public void Add(IDriver model)
        {
            models.Add(model);
        }

        public bool Remove(IDriver model)
        {
            return models.Remove(model);
        }
    }
}
