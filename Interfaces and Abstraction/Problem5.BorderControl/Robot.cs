using System;
using System.Collections.Generic;
using System.Text;

namespace Problem5.BorderControl
{
    public class Robot : IIdentifiable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Id
        {
            get => this.id;
            private set => this.id = value;
        }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
