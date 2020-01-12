using System;
using System.Collections.Generic;
using System.Text;
using Problem3.WildFarm.Models.FoodModels;

namespace Problem3.WildFarm.Factories
{
    public class FoodFactory
    {
        public Food GetFood(string type, int quantity)
        {
            switch (type)
            {
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                default:
                    throw new ArgumentException("Invalid input!");
            }
        }
    }
}
