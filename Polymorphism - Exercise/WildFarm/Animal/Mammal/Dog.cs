using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override void Eat(Food.Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += 0.40 * food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
