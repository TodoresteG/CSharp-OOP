using System;
using System.Collections.Generic;
using System.Text;
using Problem3.WildFarm.Models.FoodModels;

namespace Problem3.WildFarm.Models.AnimalModels.BirdModels
{
    public class Hen : Bird
    {
        private const double WeightPerFood = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            this.Weight += WeightPerFood * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
