using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.MotorCycle
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsepower, double fuel) : base(horsepower, fuel)
        {
            DefaultFuelConsumption = 8;
        }
    }
}
