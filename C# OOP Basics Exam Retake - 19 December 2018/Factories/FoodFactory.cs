using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Foods.FoodModels;

namespace SoftUniRestaurant.Factories
{
    public class FoodFactory
    {
        public IFood GetFood(string type, string name, decimal price)
        {
            type = type.ToLower();

            switch (type)
            {
                case "dessert":
                    return new Dessert(name, price);
                case "salad":
                    return new Salad(name, price);
                case "soup":
                    return  new Soup(name, price);
                case "maincourse":
                    return new MainCourse(name, price);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
