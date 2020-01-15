using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Bags.Models;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Characters.Enums;

namespace DungeonsAndCodeWizards.Entities.Characters.Models
{
    public class Warrior : Character, IAttackable
    {
        private const double InitialBaseHealth = 100;
        private const double InitialBaseArmor = 50;
        private const double InitialAbilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            this.IsBothCharactersAlive(character);

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                var faction = this.Faction.ToString();

                throw new ArgumentException($"Friendly fire! Both characters are from {faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
