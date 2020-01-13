using System;
using System.Collections.Generic;
using System.Text;

namespace Problem6.TrafficLights
{
    public class TrafficLight
    {
        private Light light;

        public TrafficLight(string light)
        {
            this.light = (Light)Enum.Parse(typeof(Light), light);
        }

        public void ChangeLight()
        {
            int previousLight = (int)this.light;
            this.light = (Light)((previousLight + 1) % Enum.GetNames(typeof(Light)).Length);
        }
    }
}
