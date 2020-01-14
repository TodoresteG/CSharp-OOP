using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        IReadOnlyDictionary<string, List<IAnimal>> ProcedureHistory { get; }

        string History(string procedureName);

        void DoService(IAnimal animal, int procedureTime);
    }
}
