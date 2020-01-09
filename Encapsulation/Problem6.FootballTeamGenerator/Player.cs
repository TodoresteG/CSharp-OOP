using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problem6.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        private int Endurance
        {
            get { return this.endurance; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Endurance)} should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        private int Sprint
        {
            get { return this.sprint; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Sprint)} should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        private int Dribble
        {
            get { return this.dribble; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Dribble)} should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        private int Passing
        {
            get { return this.passing; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Passing)} should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        private int Shooting
        {
            get { return this.shooting; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Shooting)} should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        public int Stats
        {
            get
            {
                return (int)Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
            }
        }
    }
}
