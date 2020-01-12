namespace Problem8.MilitaryElite.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Models.Contracts;

    public class SpyCommand : ICommand
    {
        public SpyCommand(ICollection<ISoldier> soldiers)
        {
            this.Soldiers = soldiers;
        }

        public ICollection<ISoldier> Soldiers { get; }

        public void Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            string firstName = args[1];
            string lastName = args[2];
            int codeNumber = int.Parse(args[3]);

            ISpy spy = new Spy(id, firstName, lastName, codeNumber);

            this.Soldiers.Add(spy);
        }
    }
}
