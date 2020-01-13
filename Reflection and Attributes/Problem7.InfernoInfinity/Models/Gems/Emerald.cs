using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        private const int InitialStrength = 1;
        private const int InitialAgility = 4;
        private const int InitialVitality = 9;

        public Emerald(GemClarity clarity)
            : base(clarity, InitialStrength, InitialAgility, InitialVitality)
        {
        }
    }
}
