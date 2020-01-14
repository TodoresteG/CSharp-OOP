using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;

            //Default values
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get; private set; }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                IsValueGreaterThanZero(value, nameof(this.happiness));

                this.happiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                IsValueGreaterThanZero(value, nameof(this.energy));

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }

        public override string ToString()
        {
            return
                $"    Animal type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }

        private void IsValueGreaterThanZero(int value, string name)
        {
            if (value <= 0 || value > 100)
            {
                throw new ArgumentException($"Invalid {name}");
            }
        }
    }
}
