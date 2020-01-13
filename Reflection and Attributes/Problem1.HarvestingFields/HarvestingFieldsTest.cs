using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Problem1.HarvestingFields
{
    class HarvestingFieldsTest
    {
        static void Main(string[] args)
        {
            var classType = typeof(HarvestingFields);

            var command = Console.ReadLine();

            while (command != "HARVEST")
            {
                IEnumerable<FieldInfo> fields = null;

                switch (command)
                {
                    case "private":
                        fields = GetPrivateFields(classType);
                        break;
                    case "protected":
                        fields = GetProtectedFields(classType);
                        break;
                    case "public":
                        fields = GetPublicFields(classType);
                        break;
                    case "all":
                        fields = GetAllFields(classType);
                        break;
                }

                foreach (var fieldInfo in fields)
                {
                    var accessModifier = fieldInfo.Attributes.ToString().ToLower();

                    if (fieldInfo.IsFamily)
                    {
                        accessModifier = "protected";
                    }

                    Console.WriteLine($"{accessModifier} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }

                command = Console.ReadLine();
            }
        }

        private static IEnumerable<FieldInfo> GetAllFields(Type classType)
        {
            return classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                                       BindingFlags.Public | BindingFlags.Static);
        }

        private static IEnumerable<FieldInfo> GetPublicFields(Type classType)
        {
            return classType.GetFields();
        }

        private static IEnumerable<FieldInfo> GetProtectedFields(Type classType)
        {
            return classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(t => t.IsFamily);
        }

        private static IEnumerable<FieldInfo> GetPrivateFields(Type classType)
        {
            return classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(t => t.IsPrivate);
        }
    }
}
