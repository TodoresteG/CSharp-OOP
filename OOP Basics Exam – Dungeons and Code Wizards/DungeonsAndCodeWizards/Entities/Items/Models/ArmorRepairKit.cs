using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters.Models;

namespace DungeonsAndCodeWizards.Entities.Items.Models
{
    public class ArmorRepairKit : Item
    {
        private const int InitialWeight = 10;

        public ArmorRepairKit() : base(InitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            this.IsCharacterAlive(character);

            character.Armor = character.BaseArmor;
        }
    }
}
