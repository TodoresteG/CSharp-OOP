using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.DrinkModels
{
    public class Water : Drink
    {
        public const decimal WaterPrice = 1.50m;

        public Water(string name, int servingSize, string brand) : base(name, servingSize, WaterPrice, brand)
        {
        }
    }
}
