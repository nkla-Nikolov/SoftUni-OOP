using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Dictionary<string, Rebel> rebels = new Dictionary<string, Rebel>();
            Dictionary<string, Citizen> citizens = new Dictionary<string, Citizen>();

            while (command != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs.Length == 3)
                {
                    Rebel rebel = new Rebel(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]);
                    rebels.Add(commandArgs[0], rebel);
                }
                else if (commandArgs.Length == 4)
                {
                    Citizen citizen = new Citizen(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2],
                        commandArgs[3]);
                    citizens.Add(commandArgs[0], citizen);
                }
                else if (commandArgs.Length == 1)
                {
                    string name = commandArgs[0];

                    if (citizens.ContainsKey(name))
                    {
                        citizens[name].BuyFood();
                    }
                    else if (rebels.ContainsKey(name))
                    {
                        rebels[name].BuyFood();
                    }
                }

                command = Console.ReadLine();
            }

            int totalFood = citizens.Sum(x => x.Value.Food)
                            + rebels.Sum(x => x.Value.Food);

            Console.WriteLine(totalFood);


            //string command = Console.ReadLine();                                                                     //
            //List<IBirthable> dates = new List<IBirthable>();                                                         //
            //
            //while (command != "End")                                                                                 //
            //{                                                                                                        //
            //    string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);                    //
            //
            //    if (commandArgs[0] == "Citizen")                                                                     //
            //    {                                                                                                    //
            //        Citizen citizen = new Citizen(commandArgs[1], int.Parse(commandArgs[2]), commandArgs[3],         //
            //            commandArgs[4]);                                                                             //
            //        dates.Add(citizen);                                                                              //
            //    }                                                                                                    //
            //    else if (commandArgs[0] == "Pet")                                                                    //
            //    {                                                                                                    //
            //        Pet pet = new Pet(commandArgs[1], commandArgs[2]);                                               //
            //        dates.Add(pet);                                                                                  //
            //    }                                                                                                    //
            //    else if (commandArgs[0] == "Robot")                                                                  //
            //    {                                                                                                    //
            //        Robot robot = new Robot(commandArgs[1], commandArgs[2]);                                 // 05. Birthday Celebration
            //    }                                                                                                    //
            //
            //
            //    command = Console.ReadLine();                                                                        //
            //}                                                                                                        //
            //
            //string endingYear = Console.ReadLine();                                                                  //
            //
            //foreach (var date in dates)                                                                              //
            //{                                                                                                        //
            //    if (date.Birthdate.EndsWith(endingYear))                                                             //
            //    {                                                                                                    //
            //        Console.WriteLine(date.Birthdate);                                                               //
            //    }                                                                                                    //
            //}


            //==============================================================================================
            //==============================================================================================

            //string command = Console.ReadLine();                                                                //
            //List<IIdentifiable> ids = new List<IIdentifiable>();                                                //
            //
            //while (command != "End")                                                                            //
            //{                                                                                                   //
            //    string[] commandArgds = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);              //
            //
            //    if (commandArgds.Length == 3)                                                                   //
            //    {                                                                                               //
            //        string name = commandArgds[0];                                                              //
            //        int age = int.Parse(commandArgds[1]);                                                       //
            //        string id = commandArgds[2];                                                                //
            //        Citizen citizen = new Citizen(name, age, id);                                               //
            //        ids.Add(citizen);                                                                           //
            //    }                                                                                               //
            //    else if (commandArgds.Length == 2)                                                              //
            //    {                                                                                               //   04. Border Control
            //        string model = commandArgds[0];                                                             //
            //        string id = commandArgds[1];                                                                //
            //        Robot robot = new Robot(model, id);                                                         //
            //        ids.Add(robot);                                                                             //
            //    }                                                                                               //
            //
            //    command = Console.ReadLine();                                                                   //
            //}                                                                                                   //
            //
            //string detainedLastNumbers = Console.ReadLine();                                                    //
            //
            //ids = ids.Where(x => x.Id.EndsWith(detainedLastNumbers)).ToList();                                  //
            //
            //foreach (var id in ids)                                                                             //
            //{                                                                                                   //
            //    Console.WriteLine(id.Id);                                                                       //
            //}                                                                                                   //
        }                                                                                                         //
    }
}
