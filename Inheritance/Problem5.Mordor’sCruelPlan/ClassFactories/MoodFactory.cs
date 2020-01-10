using System;
using System.Collections.Generic;
using System.Text;
using Problem5.Mordor_sCruelPlan.TypeOfMood;

namespace Problem5.Mordor_sCruelPlan.ClassFactories
{
    public static class MoodFactory
    {
        public static Mood GetMood(int points)
        {
            if (points < -5)
            {
                return new Angry();
            }
            else if (points >= -5 && points <= 0)
            {
                return new Sad();
            }
            else if (points >= 1 && points <= 15)
            {
                return new Happy();
            }
            else
            {
                return new JavaScript();
            }
        }
    }
}
