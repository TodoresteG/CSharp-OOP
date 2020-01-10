using System;
using System.Collections.Generic;
using System.Text;

namespace Problem5.Mordor_sCruelPlan
{
    public abstract class Mood
    {
        public abstract string Type { get; }

        public override string ToString()
        {
            return $"{this.Type}";
        }
    }
}
