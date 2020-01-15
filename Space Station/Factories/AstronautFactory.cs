namespace SpaceStation.Factories
{
    using Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using System;

    public class AstronautFactory : IAstronautFactory
    {
        public IAstronaut CreateAstronaut(string type, string astronautName)
        {
            switch (type)
            {
                case "Biologist":
                    return new Biologist(astronautName);
                case "Geodesist":
                    return new Geodesist(astronautName);
                case "Meteorologist":
                    return new Meteorologist(astronautName);
                default: throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
        }
    }
}
