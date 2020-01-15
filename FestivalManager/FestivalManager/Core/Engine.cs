
using System;
using System.Linq;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private readonly IFestivalController festivalCоntroller;
        private readonly ISetController setCоntroller;

        public Engine(IStage stage, IReader reader, IWriter writer)
        {
            this.festivalCоntroller = new FestivalController(stage);
            this.setCоntroller = new SetController(stage);

            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = this.reader.ReadLine();

            while (input != "END")
            {
                try
                {
                    string result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }

                input = this.reader.ReadLine();
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var command = tokens.First();
            var parameters = tokens.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var sets = this.setCоntroller.PerformSets();
                return sets;
            }

            var festivalControllerMethods = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string result = result = (string)festivalControllerMethods.Invoke(this.festivalCоntroller, new object[] { parameters });

            return result;
        }
    }
}