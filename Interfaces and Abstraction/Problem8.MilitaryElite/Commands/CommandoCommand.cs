namespace Problem8.MilitaryElite.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Models.Contracts;
    using Models;
    using System.Linq;
    using System;

    public class CommandoCommand : ICommand
    {
        public CommandoCommand(ICollection<ISoldier> soldiers)
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
                decimal salaray = decimal.Parse(args[3]);
                string corps = args[4];

                ICommando commando = new Commando(id, firstName, lastName, salaray, corps);

                string[] missionInfo = args.Skip(5).ToArray();

                for (int i = 0; i < missionInfo.Length; i += 2)
                {
                    try
                    {
                        string name = missionInfo[i];
                        string state = missionInfo[i + 1];

                        IMission mission = new Mission(name, state);

                        commando.AddMission(mission);
                    }
                    catch (InvalidOperationException)
                    {
                    }
                }

                this.Soldiers.Add(commando);
            }
            catch (ArgumentException)
            {
            }
        }
    }
}
