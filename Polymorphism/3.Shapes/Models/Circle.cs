using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public override double CalculatePerimeter()
        {
            return 2 * 3.14 * this.Radius;
        }

        public override double CalculateArea()
        {
            return 3.14 * Math.Pow(this.Radius, 2);
        }

        public override string Draw()
        {
            throw new NotImplementedException();
        }
    }
}
