using System;
using System.Collections.Generic;
using System.Text;
using Problem9.CollectionHierarchy.Contracts;

namespace Problem9.CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        private List<string> data;
        private List<int> indexes;

        public AddCollection()
        {
            this.data = new List<string>();
            this.indexes = new List<int>();
        }

        public virtual void Add(string element)
        {
            int lastIndex = this.data.Count;
            this.data.Add(element);
            this.indexes.Add(lastIndex);
        }

        public override string ToString()
        {
            return string.Join(" ", this.indexes);
        }
    }
}
