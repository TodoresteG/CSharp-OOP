using System;
using Operations.Core;
using Operations.Models;

namespace Operations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
