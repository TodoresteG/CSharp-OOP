﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Problem9.CollectionHierarchy.Contracts
{
    public interface IMyList
    {
        string Remove();

        int Used { get; }
    }
}
