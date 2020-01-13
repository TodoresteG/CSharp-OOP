using System;
using System.Collections.Generic;
using System.Text;

namespace Problem7.InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponRarity, string weaponType, string name);
    }
}
