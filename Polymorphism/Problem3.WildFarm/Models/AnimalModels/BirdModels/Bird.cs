using System;
using System.Collections.Generic;
using System.Text;
using Problem3.WildFarm.Contracts;

namespace Problem3.WildFarm.Models.AnimalModels.BirdModels
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; protected set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
