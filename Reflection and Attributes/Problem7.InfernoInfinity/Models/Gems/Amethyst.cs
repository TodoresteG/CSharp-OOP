using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int InitialStrength = 2;
        private const int InitialAgility = 8;
        private const int InitialVitality = 4;

        public Amethyst(GemClarity clarity)
            : base(clarity, InitialStrength, InitialAgility, InitialVitality)
        {
        }
    }
}
