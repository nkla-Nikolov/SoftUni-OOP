using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] peopleInput = Console.ReadLine()
                    .Split(new char[] { ';', '=' });

                List<Person> people = new List<Person>();

                for (int i = 0; i < peopleInput.Length; i += 2)
                {
                    Person person = new Person(peopleInput[i], decimal.Parse(peopleInput[i + 1]));
                    people.Add(person);
                }

                List<string> productsInput = new List<string>(Console.ReadLine()
                    .Split(new char[] { ';', '=' }));

                List<Product> products = new List<Product>();

                for (int i = 0; i < productsInput.Count; i += 2)
                {
                    if (i + 1 >= productsInput.Count)
                    {
                        break;
                    }
                    string name = productsInput[i];
                    decimal price = decimal.Parse(productsInput[i + 1]);
                    Product product = new Product(name, price);
                    products.Add(product);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandArgs = command.Split();
                    string person = commandArgs[0];
                    string product = commandArgs[1];

                    var currentPerson = people.FirstOrDefault(x => x.Name == person);
                    var currentProduct = products.FirstOrDefault(x => x.Name == product);

                    currentPerson.Buy(currentProduct);

                    command = Console.ReadLine();
                }
                
                foreach (var person in people)
                {
                    if (person.Products.Count > 0)
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(x => x.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
