using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters.Models;

namespace DungeonsAndCodeWizards.Entities.Items.Contracts
{
    public interface IItem
    {
        int Weight { get; }

        void AffectCharacter(Character character);
    }
}
