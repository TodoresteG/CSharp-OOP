using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters.Models;

namespace DungeonsAndCodeWizards.Entities.Characters.Contracts
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
