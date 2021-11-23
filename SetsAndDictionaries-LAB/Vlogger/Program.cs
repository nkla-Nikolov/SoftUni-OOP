using System;
using System.Collections.Generic;
using System.Linq;

namespace Vlogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (input != "Statistics")
            {
                string[] inputInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vlogger = inputInfo[0];

                if (inputInfo[1] == "joined" && (!vloggers.ContainsKey(vlogger)))
                {
                    vloggers.Add(vlogger, new Dictionary<string, HashSet<string>>());

                    vloggers[vlogger].Add("following", new HashSet<string>());
                    vloggers[vlogger].Add("followers", new HashSet<string>());
                }
                else if (inputInfo[1] == "followed")
                {
                    string follower = inputInfo[0];
                    string theFollowed = inputInfo[2];

                    if (vloggers.ContainsKey(follower) && vloggers.ContainsKey(theFollowed) && follower != theFollowed)
                    {
                        vloggers[follower]["following"].Add(theFollowed);
                        vloggers[theFollowed]["followers"].Add(follower);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            vloggers = vloggers.OrderByDescending(x => x.Value["followers"].Count()).ThenBy(x => x.Value["following"].Count()).ToDictionary(x => x.Key, v => v.Value);

            int counter = 1;
            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var item in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                counter++;
            }
        }
    }
}
