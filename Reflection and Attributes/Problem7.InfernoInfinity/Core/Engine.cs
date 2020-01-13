using System;
using System.Linq;
using Problem7.InfernoInfinity.Contracts;

namespace Problem7.InfernoInfinity.Core
{
    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string commandName = tokens[0];

                string[] data = tokens.Skip(1).ToArray();

                IExecutable command = this.commandInterpreter.InterpretCommand(commandName, data);

                command.Execute();

                input = Console.ReadLine();
            }
        }
    }
}
