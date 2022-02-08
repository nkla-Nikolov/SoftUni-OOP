using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string breed) : base(name, weight, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(Food.Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += 0.30 * food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
