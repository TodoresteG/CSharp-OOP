using System;
using System.Collections.Generic;
using System.Text;
using Problem7.InfernoInfinity.Contracts;

namespace Problem7.InfernoInfinity.Core.Commands
{
    public class EndCommand : Command
    {
        public EndCommand(string[] data, IGemFactory gemFactory, IRepository repository, IWeaponFactory weaponFactory) 
            : base(data, gemFactory, repository, weaponFactory)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
