using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    class MyList : IAdd, IRemove
    {
        private List<string> list;

        public MyList()
        {
            list = new List<string>();
        }


        public void Add(string word)
        {
            list.Insert(0, word);
            Console.WriteLine(0 + ' ');
        }

        public void Remove()
        {
            string removed = list[0];
            list.Remove(list[0]);
            Console.WriteLine(removed + ' ');
        }

        public int Count => list.Count;
    }
}
