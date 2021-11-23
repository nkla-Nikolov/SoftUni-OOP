using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string contests = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> passwords = new Dictionary<string, string>();

            while (contests != "end of contests")
            {
                string[] info = contests.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = info[0];
                string pass = info[1];

                if (!passwords.ContainsKey(contest))
                {
                    passwords.Add(contest, pass);
                }

                contests = Console.ReadLine();
            }

            string input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] inputArgs = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = inputArgs[0];
                string pass = inputArgs[1];
                string user = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (passwords.ContainsKey(contest) && passwords[contest].Contains(pass))
                {
                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, new Dictionary<string, int>());
                        users[user].Add(contest, points);
                    }
                    else
                    {
                        if (users[user].ContainsKey(contest))
                        {
                            if (points > users[user][contest])
                            {
                                users[user][contest] = points;
                            }
                        }
                        else
                        {
                            users[user].Add(contest, points);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            int maxPoints = 0;
            string candidate = string.Empty;

            foreach (var student in users)
            {
                int sum = 0;
                foreach (var item in student.Value)
                {
                    sum += item.Value;
                }

                if (sum > maxPoints)
                {
                    maxPoints = sum;
                    candidate = student.Key;
                }
            }
            Console.WriteLine($"Best candidate is {candidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var scores in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {scores.Key} -> {scores.Value}");
                }
            }
        }
    }
}
