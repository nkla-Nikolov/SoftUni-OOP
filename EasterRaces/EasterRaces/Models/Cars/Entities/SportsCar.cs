﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private int horsePower;
        private const int minHorsePower = 250;
        private const int maxHorsePower = 450;

        public SportsCar(string model, int horsePower) : base(model, horsePower, 3000, minHorsePower, maxHorsePower)
        {
        }
    }
}
