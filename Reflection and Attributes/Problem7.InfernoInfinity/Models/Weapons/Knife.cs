using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Contracts;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int InitialBaseMinDamage = 4;
        private const int InitialBaseMaxDamage = 6;
        private const int InitialSockets = 3;

        public Knife(string name, WeaponRarity rarity) 
            : base(name, rarity, InitialBaseMinDamage, InitialBaseMaxDamage, InitialSockets)
        {
        }
    }
}
