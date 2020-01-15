namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public bool Remove(IAstronaut model)
        {
            return this.models.Remove(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut = this.models
                                    .FirstOrDefault(a => a.Name == name);

            if (astronaut == null)
            {
                return null;
            }

            return astronaut;
        }
    }
}
