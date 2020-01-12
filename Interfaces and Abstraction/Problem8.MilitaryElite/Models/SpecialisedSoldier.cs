namespace Problem8.MilitaryElite.Models
{
    using Contracts;
    using Enums;
    using System;

    public abstract class SpecialisedSoldier : Soldier, ISpecialisedSoldier
    {
        private string corps;

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Corps = corps;
        }

        public string Corps
        {
            //TODO 200% FAIL

            get => this.corps;
            private set
            {
                //TODO Enum parse
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
                else
                {
                    throw new ArgumentException("Invalid corps given");
                }
            }
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}" + "\n" +
                $"Corps: {this.Corps}";
        }
    }
}
