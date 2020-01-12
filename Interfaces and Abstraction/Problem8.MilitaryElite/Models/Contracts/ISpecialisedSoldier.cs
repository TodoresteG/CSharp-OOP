namespace Problem8.MilitaryElite.Models.Contracts
{
    using Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }
    }
}
