using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = commandArgs[0];
                string country = commandArgs[1];
                int age = int.Parse(commandArgs[2]);

                Citizen citizen = new Citizen(name, country, age);
                Console.WriteLine(citizen.GetName(name));
                Console.WriteLine($"{citizen.GetName()} {citizen.GetName(name)}");

                command = Console.ReadLine();
            }
        }
    }
}
