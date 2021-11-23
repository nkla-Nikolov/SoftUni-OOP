using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzainfo = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                Pizza pizza = new Pizza(pizzainfo[1], dough);

                string toppingInput = Console.ReadLine();

                while (toppingInput != "END")
                {
                    string[] toppingInfo = toppingInput.Split();
                    string toppingType = toppingInfo[1];
                    double weight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, weight);
                    pizza.Add(topping);

                    toppingInput = Console.ReadLine();
                }
                
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
