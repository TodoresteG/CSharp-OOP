using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MortalEngines.Core.Contracts;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private readonly IMachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Quit")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string[] args = tokens.Skip(1).ToArray();

                try
                {
                    string result = ParseCommand(command, args);

                    Console.WriteLine(result);
                }
                catch (ArgumentNullException nullEx)
                {
                    Console.WriteLine($"Error: {nullEx.Message}");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                input = Console.ReadLine();
            }
        }

        private string ParseCommand(string command, string[] args)
        {
            string result = string.Empty;

            string name = args[0];

            switch (command)
            {
                case "HirePilot":
                    result = this.machinesManager.HirePilot(name);
                    break;
                case "PilotReport":
                    result = this.machinesManager.PilotReport(name);
                    break;
                case "ManufactureTank":
                    double attackPoints = double.Parse(args[1]);
                    double defensePoints = double.Parse(args[2]);

                    result = this.machinesManager.ManufactureTank(name, attackPoints, defensePoints);
                    break;
                case "ManufactureFighter":
                    attackPoints = double.Parse(args[1]);
                    defensePoints = double.Parse(args[2]);

                    result = this.machinesManager.ManufactureFighter(name, attackPoints, defensePoints);
                    break;
                case "MachineReport":
                    result = this.machinesManager.MachineReport(name);
                    break;
                case "AggressiveMode":
                    result = this.machinesManager.ToggleFighterAggressiveMode(name);
                    break;
                case "DefenseMode":
                    result = this.machinesManager.ToggleTankDefenseMode(name);
                    break;
                case "Engage":
                    string target = args[1];

                    result = this.machinesManager.EngageMachine(name, target);
                    break;
                case "Attack":
                    target = args[1];

                    result = this.machinesManager.AttackMachines(name, target);
                    break;
            }

            return result;
        }
    }
}
