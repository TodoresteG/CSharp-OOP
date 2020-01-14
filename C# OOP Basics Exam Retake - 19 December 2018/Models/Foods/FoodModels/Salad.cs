using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.FoodModels
{
    public class Salad : Food
    {
        public const int InitialServingSize = 300;

        public Salad(string name, decimal price) : base(name, InitialServingSize, price)
        {
        }
    }
}
