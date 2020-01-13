using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Problem7.InfernoInfinity.Contracts;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Core.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponRarity, string weaponType, string name)
        {
            WeaponRarity rarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), weaponRarity);

            string weaponName = weaponType.ToLower();

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type classType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == weaponName);

            IWeapon instance = (IWeapon)Activator.CreateInstance(classType, new object[] { name, rarity });

            return instance;
        }
    }
}
