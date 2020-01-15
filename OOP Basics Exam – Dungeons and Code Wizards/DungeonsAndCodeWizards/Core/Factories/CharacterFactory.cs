using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Characters.Enums;
using DungeonsAndCodeWizards.Entities.Characters.Models;

namespace DungeonsAndCodeWizards.Core.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        public Character CreateCharacter(string name, string faction, string type)
        {
            if (Enum.TryParse<Faction>(faction, out Faction result) == false)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            string validType = type.ToLower();

            Type characterType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == validType);

            if (characterType == null)
            {
                throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            Character characterInstance = (Character)Activator.CreateInstance(characterType, new object[] {name, result});

            return characterInstance;
        }
    }
}
