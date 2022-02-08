using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food.Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += 0.10 * food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }


    }
}
