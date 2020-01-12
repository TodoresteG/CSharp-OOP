using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem6.BirthdayCelebrations.Contracts;
using Problem6.BirthdayCelebrations.Factories;
using Problem6.BirthdayCelebrations.Models;

namespace Problem6.BirthdayCelebrations.Core
{
    public class Engine
    {
        private List<IBirthable> birthables;
        private BirthdateFactory birthdateFactory;

        public Engine()
        {
            this.birthables = new List<IBirthable>();
            this.birthdateFactory = new BirthdateFactory();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(' ');

                string type = tokens[0];

                string[] parameters = tokens.Skip(1).ToArray();

                try
                {
                    var citizen = this.birthdateFactory.GetBirthable(type, parameters);

                    this.birthables.Add(citizen);
                }
                catch (Exception)
                {
                }

                input = Console.ReadLine();
            }

            int year = int.Parse(Console.ReadLine());

            var test = this.birthables.Where(x => x.Birthdate.Year == year).ToList();

            foreach (var item in test)
            {
                Console.WriteLine(item.Birthdate.ToString("dd/mm/yyyy"));
            }
        }
    }
}
