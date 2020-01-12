namespace Problem8.MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class LieutenantGeneral : Soldier, ILieutenantGeneral
    {
        private List<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;

            this.privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates => this.privates.AsReadOnly();

        public decimal Salary { get; private set; }

        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine("Privates:");

            foreach (var soldier in this.Privates)
            {
                sb.AppendLine("  " + soldier.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
