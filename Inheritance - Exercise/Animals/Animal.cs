using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }

        public int Age { get; set; }
        
        public string Gender { get; set; }
        
        public string Sound { get; set; }

        public string ProduceSound()
            => Sound;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}\r\n{Name} {Age} {Gender}\r\n{this.ProduceSound()}");

            return sb.ToString().TrimEnd();
        }
    }
}
