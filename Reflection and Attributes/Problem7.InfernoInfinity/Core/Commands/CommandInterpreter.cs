using System;
using System.Linq;
using System.Reflection;
using Problem7.InfernoInfinity.Contracts;

namespace Problem7.InfernoInfinity.Core.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";

        private IGemFactory gemFactory;
        private IRepository repository;
        private IWeaponFactory weaponFactory;

        public CommandInterpreter(IGemFactory gemFactory, IRepository repository, IWeaponFactory weaponFactory)
        {
            this.gemFactory = gemFactory;
            this.repository = repository;
            this.weaponFactory = weaponFactory;
        }

        public IExecutable InterpretCommand(string commandName, string[] data)
        {
            string commandTypeName = commandName.ToLower();

            Assembly assembly = Assembly
                .GetExecutingAssembly();

            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandTypeName + Suffix);

            IExecutable commandInstance = (IExecutable)Activator
                .CreateInstance(commandType, new object[] {data, this.gemFactory, this.repository, this.weaponFactory});

            return commandInstance;
        }
    }
}
