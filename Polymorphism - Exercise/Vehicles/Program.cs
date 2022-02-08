using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), int.Parse(carInfo[3]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "Drive" && commands[1] == "Car")
                {
                    Console.WriteLine(car.Drive(double.Parse(commands[2])));
                }
                else if (commands[0] == "Drive" && commands[1] == "Truck")
                {
                    Console.WriteLine(truck.Drive(double.Parse(commands[2])));
                }
                else if (commands[0] == "Drive" && commands[1] == "Bus")
                {
                    Console.WriteLine(bus.Drive(double.Parse(commands[2])));
                }
                else if (commands[0] == "DriveEmpty" && commands[1] == "Bus")
                {
                    Console.WriteLine(bus.DriveEmpty(double.Parse(commands[2])));
                }
                else if (commands[0] == "Refuel" && commands[1] == "Car")
                {
                    car.Refuel(double.Parse(commands[2]));
                }
                else if (commands[0] == "Refuel" && commands[1] == "Truck")
                {
                    truck.Refuel(double.Parse(commands[2]));
                }
                else if (commands[0] == "Refuel" && commands[1] == "Bus")
                {
                    bus.Refuel(double.Parse(commands[2]));
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
