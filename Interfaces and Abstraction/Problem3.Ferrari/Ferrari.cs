using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3.Ferrari
{
    public class Ferrari : ICar
    {
        private string driverName;
        private string model = "488-Spider";

        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string DriverName
        {
            get => this.driverName;
            private set => this.driverName = value;
        }

        public string Model
        {
            get => this.model;
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public string UseBreaks()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.model}/{this.UseBreaks()}/{this.PushGasPedal()}/{this.DriverName}";
        }
    }
}
