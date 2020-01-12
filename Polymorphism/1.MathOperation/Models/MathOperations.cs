using System;
using System.Collections.Generic;
using System.Text;
using Operations.Contracts;

namespace Operations.Models
{
    public class MathOperations : IMathOperations
    {
        public int Add(int first, int second)
        {
            return first + second;
        }

        public double Add(double first, double second, double third)
        {
            return first + second + third;
        }

        public decimal Add(decimal first, decimal second, decimal third)
        {
            return first + second + third;
        }
    }
}
