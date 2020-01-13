using System;
using Problem7.InfernoInfinity.Contracts;

namespace Problem7.InfernoInfinity.Core.Commands
{
    public class PrintCommand : Command
    {
        public PrintCommand(string[] data, IGemFactory gemFactory, IRepository repository, IWeaponFactory weaponFactory) 
            : base(data, gemFactory, repository, weaponFactory)
        {
        }

        public override void Execute()
        {
            string name = this.Data[0];

            Console.WriteLine(this.Repository.PrintWeapon(name));
        }
    }
}
