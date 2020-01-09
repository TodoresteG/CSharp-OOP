using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int speed = int.Parse(parameters[1]);
                int power = int.Parse(parameters[2]);

                Engine engine = new Engine(speed, power);

                int weight = int.Parse(parameters[3]);
                string type = parameters[4];

                Cargo cargo = new Cargo(weight, type);

                List<Tire> tires = new List<Tire>();

                for (int j = 5; j < parameters.Length; j += 2)
                {
                    double pressure = double.Parse(parameters[j]);
                    int age = int.Parse(parameters[j + 1]);

                    Tire tire = new Tire(pressure, age);

                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
