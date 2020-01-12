namespace Problem8.MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}
