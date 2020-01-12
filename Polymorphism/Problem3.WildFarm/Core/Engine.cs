using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem3.WildFarm.Factories;
using Problem3.WildFarm.Models.AnimalModels;
using Problem3.WildFarm.Models.FoodModels;

namespace Problem3.WildFarm.Core
{
    public class Engine
    {
        private readonly List<Animal> animals;
        private readonly AnimalFactory animalFactory;
        private FoodFactory foodFactory;

        private Animal animal;
        private Food food;

        public Engine()
        {
            this.animals = new List<Animal>();
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            int counter = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string type = tokens[0];

                    string[] parameters = tokens.Skip(1).ToArray();

                    if (counter % 2 == 0)
                    {
                        if (parameters.Length == 4)
                        {
                            this.animal = this.animalFactory.GetAnimal(type, parameters);
                        }
                        else if (parameters.Length == 3)
                        {
                            if (double.TryParse(parameters[2], out double wingSize))
                            {
                                this.animal = this.animalFactory.GetAnimal(type, parameters);
                            }
                            else
                            {
                                this.animal = this.animalFactory.GetAnimal(type, parameters);
                            }
                        }

                        this.animals.Add(animal);
                    }
                    else
                    {
                        int quantity = int.Parse(tokens[1]);

                        this.food = this.foodFactory.GetFood(type, quantity);


                        Console.WriteLine(animal.AskForFood());
                        animal.Eat(this.food);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                counter++;
                input = Console.ReadLine();
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
