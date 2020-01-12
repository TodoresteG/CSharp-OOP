using System;
using System.Collections.Generic;
using System.Text;
using Problem9.CollectionHierarchy.Contracts;

namespace Problem9.CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IAddable, IMyList
    {
        private List<string> data;
        private List<int> indexes;
        private List<string> removed;

        public MyList()
        {
            this.data = new List<string>();
            this.indexes = new List<int>();
            this.removed = new List<string>();
        }

        public int Used => this.data.Count;

        public override void Add(string element)
        {
            this.data.Insert(0, element);
            this.indexes.Add(0);
        }

        public override string Remove()
        {
            string item = this.data[0];
            this.removed.Add(item);
            this.data.RemoveAt(0);

            return item;
        }

        public string GetRemoved()
        {
            return string.Join(" ", removed);
        }

        public override string ToString()
        {
            return string.Join(" ", this.indexes);
        }
    }
}
