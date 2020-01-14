using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private readonly Dictionary<string, List<IAnimal>> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new Dictionary<string, List<IAnimal>>();
        }

        public IReadOnlyDictionary<string, List<IAnimal>> ProcedureHistory
            => this.procedureHistory;

        public string History(string procedureName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this.ProcedureHistory.Where(x => x.Key == procedureName))
            {
                sb.AppendLine($"{kvp.Key}");

                foreach (var animal in kvp.Value)
                {
                    sb.AppendLine(animal.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        protected void AddAnimalToProcedureHistory(IAnimal animal)
        {
            string procedureName = this.GetType().Name;

            if (this.procedureHistory.ContainsKey(procedureName) == false)
            {
                this.procedureHistory[procedureName] = new List<IAnimal>();
            }

            this.procedureHistory[procedureName].Add(animal);
        }

        protected void CheckProcedureTime(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
        }
    }
}
