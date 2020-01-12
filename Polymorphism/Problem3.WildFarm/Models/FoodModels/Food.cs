using System;
using System.Collections.Generic;
using System.Text;
using Problem3.WildFarm.Contracts;

namespace Problem3.WildFarm.Models.FoodModels
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; protected set; }
    }
}
