﻿using System;
using System.Collections.Generic;
using System.Text;
using Solid.Layouts.Contracts;

namespace Solid.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
