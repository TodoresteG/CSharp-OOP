using System;
using System.Collections.Generic;
using System.Text;
using Problem9.CollectionHierarchy.Contracts;

namespace Problem9.CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection ,IAddable, IAddRemoveCollection
    {
        private List<string> data;
        private List<int> indexes;
        private List<string> removed;

        public AddRemoveCollection()
        {
            this.data = new List<string>();
            this.indexes = new List<int>();
            this.removed = new List<string>();
        }

        public override void Add(string element)
        {
            this.data.Insert(0, element);
            this.indexes.Add(0);
        }

        public virtual string Remove()
        {
            int lastIndex = this.data.Count - 1;
            string item = this.data[lastIndex];
            this.removed.Add(item);
            this.data.RemoveAt(lastIndex);

            return item;
        }

        public string GetRemoved()
        {
            return string.Join(" ", this.removed);
        }

        public override string ToString()
        {
            return string.Join(" ", this.indexes);
        }
    }
}
