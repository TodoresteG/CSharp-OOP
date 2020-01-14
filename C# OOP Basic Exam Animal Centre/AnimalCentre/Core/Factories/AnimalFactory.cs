using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AnimalCentre.CommonCotracts;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Core.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            //Type animalType = Assembly
            //    .GetExecutingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name == type);

            //if (animalType == null)
            //{
            //    throw new ArgumentException("Invalid type of animal");
            //}

            //IAnimal animalInstance = (IAnimal)Activator
            //    .CreateInstance(animalType, new object[] { name, energy, happiness, procedureTime });

            //return animalInstance;

            // BUT WHYYYYYY :(

            switch (type)
            {
                case "Cat":
                    return new Cat(name, energy, happiness, procedureTime);
                case "Dog":
                    return new Dog(name, energy, happiness, procedureTime);
                case "Lion":
                    return new Lion(name, energy, happiness, procedureTime);
                case "Pig":
                    return new Pig(name, energy, happiness, procedureTime);
                default:
                    throw new ArgumentException("Invalid type of animal");
            }
        }
    }
}
