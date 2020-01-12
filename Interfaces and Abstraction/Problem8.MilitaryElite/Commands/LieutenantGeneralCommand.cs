namespace Problem8.MilitaryElite.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;
    using Models.Contracts;

    public class LieutenantGeneralCommand : ICommand
    {
        public LieutenantGeneralCommand(ICollection<ISoldier> soldiers)
        {
            this.Soldiers = soldiers;
        }

        public ICollection<ISoldier> Soldiers { get; }

        public void Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            string firstName = args[1];
            string lastName = args[2];
            decimal salary = decimal.Parse(args[3]);

            ILieutenantGeneral soldier = new LieutenantGeneral(id, firstName, lastName, salary);

            string[] privatesInfo = args.Skip(4).ToArray();

            for (int i = 0; i < privatesInfo.Length; i++)
            {
                int privateId = int.Parse(privatesInfo[i]);

                ISoldier privateSoldier = this.Soldiers.FirstOrDefault(ps => ps.Id == privateId);

                soldier.AddPrivate((IPrivate)privateSoldier);
            }

            this.Soldiers.Add(soldier);
        }
    }
}
