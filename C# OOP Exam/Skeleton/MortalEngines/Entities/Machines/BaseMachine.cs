﻿using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get => this.healthPoints;
            set
            {
                if (value < 0)
                {
                    this.healthPoints = 0;
                }
                else
                {
                    this.healthPoints = value;
                }
            }
        }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            // what happens when defference is smaller than zero??
            double difference = this.AttackPoints -= target.DefensePoints;

            target.HealthPoints -= difference;

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:f2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:f2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:f2}");

            if (this.Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }
            else
            {
                //not sure about comas
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
