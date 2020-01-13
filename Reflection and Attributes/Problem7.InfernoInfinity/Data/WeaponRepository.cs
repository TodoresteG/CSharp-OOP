using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem7.InfernoInfinity.Contracts;

namespace Problem7.InfernoInfinity.Data
{
    public class WeaponRepository : IRepository
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public void AddGem(string weaponName, int index, IGem gem)
        {
            IWeapon weapon = this.weapons
                .FirstOrDefault(x => x.Name == weaponName);

            IsWeaponValid(weapon);

            weapon.AddGem(index, gem);
        }

        public void RemoveGem(string weaponName, int index)
        {
            IWeapon weapon = this.weapons
                .FirstOrDefault(x => x.Name == weaponName);

            IsWeaponValid(weapon);

            weapon.RemoveGem(index);
        }

        public string PrintWeapon(string weaponName)
        {
            IWeapon weapon = this.weapons
                .FirstOrDefault(x => x.Name.ToLower() == weaponName.ToLower());

            IsWeaponValid(weapon);

            return weapon.ToString();
        }

        private void IsWeaponValid(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new ArgumentException("Not supported weapon");
            }
        }
    }
}
