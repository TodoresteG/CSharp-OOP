using System;
using System.Collections.Generic;
using MortalEngines.Common;
using MortalEngines.Core.Factories;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Machines;

namespace MortalEngines.Core
{
    using Contracts;

    // maybe two dictionaries
    public class MachinesManager : IMachinesManager
    {
        private readonly Dictionary<string, IPilot> pilots;
        private readonly Dictionary<string, IMachine> machines;

        private readonly IPilotFactory pilotFactory;

        public MachinesManager()
        {
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();

            this.pilotFactory = new PilotFactory();
        }

        public string HirePilot(string name)
        {
            IPilot pilot = this.pilotFactory.CreatePilot(name);

            if (this.pilots.ContainsKey(name) == false)
            {
                this.pilots.Add(name, pilot);

                return $"Pilot {name} hired";
            }
            else
            {
                return $"Pilot {name} is hired already";
            }
        }

        public string PilotReport(string pilotReporting)
        {
            if (this.pilots.ContainsKey(pilotReporting))
            {
                IPilot pilot = this.pilots[pilotReporting];

                return pilot.Report();
            }

            return string.Empty; // not sure
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.ContainsKey(name) == false)
            {
                IMachine tank = new Tank(name, attackPoints, defensePoints);

                this.machines.Add(name, tank);

                return $"Tank {name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
            }
            else
            {
                return $"Machine {name} is manufactured already";
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.ContainsKey(name) == false)
            {
                IMachine fighter = new Fighter(name, attackPoints, defensePoints);

                this.machines.Add(name, fighter);

                return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
            }
            else
            {
                return $"Machine {name} is manufactured already";
            }
        }


        public string MachineReport(string machineName)
        {
            if (this.machines.ContainsKey(machineName))
            {
                IMachine machine = this.machines[machineName];

                return machine.ToString();
            }

            return string.Empty; // not sure
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (this.pilots.ContainsKey(selectedPilotName) == false)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (this.machines.ContainsKey(selectedMachineName) == false)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            //dont know what machine not occupied means
            //one more if statement

            IPilot pilot = this.pilots[selectedPilotName];
            IMachine machine = this.machines[selectedMachineName];

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (this.machines.ContainsKey(attackingMachineName) == false)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            if (this.machines.ContainsKey(defendingMachineName) == false)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            IMachine attackingMachine = this.machines[attackingMachineName];
            IMachine defendingMachine = this.machines[defendingMachineName];

            if (attackingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachine} cannot attack or be attacked";
            }

            attackingMachine.Attack(defendingMachine);

            return $"Machine {defendingMachine.Name} was attacked by machine {attackingMachine.Name} - current health: {defendingMachine.HealthPoints:F2}";
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.machines.ContainsKey(fighterName))
            {
                IMachine machine = this.machines[fighterName];

                IFighter fighter = machine as IFighter;

                fighter.ToggleAggressiveMode();

                return $"Fighter {fighterName} toggled aggressive mode";
            }

            return $"Machine {fighterName} could not be found";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.machines.ContainsKey(tankName))
            {
                IMachine machine = this.machines[tankName];

                ITank tank = machine as ITank;

                tank.ToggleDefenseMode();

                return $"Tank {tankName} toggled defense mode";
            }

            return $"Machine {tankName} could not be found";
        }
    }
}