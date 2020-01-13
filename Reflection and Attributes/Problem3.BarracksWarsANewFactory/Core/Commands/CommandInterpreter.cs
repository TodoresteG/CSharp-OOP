using System;
using System.Reflection;
using _03BarracksFactory.Contracts;
using System.Linq;
using _03BarracksFactory.CustomAttribute;

namespace _03BarracksFactory.Core.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";

        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly
                .GetExecutingAssembly();

            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + Suffix);

            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            object[] fields = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType))
                .ToArray();

            object[] arguments = new object[] { data }.Concat(fields).ToArray();


            IExecutable command = (IExecutable) Activator
                .CreateInstance(commandType, arguments);

            return command;
        }
    }
}
