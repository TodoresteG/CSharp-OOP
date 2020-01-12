using System;
using System.Collections.Generic;
using System.Text;

namespace Operations.Contracts
{
    public interface IMathOperations
    {
        int Add(int first, int second);

        double Add(double first, double second, double third);

        decimal Add(decimal first, decimal second, decimal third);
    }
}
