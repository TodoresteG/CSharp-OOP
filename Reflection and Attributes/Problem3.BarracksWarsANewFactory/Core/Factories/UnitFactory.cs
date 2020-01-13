using System.Linq;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type classType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == unitType);

            return (IUnit)Activator.CreateInstance(classType);
        }
    }
}
