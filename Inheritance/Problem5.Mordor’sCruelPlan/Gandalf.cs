using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem5.Mordor_sCruelPlan
{
    public class Gandalf
    {
        private List<Food> eatenFood;

        public Gandalf()
        {
            this.eatenFood = new List<Food>();
        }

        public void AddFood(Food food)
        {
            this.eatenFood.Add(food);
        }

        public int Points
        {
            get
            {
                return this.eatenFood.Sum(x => x.Points);
            }
        }
    }
}
