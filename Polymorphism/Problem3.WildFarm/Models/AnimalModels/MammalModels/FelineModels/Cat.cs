using System;
using System.Collections.Generic;
using System.Text;
using Problem3.WildFarm.Models.FoodModels;

namespace Problem3.WildFarm.Models.AnimalModels.MammalModels.FelineModels
{
    public class Cat : Feline
    {
        private const double WeightPerFood = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
            {
                this.Weight += WeightPerFood * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
