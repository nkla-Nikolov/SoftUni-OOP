using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string technique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = technique;
            this.Weight = weight;
        }

        private Dictionary<string, double> doughInfo = new Dictionary<string, double>
        {
            {"wholegrain", 1 },
            {"white", 1.5 },
        };

        private Dictionary<string, double> bakingTechniqueInfo = new Dictionary<string, double>
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1 },
        };

        public string FlourType
        {
            get => flourType;
            private set
            {
                if (!doughInfo.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniqueInfo.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double Calories => 2 * this.Weight * doughInfo[this.FlourType.ToLower()] * bakingTechniqueInfo[this.bakingTechnique.ToLower()];
        
    }
}
