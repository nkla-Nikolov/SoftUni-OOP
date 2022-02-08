using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raid = new List<BaseHero>();

            while(raid.Count != n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Paladin")
                {
                    raid.Add(new Paladin(name));
                }
                else if (type == "Druid")
                {
                    raid.Add(new Druid(name));
                }
                else if (type == "Rogue")
                {
                    raid.Add(new Rogue(name));
                }
                else if (type == "Warrior")
                {
                    raid.Add(new Warrior(name));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in raid)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int maxDamage = raid.Sum(x => x.Power);
            Console.WriteLine(maxDamage >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
