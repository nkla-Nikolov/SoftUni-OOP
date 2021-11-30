using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<Racer>
    {
        private List<Racer> models;

        public RacerRepository()
        {
            this.models = new List<Racer>();
        }

        public IReadOnlyCollection<Racer> Models => models.AsReadOnly();

        public void Add(Racer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }

            models.Add(model);
        }

        public Racer FindBy(string username)
        {
            return models.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(Racer model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
