namespace Problem8.MilitaryElite.Commands.Contracts
{
    using Models.Contracts;
    using System.Collections.Generic;

    public interface ICommand
    {
        void Execute(string[] args);

        ICollection<ISoldier> Soldiers { get; }
    }
}
