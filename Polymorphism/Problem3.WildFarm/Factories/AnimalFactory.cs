using System;
using System.Collections.Generic;
using System.Text;
using Problem3.WildFarm.Models.AnimalModels;
using Problem3.WildFarm.Models.AnimalModels.BirdModels;
using Problem3.WildFarm.Models.AnimalModels.MammalModels;
using Problem3.WildFarm.Models.AnimalModels.MammalModels.FelineModels;

namespace Problem3.WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal GetAnimal(string type, params string[] parameters)
        {
            string name = parameters[0];
            double weight = double.Parse(parameters[1]);

            switch (type)
            {
                case "Owl":
                    double wingSize = double.Parse(parameters[2]);
                    return new Owl(name, weight, wingSize);
                case "Hen":
                    wingSize = double.Parse(parameters[2]);
                    return new Hen(name, weight, wingSize);
                case "Cat":
                    string livingRegion = parameters[2];
                    string breed = parameters[3];
                    return new Cat(name, weight, livingRegion, breed);
                case "Tiger":
                    livingRegion = parameters[2];
                    breed = parameters[3];
                    return new Tiger(name, weight, livingRegion, breed);
                case "Mouse":
                    livingRegion = parameters[2];
                    return new Mouse(name, weight, livingRegion);
                case "Dog":
                    livingRegion = parameters[2];
                    return new Dog(name, weight, livingRegion);
                default:
                    throw new ArgumentException("Invalid input!");
            }
        }
    }
}
