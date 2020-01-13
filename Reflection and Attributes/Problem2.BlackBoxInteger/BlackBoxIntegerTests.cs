using System;
using System.Reflection;

namespace Problem2.BlackBoxInteger
{
    class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            var classType = typeof(BlackBoxInteger);

            var constructor = classType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);

            var blackBox = (BlackBoxInteger)Activator.CreateInstance(classType, true);

            //var blackBox = constructor.Invoke(new object[0]);

            var innerValue = classType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split('_');

                var command = tokens[0];
                var value = int.Parse(tokens[1]);

                var method = classType.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Instance);
                method.Invoke(blackBox, new object[] { value });

                Console.WriteLine(innerValue.GetValue(blackBox));

                input = Console.ReadLine();
            }
        }
    }
}
