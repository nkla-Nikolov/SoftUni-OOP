using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthable
    {
        public Pet(string name, string date)
        {
            this.Name = name;
            this.Birthdate = date;
        }
        public string Name { get; private set; }

        public string Birthdate { get; set; }
    }
}
