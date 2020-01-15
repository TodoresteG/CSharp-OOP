namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Planets;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            return this.models.Remove(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(p => p.Name == name);
        }
    }
}
