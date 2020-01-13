using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int InitialStrength = 7;
        private const int InitialAgility = 2;
        private const int InitialVitality = 5;

        public Ruby(GemClarity clarity)
            : base(clarity, InitialStrength, InitialAgility, InitialVitality)
        {
        }
    }
}
