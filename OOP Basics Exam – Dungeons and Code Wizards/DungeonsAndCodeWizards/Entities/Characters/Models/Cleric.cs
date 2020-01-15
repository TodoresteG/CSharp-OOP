using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Bags.Models;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Characters.Enums;

namespace DungeonsAndCodeWizards.Entities.Characters.Models
{
    public class Cleric : Character, IHealable
    {
        private const double InitialBaseHealth = 50;
        private const double InitialBaseArmor = 25;
        private const double InitialAbilityPoints = 40;

        public Cleric(string name, Faction faction)
            : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Backpack(), faction)
        {
            this.RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
           this.IsBothCharactersAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
