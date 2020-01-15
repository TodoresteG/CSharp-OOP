using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Characters.Models;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine : IRunnable
    {
        private readonly DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            bool isGameOver = false;

            while (true)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                string[] data = tokens.Skip(1).ToArray();

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            result = this.dungeonMaster.JoinParty(data);
                            break;
                        case "AddItemToPool":
                            result = this.dungeonMaster.AddItemToPool(data);
                            break;
                        case "PickUpItem":
                            result = this.dungeonMaster.PickUpItem(data);
                            break;
                        case "UseItem":
                            result = this.dungeonMaster.UseItem(data);
                            break;
                        case "UseItemOn":
                            result = this.dungeonMaster.UseItemOn(data);
                            break;
                        case "GiveCharacterItem":
                            result = this.dungeonMaster.GiveCharacterItem(data);
                            break;
                        case "GetStats":
                            result = this.dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            result = this.dungeonMaster.Attack(data);
                            break;
                        case "Heal":
                            result = this.dungeonMaster.Heal(data);
                            break;
                        case "EndTurn":
                            result = this.dungeonMaster.EndTurn(data);
                            isGameOver = this.dungeonMaster.IsGameOver();
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"Parameter Error: {ae.Message}");
                }
                catch (InvalidOperationException ie)
                {
                    Console.WriteLine($"Invalid Operation: {ie.Message}");
                }

                if (isGameOver)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(this.dungeonMaster.GetStats());
        }
    }
}
