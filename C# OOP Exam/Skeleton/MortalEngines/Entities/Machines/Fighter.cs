using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.AggressiveMode = true;

            this.AttackPoints += 50;
            this.DefensePoints -= 25;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;

                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string mode = this.AggressiveMode ? "ON" : "OFF";

            return base.ToString() + "\n" +
                   $" *Aggressive: {mode}";
        }
    }
}
