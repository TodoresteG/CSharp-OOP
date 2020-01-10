using System;
using Problem5.Mordor_sCruelPlan.ClassFactories;

namespace Problem5.Mordor_sCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] food = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Gandalf gandalf = new Gandalf();

            for (int i = 0; i < food.Length; i++)
            {
                string current = food[i].ToLower();

                var currentFood = FoodFactory.GetFood(current);

                gandalf.AddFood(currentFood);
            }

            int points = gandalf.Points;

            Mood mood = MoodFactory.GetMood(points);

            Console.WriteLine(points);
            Console.WriteLine(mood);
        }
    }
}
