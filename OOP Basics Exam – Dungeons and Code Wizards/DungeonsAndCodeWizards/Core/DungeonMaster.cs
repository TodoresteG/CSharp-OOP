using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Core.Factories;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Characters.Models;
using DungeonsAndCodeWizards.Entities.Items.Models;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private readonly List<Character> characterParty;
        private readonly Stack<Item> itemPool;

        private readonly ICharacterFactory characterFactory;
        private readonly IItemFactory itemFactory;

        private int lastSurvivorRound = 0;

        public DungeonMaster()
        {
            this.characterParty = new List<Character>();
            this.itemPool = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character = this.characterFactory.CreateCharacter(name, faction, characterType);

            this.characterParty.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);

            this.itemPool.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.FindCharacterInParty(characterName);

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = this.itemPool.Pop();

            character.Bag.AddItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.FindCharacterInParty(characterName);

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.FindCharacterInParty(giverName);

            Character receiver = this.FindCharacterInParty(receiverName);

            Item itemToGive = giver.Bag.GetItem(itemName);

            giver.UseItemOn(itemToGive, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.FindCharacterInParty(giverName);

            Character receiver = this.FindCharacterInParty(receiverName);

            Item itemToGive = giver.Bag.GetItem(itemName);

            receiver.Bag.AddItem(itemToGive);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string receiverName = args[1];

            Character attackerCharacter = this.FindCharacterInParty(attackerName);

            Character receiver = this.FindCharacterInParty(receiverName);

            if (!(attackerCharacter is IAttackable attacker))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            attacker.Attack(receiver);

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attackerCharacter.AbilityPoints} hit points!" +
                          $" {receiverName} has {receiver.Health}/{receiver.BaseHealth}" +
                          $" HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive == false)
            {
                sb.AppendLine($"{receiverName} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healerCharacter = this.FindCharacterInParty(healerName);

            Character receiver = this.FindCharacterInParty(healingReceiverName);

            if (!(healerCharacter is IHealable healer))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            healer.Heal(receiver);

            sb.AppendLine($"{healerCharacter.Name} heals {receiver.Name} for {healerCharacter.AbilityPoints}!" +
                          $" {receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().TrimEnd();
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            List<Character> aliveCharacters = this.characterParty
                .Where(x => x.IsAlive == true)
                .ToList();

            if (aliveCharacters.Count == 0 || aliveCharacters.Count == 1)
            {
                this.lastSurvivorRound++;
            }

            foreach (var character in aliveCharacters)
            {
                double healthBeforeRest = character.Health;

                character.Rest();

                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (this.lastSurvivorRound == 2)
            {
                return true;
            }

            return false;
        }

        private Character FindCharacterInParty(string characterName)
        {
            Character character = this.characterParty
                .FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
