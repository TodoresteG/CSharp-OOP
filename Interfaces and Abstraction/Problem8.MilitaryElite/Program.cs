namespace Problem8.MilitaryElite
{
    using Models.Enums;
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using IO.Contracts;
    using IO;
    using Core.Contracts;
    using Core;

    public class Program
    {
        static void Main(string[] args)
        {
            ICollection<ISoldier> soldiers = new List<ISoldier>();
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IEngine engine = new Engine(reader, writer, soldiers);

            engine.Run();
        }
    }
}
