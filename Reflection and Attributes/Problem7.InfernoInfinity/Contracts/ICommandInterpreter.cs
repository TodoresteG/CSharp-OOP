using System;
using System.Collections.Generic;
using System.Text;

namespace Problem7.InfernoInfinity.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string commandName, string[] data);
    }
}
