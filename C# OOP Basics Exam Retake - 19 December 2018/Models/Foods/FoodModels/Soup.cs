using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.FoodModels
{
    public class Soup : Food
    {
        public const int InitialServingSize = 245;

        public Soup(string name, decimal price) : base(name, InitialServingSize, price)
        {
        }
    }
}
