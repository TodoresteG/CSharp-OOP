using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Problem7.InfernoInfinity.Contracts;
using Problem7.InfernoInfinity.Enums;

namespace Problem7.InfernoInfinity.Core.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string clarity, string gemType)
        {
            string gemName = gemType.ToLower();

            GemClarity gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), clarity);

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type classType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == gemName);

            IGem instance = (IGem)Activator.CreateInstance(classType, new object[] {gemClarity});

            return instance;
        }
    }
}
