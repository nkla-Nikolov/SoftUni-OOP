using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public override string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}\r\nMEEOW";
        }

        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {

        }
    }
}
