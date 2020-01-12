using System;
using System.Collections.Generic;
using System.Text;

namespace Problem1.VehiclesAndProblem2.Extension.Contracts
{
    public interface IBus : IVehicle
    {
        string DriveEmpty(double distance);
    }
}
