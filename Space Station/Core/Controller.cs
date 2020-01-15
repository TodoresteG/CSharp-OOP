namespace SpaceStation.Core
{
    using Contracts;
    using SpaceStation.Factories;
    using SpaceStation.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SpaceStation.Models.Mission;
    using System.Text;

    public class Controller : IController
    {
        private IAstronautFactory astronautFactory;
        private IPlanetFactory planetFactory;

        private IRepository<IAstronaut> astronautRepository;
        private IRepository<IPlanet> planetRepository;

        private IMission mission;

        private int exploredPlanets = 0;

        public Controller()
        {
            this.astronautFactory = new AstronautFactory();
            this.planetFactory = new PlanetFactory();

            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();

            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = this.astronautFactory.CreateAstronaut(type, astronautName);

            this.astronautRepository.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = this.planetFactory.CreatePlanet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planetRepository.FindByName(planetName);

            ICollection<IAstronaut> astronauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            this.mission.Explore(planet, astronauts);

            int deadAstronauts = astronauts.Where(a => a.Oxygen == 0).Count();

            this.exploredPlanets++;

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var astronauts = this.astronautRepository.Models;

            sb.AppendLine($"{this.exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astro in astronauts)
            {
                sb.AppendLine($"Name: {astro.Name}");
                sb.AppendLine($"Oxygen: {astro.Oxygen}");

                if (astro.Bag.Items.Count == 0)
                {
                    sb.AppendLine("Bag items: none");
                    continue;
                }

                sb.AppendLine($"Bag items: {string.Join(", ", astro.Bag.Items)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astronautRepository.Remove(astronaut);

            return $"Astronaut {astronautName} was retired!";
        }
    }
}
