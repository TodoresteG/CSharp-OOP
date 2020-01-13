using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Contracts;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int InitialBaseMinDamage = 3;
        private const int InitialBaseMaxDamage = 4;
        private const int InitialSockets = 2;

        public Sword(string name, WeaponRarity rarity)
            : base(name, rarity, InitialBaseMinDamage, InitialBaseMaxDamage, InitialSockets)
        {
        }
    }
}
