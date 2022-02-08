using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food.Food food)
        {
            this.FoodEaten = food.Quantity;
            this.Weight += 0.35 * food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        
    }
}
