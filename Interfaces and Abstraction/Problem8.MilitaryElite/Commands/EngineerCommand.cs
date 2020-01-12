namespace Problem8.MilitaryElite.Commands
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;
    using Models;
    using System.Linq;
    using System;

    public class EngineerCommand : ICommand
    {
        public EngineerCommand(ICollection<ISoldier> soldiers)
        {
            this.Soldiers = soldiers;
        }

        public ICollection<ISoldier> Soldiers { get; }

        public void Execute(string[] args)
        {
            try
            {
                int id = int.Parse(args[0]);
                string firstName = args[1];
                string lastName = args[2];
                decimal salary = decimal.Parse(args[3]);
                string corps = args[4];

                IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                string[] repairInfo = args.Skip(5).ToArray();

                for (int i = 0; i < repairInfo.Length; i += 2)
                {
                    string part = repairInfo[i];
                    int hours = int.Parse(repairInfo[i + 1]);

                    IRepair repair = new Repair(part, hours);

                    engineer.AddRepair(repair);
                }

                this.Soldiers.Add(engineer);
            }
            catch (ArgumentException)
            {
            }
        }
    }
}
