using System;

namespace Problem10.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson person = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());

                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(resident.GetName());


                input = Console.ReadLine();
            }
        }
    }
}
