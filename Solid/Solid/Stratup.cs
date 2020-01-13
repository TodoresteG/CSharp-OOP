using System;
using Solid.Appenders;
using Solid.Appenders.Contracts;
using Solid.Core;
using Solid.Layouts;
using Solid.Layouts.Contracts;
using Solid.Loggers;
using Solid.Loggers.Contracts;

namespace Solid
{
    public class Stratup
    {
        public static void Main(string[] args)
        {
            int countOfAppenders = int.Parse(Console.ReadLine());

            Engine engine = new Engine();
            engine.Run(countOfAppenders);
        }
    }
}
