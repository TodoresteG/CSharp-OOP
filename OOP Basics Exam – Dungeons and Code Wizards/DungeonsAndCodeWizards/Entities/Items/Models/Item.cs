using System;
using DungeonsAndCodeWizards.Entities.Characters.Models;
using DungeonsAndCodeWizards.Entities.Items.Contracts;

namespace DungeonsAndCodeWizards.Entities.Items.Models
{
    public abstract class Item : IItem
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; private set; }

        public abstract void AffectCharacter(Character character);

        protected void IsCharacterAlive(Character character)
        {
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
