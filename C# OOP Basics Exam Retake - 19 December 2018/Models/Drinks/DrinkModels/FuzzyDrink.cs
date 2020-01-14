using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.DrinkModels
{
    public class FuzzyDrink : Drink
    {
        public const decimal FuzzyDrinkPrice = 2.50m;

        public FuzzyDrink(string name, int servingSize, string brand) : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }
    }
}
