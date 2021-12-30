using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAdd, IRemove
    {
        private List<string> list;

        public AddRemoveCollection()
        {
            list = new List<string>();
        }


        public void Add(string word)
        {
            list.Insert(0, word);
            Console.Write(0 + ' ');
        }

        public void Remove()
        {
            string removed = list[list.Count - 1];
            list.Remove(list[list.Count - 1]);
            Console.Write(removed + ' ');
        }
    }
}
