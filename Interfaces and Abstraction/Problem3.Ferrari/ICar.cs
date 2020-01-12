using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3.Ferrari
{
    public interface ICar
    {
        string DriverName { get; }

        string UseBreaks();

        string PushGasPedal();
    }
}
