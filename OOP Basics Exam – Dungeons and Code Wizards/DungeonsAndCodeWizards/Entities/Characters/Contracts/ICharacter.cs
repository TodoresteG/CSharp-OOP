using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Bags.Models;
using DungeonsAndCodeWizards.Entities.Characters.Enums;
using DungeonsAndCodeWizards.Entities.Characters.Models;
using DungeonsAndCodeWizards.Entities.Items.Models;

namespace DungeonsAndCodeWizards.Entities.Characters.Contracts
{
    public interface ICharacter
    {
        string Name { get; }

        double BaseHealth { get; }

        double Health { get; set; }

        double BaseArmor { get; }

        double Armor { get; set; }

        double AbilityPoints { get; }

        Bag Bag { get; }

        Faction Faction { get; }

        bool IsAlive { get; }

        double RestHealMultiplier { get; }

        void TakeDamage(double hitPoints);

        void Rest();

        void UseItem(Item item);

        void UseItemOn(Item item, Character character);

        void GiveCharacterItem(Item item, Character character);

        void ReceiveItem(Item item);
    }
}
