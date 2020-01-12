namespace Problem8.MilitaryElite.Models.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        string State { get; }

        string CompleteMission();
    }
}
