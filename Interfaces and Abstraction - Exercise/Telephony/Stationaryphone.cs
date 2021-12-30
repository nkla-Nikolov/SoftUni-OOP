using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Stationaryphone : ICallable
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
