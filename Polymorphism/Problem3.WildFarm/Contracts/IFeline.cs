﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3.WildFarm.Contracts
{
    public interface IFeline : IMammal
    {
        string Breed { get; }
    }
}