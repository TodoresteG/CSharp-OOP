using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Models.Drinks.DrinkModels
{
    public class Alcohol : Drink
    {
        public const decimal AlcoholPrice = 3.50m;

        public Alcohol(string name, int servingSize, string brand) : base(name, servingSize, AlcoholPrice, brand)
        {
        }
    }
}
