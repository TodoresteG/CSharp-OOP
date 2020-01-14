using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Foods.FoodModels
{
    public class Dessert : Food
    {
        public const int InitialServingSize = 200;

        public Dessert(string name, decimal price) : base(name, InitialServingSize, price)
        {
        }
    }
}
