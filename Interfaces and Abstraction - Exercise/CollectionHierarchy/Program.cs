using System;

namespace CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                addCollection.Add(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                addRemoveCollection.Add(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                myList.Add(input[i]);
            }

            int countRemoveOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < countRemoveOperations; i++)
            {
                addRemoveCollection.Remove();
                myList.Remove();
            }

        }
    }
}
