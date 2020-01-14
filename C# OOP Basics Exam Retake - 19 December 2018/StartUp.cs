using System;
using SoftUniRestaurant.Core;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Foods.FoodModels;
using SoftUniRestaurant.Models.Tables.TableModels;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
