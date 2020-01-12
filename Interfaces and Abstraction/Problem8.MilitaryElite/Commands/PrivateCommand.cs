namespace Problem8.MilitaryElite.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Models.Contracts;

    public class PrivateCommand : ICommand
    {
        public PrivateCommand(ICollection<ISoldier> soldiers)
        {
            this.Soldiers = soldiers;
        }

        public ICollection<ISoldier> Soldiers { get; }

        public void Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            string firtsName = args[1];
            string lastName = args[2];
            decimal salary = decimal.Parse(args[3]);

            ISoldier soldier = new Private(id, firtsName, lastName, salary);

            this.Soldiers.Add(soldier);
        }
    }
}
