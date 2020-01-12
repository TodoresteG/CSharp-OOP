namespace Problem8.MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
