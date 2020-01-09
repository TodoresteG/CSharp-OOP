using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problem6.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private int overall;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<Player> Players
        {
            get { return this.players.AsReadOnly(); }
        }

        public int Overall
        {
            get
            {
                return this.players.Count == 0 ? 0 : Convert.ToInt32((this.players.Average(p => p.Stats)));
            }
        }

        public void Add(Player player)
        {
            this.players.Add(player);
        }

        public void Remove(string name)
        {
            if (this.players.Any(x => x.Name == name) == false)
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            this.players.Remove(this.players.First(x => x.Name == name));
        }
    }
}
