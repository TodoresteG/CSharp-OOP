using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Core.Contracts;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Pilots;

namespace MortalEngines.Core.Factories
{
    public class PilotFactory : IPilotFactory
    {
        public IPilot CreatePilot(string name)
        {
            return new Pilot(name);
        }
    }
}
