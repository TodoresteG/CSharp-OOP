using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Bags.Models;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Characters.Enums;
using DungeonsAndCodeWizards.Entities.Items.Models;

namespace DungeonsAndCodeWizards.Entities.Characters.Models
{
    public abstract class Character : ICharacter
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            //Default values
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;

            //Inicialization values
            this.Name = name;
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;

            //Current stats
            this.Health = this.BaseHealth;
            this.Armor = this.BaseArmor;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => this.health;
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else if (value < 0)
                {
                    this.IsAlive = false;
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => this.armor;
            set
            {
                if (value > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; private set; }

        public double RestHealMultiplier { get; protected set; }

        public void TakeDamage(double hitPoints)
        {
            this.IsCharacterAlive();

            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                double hitPointsLeft = Math.Abs(this.Armor -= hitPoints);
                this.Health -= hitPointsLeft;
            }
        }

        public void Rest()
        {
            this.IsCharacterAlive();

            double healthToAdd = this.BaseHealth * this.RestHealMultiplier;

            this.Health += healthToAdd;
        }

        public void UseItem(Item item)
        {
            this.IsCharacterAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.IsBothCharactersAlive(character);

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.IsBothCharactersAlive(character);

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.IsCharacterAlive();

            this.Bag.AddItem(item);
        }

        private void IsCharacterAlive()
        {
            if (this.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            string status = IsAlive ? "Alive" : "Dead";

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }

        protected void IsBothCharactersAlive(Character character)
        {
            if (this.IsAlive == false || character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
