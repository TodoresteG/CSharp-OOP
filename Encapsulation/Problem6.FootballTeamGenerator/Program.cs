using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem6.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(';');

                try
                {
                    if (tokens[0] == "Team")
                    {
                        teams.Add(new Team(tokens[1]));
                    }
                    else if (tokens[0] == "Add")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }

                        var player = new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));

                        team.Add(player);
                    }
                    else if (tokens[0] == "Remove")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }

                        team.Remove(tokens[2]);
                    }
                    else if (tokens[0] == "Rating")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }

                        Console.WriteLine($"{team.Name} - {team.Overall}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
