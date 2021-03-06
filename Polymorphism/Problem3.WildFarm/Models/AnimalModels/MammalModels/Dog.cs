﻿using System;
using System.Collections.Generic;
using System.Text;
using Problem3.WildFarm.Models.FoodModels;

namespace Problem3.WildFarm.Models.AnimalModels.MammalModels
{
    public class Dog : Mammal
    {
        private const double WeightPerFood = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
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
