using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Feline : Animal
    {
        protected Feline(string name, double weight, string breed) : base(name, weight)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {this.}, {FoodEaten}]";
        }
    }
}
