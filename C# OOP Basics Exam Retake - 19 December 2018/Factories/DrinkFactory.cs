using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Drinks.DrinkModels;

namespace SoftUniRestaurant.Factories
{
    public class DrinkFactory
    {
        public IDrink GetDrink(string type, string name, int servingSize, string brand)
        {
            type = type.ToLower();

            switch (type)
            {
                case "alcohol":
                    return new Alcohol(name, servingSize, brand);
                case "fuzzydrink":
                    return new FuzzyDrink(name, servingSize, brand);
                case "juice":
                    return  new Juice(name, servingSize, brand);
                case "water":
                    return new Water(name, servingSize, brand);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
