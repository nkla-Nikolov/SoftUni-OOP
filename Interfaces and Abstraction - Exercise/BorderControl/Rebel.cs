using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Group { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Food { get; set; } = 0;

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
