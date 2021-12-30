using System;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in phoneNumbers)
            {
                if (!number.All(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (number.Length == 7)
                {
                    ICallable stationary = new Stationaryphone();
                    stationary.Call(number);
                }
                else if (number.Length == 10)
                {
                    ICallable callable = new Smartphone();
                    callable.Call(number);
                }
            }


            foreach (var url in urls)
            {
                if (url.Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                
                IBrowsable browseble = new Smartphone();
                browseble.Browse(url);
            }

        }
    }
}
