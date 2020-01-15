namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;
    using Astronauts.Contracts;
    using Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astro in astronauts)
            {
                if (!astro.CanBreath)
                {
                    continue;
                }

                foreach (var item in planet.Items.ToList())
                {
                    if (!astro.CanBreath)
                    {
                        break;
                    }

                    astro.Breath();
                    astro.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                }
            }
        }
    }
}
