using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem5.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> list = new List<IIdentifiable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    Robot robot = new Robot(model, id);

                    list.Add(robot);
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    Citizen citizen = new Citizen(name, age, id);

                    list.Add(citizen);
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            list.Where(c => c.Id.EndsWith(fakeId))
                .Select(c => c.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
