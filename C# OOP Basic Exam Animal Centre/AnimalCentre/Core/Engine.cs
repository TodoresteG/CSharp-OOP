using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.CommonContracts;
using AnimalCentre.CommonCotracts;

namespace AnimalCentre.Core
{
    public class Engine : IRunnable
    {
        private readonly IAnimalCentre animalCentre;

        public Engine(IAnimalCentre animalCentre)
        {
            this.animalCentre = animalCentre;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            string type = tokens[1];
                            string name = tokens[2];
                            int energy = int.Parse(tokens[3]);
                            int happiness = int.Parse(tokens[4]);
                            int procedureTime = int.Parse(tokens[5]);

                            result = this.animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                            break;
                        case "Chip":
                            name = tokens[1];
                            procedureTime = int.Parse(tokens[2]);

                            result = this.animalCentre.Chip(name, procedureTime);
                            break;
                        case "Vaccinate":
                            name = tokens[1];
                            procedureTime = int.Parse(tokens[2]);

                            result = this.animalCentre.Vaccinate(name, procedureTime);
                            break;
                        case "Fitness":
                            name = tokens[1];
                            procedureTime = int.Parse(tokens[2]);

                            result = this.animalCentre.Fitness(name, procedureTime);
                            break;
                        case "Play":
                            name = tokens[1];
                            procedureTime = int.Parse(tokens[2]);

                            result = this.animalCentre.Play(name, procedureTime);
                            break;
                        case "DentalCare":
                            name = tokens[1];
                            procedureTime = int.Parse(tokens[2]);

                            result = this.animalCentre.DentalCare(name, procedureTime);
                            break;
                        case "NailTrim":
                            name = tokens[1];
                            procedureTime = int.Parse(tokens[2]);

                            result = this.animalCentre.NailTrim(name, procedureTime);
                            break;
                        case "Adopt":
                            string animalName = tokens[1];
                            string owner = tokens[2];

                            result = this.animalCentre.Adopt(animalName, owner);
                            break;
                        case "History":
                            string procedureType = tokens[1];

                            result = this.animalCentre.History(procedureType);
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"ArgumentException: {ae.Message}");
                }
                catch (InvalidOperationException ie)
                {
                    Console.WriteLine($"InvalidOperationException: {ie.Message}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(this.animalCentre.PrintAdoptedAnimals());
        }
    }
}
