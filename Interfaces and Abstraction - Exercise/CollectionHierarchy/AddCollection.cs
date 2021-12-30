using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAdd
    {
        private List<string> list;

        public AddCollection()
        {
            list = new List<string>();
        }
        public void Add(string word)
        {
            list.Add(word);
            Console.Write(list.Count - 1 + ' ');
        }
    }
}
