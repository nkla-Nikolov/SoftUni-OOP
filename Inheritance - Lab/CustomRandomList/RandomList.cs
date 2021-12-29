using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd;
        private List<string> list;

        public RandomList()
        {
            list = new List<string>();
        }
        public void Remove()
        {
            int index = rnd.Next(0, Count);
            list.RemoveAt(index);
        }

        public string RandomString()
        {
            int index = rnd.Next(0, Count);
            return list[index];
        }
    }
}
