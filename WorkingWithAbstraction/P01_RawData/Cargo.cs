using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {
        public Cargo(int weigth, string type)
        {
            this.Weight = weigth;
            this.Type = type;
        }

        public int Weight { get; set; }

        public string Type { get; set; }
    }
}
