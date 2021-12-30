using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    interface ICar
    {
        public string Color { get;}
        public string Model { get;}

        public string Start();
        public string Stop();
    }
}
