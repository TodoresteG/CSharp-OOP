using System;
using System.Collections.Generic;
using System.Text;
using Problem3.WildFarm.Contracts;

namespace Problem3.WildFarm.Models.AnimalModels.MammalModels.FelineModels
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }


        public string Breed { get; protected set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
