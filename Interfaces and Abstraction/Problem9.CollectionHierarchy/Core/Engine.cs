using System;
using System.Collections.Generic;
using System.Text;
using Problem9.CollectionHierarchy.Models;

namespace Problem9.CollectionHierarchy.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var item in tokens)
            {
                addCollection.Add(item);
                addRemoveCollection.Add(item);
                myList.Add(item);
            }

            int itemsToRemove = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemsToRemove; i++)
            {
                addRemoveCollection.Remove();
                myList.Remove();
            }

            Console.WriteLine(addCollection);
            Console.WriteLine(addRemoveCollection);
            Console.WriteLine(myList);
            Console.WriteLine(addRemoveCollection.GetRemoved());
            Console.WriteLine(myList.GetRemoved());
        }
    }
}
