using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birth = Console.ReadLine();

            IIdentifiable identifible = new Citizen(name, age, id, birth);
            IBirthable ibirthable = new Citizen(name, age, id, birth);

            Console.WriteLine(identifible.Id);
            Console.WriteLine(ibirthable.Birthdate);

        }
    }
}
