using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters.Models;

namespace DungeonsAndCodeWizards.Entities.Items.Models
{
    public class PoisonPotion : Item
    {
        private const int InitialWeight = 5;

        public PoisonPotion() : base(InitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            this.IsCharacterAlive(character);

            character.Health -= 20;
        }
    }
}
