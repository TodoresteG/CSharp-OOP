using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        List<IGem> Sockets { get; }

        void AddGem(int index, IGem gem);

        void RemoveGem(int index);
    }
}
