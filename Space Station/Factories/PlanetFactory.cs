namespace SpaceStation.Factories
{
    using Contracts;
    using SpaceStation.Models.Planets;

    public class PlanetFactory : IPlanetFactory
    {
        public IPlanet CreatePlanet(string planetName)
        {
            return new Planet(planetName);
        }
    }
}
