namespace Problem8.MilitaryElite.Models
{
    using Contracts;
    using Enums;
    using System;

    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get => this.state;
            private set
            {
                //TODO Enum Parse
                if (value == "inProgress" || value == "Finished")
                {
                    this.state = value;
                }
                else
                {
                    throw new InvalidOperationException("Invalid mission state given!");
                }
            }
        }

        public string CompleteMission()
        {
            return "Mission Completed";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
