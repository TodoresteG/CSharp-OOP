using System;
using System.Collections.Generic;
using System.Text;
using Problem6.Animals.Animals;
using Problem6.Animals.Factories;

namespace Problem6.Animals.Core
{
    public class Engine
    {
        private List<Animal> animals;
        private AnimalFactory animalFactory;

        public Engine()
        {
            this.animals = new List<Animal>();
            this.animalFactory = new AnimalFactory();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                try
                {
                    string type = input;
                    string[] animalArgs = Console.ReadLine().Split();

                    if (animalArgs.Length != 3)
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string name = animalArgs[0];
                    int age = int.Parse(animalArgs[1]);
                    string gender = animalArgs[2];

                    Animal animal = animalFactory.CreateAnimal(type, name, age, gender);
                    animals.Add(animal);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
