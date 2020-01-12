using System;
using System.Collections.Generic;
using System.Text;
using Problem3.WildFarm.Models.FoodModels;

namespace Problem3.WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string AskForFood();

        void Eat(Food food);
    }
}
