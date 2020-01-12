namespace Problem8.MilitaryElite.Core
{
    using Contracts;
    using IO.Contracts;
    using Commands.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private const string CommandSuffix = "Command";

        private readonly IReader reader;
        private readonly IWriter writer;

        private ICollection<ISoldier> soldiers;

        public Engine(IReader reader, IWriter writer, ICollection<ISoldier> soldiers)
        {
            this.reader = reader;
            this.writer = writer;
            this.soldiers = soldiers;
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                Type commandType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name == input[0] + CommandSuffix);

                ICommand command = (ICommand)Activator.CreateInstance(commandType, new[] { this.soldiers });

                string[] args = input.Skip(1).ToArray();

                command.Execute(args);
            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }
    }
}
