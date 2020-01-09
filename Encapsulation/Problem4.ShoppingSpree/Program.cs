using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] peopleArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                string[] productsArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                GetPeopleFromData(peopleArgs, people);
                GetProductsFromData(productsArgs, products);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] tokens = command.Split(' ');

                    string personName = tokens[0];
                    string productName = tokens[1];

                    Person person = people.FirstOrDefault(x => x.Name == personName);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    Console.WriteLine(person.Buy(person, product));

                    command = Console.ReadLine();
                }

                Print(people);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Print(List<Person> people)
        {
            foreach (var person in people)
            {
                if (person.Bag.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
            }
        }

        private static void GetProductsFromData(string[] productsArgs, List<Product> products)
        {
            for (int i = 0; i < productsArgs.Length; i++)
            {
                string[] current = productsArgs[i].Split('=');

                string name = current[0];
                int money = int.Parse(current[1]);

                Product product = new Product(name, money);

                products.Add(product);
            }
        }

        private static void GetPeopleFromData(string[] peopleArgs, List<Person> people)
        {
            for (int i = 0; i < peopleArgs.Length; i++)
            {
                string[] current = peopleArgs[i].Split('=');

                string name = current[0];
                int money = int.Parse(current[1]);

                Person person = new Person(name);
                person.Money = money;

                people.Add(person);
            }
        }
    }
}
