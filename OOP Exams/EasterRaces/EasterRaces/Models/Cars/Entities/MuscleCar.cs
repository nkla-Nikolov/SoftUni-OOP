using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private int horsePower;
        private const int minHorsePower = 400;
        private const int maxHorsePower = 600;
        
        public MuscleCar(string model, int horsePower) : base(model, horsePower, 5000, minHorsePower, maxHorsePower)
        {
        }
    }
}
