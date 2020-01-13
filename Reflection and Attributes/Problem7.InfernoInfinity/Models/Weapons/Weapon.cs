using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem7.InfernoInfinity.Contracts;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Models.Weapons
{
    public abstract class Weapon : IWeapon, IRareWeapon
    {
        private readonly List<IGem> sockets;
        private readonly int minDamage;
        private readonly int maxDamage;

        protected Weapon(string name, WeaponRarity rarity, int baseMinDamage, int baseMaxDamage, int sockets)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.minDamage = baseMinDamage;
            this.maxDamage = baseMaxDamage;
            this.sockets = new List<IGem>(sockets);
        }

        public string Name { get; private set; }

        public int MinDamage
        {
            get
            {
                return this.minDamage * (int)this.Rarity + this.Sockets
                           .Where(x => x != null)
                           .Sum(x => (x.Strength * 2) + x.Agility);
            }
        }

        public int MaxDamage
        {
            get
            {
                return this.maxDamage * (int) this.Rarity + this.Sockets
                           .Where(x => x != null)
                           .Sum(x => (x.Strength * 3) + (x.Agility * 4));
            }
        }

        public List<IGem> Sockets => this.sockets;

        public WeaponRarity Rarity { get; private set; }

        public void AddGem(int index, IGem gem)
        {
            if (index >= 0 && index < this.Sockets.Count)
            {
                this.sockets.Add(gem);
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < this.Sockets.Count)
            {
                this.sockets.RemoveAt(index);
            }
        }

        public override string ToString()
        {
            int strength = this.Sockets
                .Sum(g => g.Strength);

            int agility = this.Sockets
                .Sum(g => g.Agility);

            int vitality = this.Sockets
                .Sum(g => g.Vitality);

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
        }
    }
}
