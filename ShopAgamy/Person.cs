using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAgamy
{
    // building person.
    class Person
    {
        private String _fullName;
        private int _age;
        private double _bodyTemp;

        public static Person cratePerson()
        {
            Console.WriteLine("Please enter your full name:");
            var fullName = Console.ReadLine();
            while (string.IsNullOrEmpty(fullName))
            {
                Console.WriteLine("Invalid input, please enter your full name");
                fullName = Console.ReadLine();
            }


            Console.WriteLine("Please enter your age:");
            var ageAsString = Console.ReadLine();
            int age;
            while (!int.TryParse(ageAsString, out age))
            {
                Console.WriteLine("Invalid input, please enter a number");
                ageAsString = Console.ReadLine();
            }
            age = int.Parse(ageAsString);

            Console.WriteLine("Please enter your body temperature:");
            var bodyTempAsString = Console.ReadLine();
            double bodyTemp;
            while (!double.TryParse(bodyTempAsString, out bodyTemp) || double.Parse(bodyTempAsString) < 35)
            {
                Console.WriteLine("Invalid input, please enter a bodyTemp");
                bodyTempAsString = Console.ReadLine();
            }

            Person person = new Person(fullName, age, bodyTemp);
            return person;


        }
        public Person(string fullName, int age, double bodyTemp)
        {
            FullName = fullName;
            Age = age;
            BodyTemp = bodyTemp;
        }
        public Person(Person p)
        {
            FullName = p.FullName;
            Age = p.Age;
            BodyTemp = p.BodyTemp;
        }

        public string FullName { get => _fullName; set => _fullName = value; }
        public double Age { get => _age; set => _age = (int)value; }
        public double BodyTemp { get => _bodyTemp; set => _bodyTemp = value; }
    }
}

