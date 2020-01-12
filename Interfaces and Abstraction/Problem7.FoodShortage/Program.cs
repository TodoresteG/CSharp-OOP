using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem7.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> people = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    people.Add(citizen);
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    Rebel rebel = new Rebel(name, age, group);

                    people.Add(rebel);
                }
            }

            string buyer = Console.ReadLine();

            while (buyer != "End")
            {
                var person = people.FirstOrDefault(x => x.Name == buyer);

                if (person != null)
                {
                    person.BuyFood();
                }

                buyer = Console.ReadLine();
            }

            int sum = people.Sum(x => x.Food);

            Console.WriteLine(sum);
        }
    }
}
