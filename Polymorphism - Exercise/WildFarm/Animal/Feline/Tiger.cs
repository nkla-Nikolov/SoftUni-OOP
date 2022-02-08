using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string breed) : base(name, weight, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override void Eat(Food.Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.Weight += food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
