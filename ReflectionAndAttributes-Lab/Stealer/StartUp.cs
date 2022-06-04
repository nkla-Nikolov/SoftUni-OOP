using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var spy = new Spy();
            Console.WriteLine(spy.CollectGettersAndSetters("Stealer.Hacker"));
        }
    }
}
