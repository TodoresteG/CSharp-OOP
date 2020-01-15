using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters.Enums;
using DungeonsAndCodeWizards.Entities.Characters.Models;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface ICharacterFactory
    {
        Character CreateCharacter(string name, string faction, string type);
    }
}
