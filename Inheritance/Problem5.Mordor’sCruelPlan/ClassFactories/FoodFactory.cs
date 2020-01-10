using System;
using System.Collections.Generic;
using System.Text;

namespace Problem5.Mordor_sCruelPlan
{
    public static class FoodFactory
    {
        public static Food GetFood(string type)
        {
            switch (type)
            {
                case "cram":
                    return new Cram();
                case "lembas":
                    return new Lembas();
                case "apple":
                    return new Apple();
                case "melon":
                    return new Melon();
                case "honeycake":
                    return new HoneyCake();
                case "mushrooms":
                    return new Mushroom();
                default:
                    return new EverythingElse();
            }
        }
    }
}
