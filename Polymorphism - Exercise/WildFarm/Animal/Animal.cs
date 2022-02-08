using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public double FoodEaten { get; protected set; }

        public abstract string ProduceSound();

        public abstract void Eat(Food.Food food);
    }
}
