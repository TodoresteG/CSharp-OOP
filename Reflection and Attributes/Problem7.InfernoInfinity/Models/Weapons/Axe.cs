using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Contracts;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int InitialBaseMinDamage = 5;
        private const int InitialBaseMaxDamage = 10;
        private const int InitialSockets = 4;

        public Axe(string name, WeaponRarity rarity)
            : base(name, rarity, InitialBaseMinDamage, InitialBaseMaxDamage, InitialSockets)
        {
        }
    }
}
