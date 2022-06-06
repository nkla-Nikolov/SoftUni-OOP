using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string firstName, int age)
        {
            this.FirstName = firstName;
            this.Age = age;
        }
        [MyRequired]
        public string FirstName { get; set; }
        [MyRange(1, 105)]
        public int Age { get; set; }
    }
}
