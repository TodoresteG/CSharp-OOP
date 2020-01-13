using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Contracts
{
    public interface IRareWeapon
    {
        WeaponRarity Rarity { get; }
    }
}
