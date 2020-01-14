using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;

            this.AttackPoints -= 40;
            this.DefensePoints += 30;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;

                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else if (this.DefenseMode == true)
            {
                this.DefenseMode = false;

                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string mode = this.DefenseMode ? "ON" : "OFF";

            return base.ToString() + "\n" +
                   $" *Defense: {mode}";
        }
    }
}
