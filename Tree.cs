using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTransactionDemo
{
    class SortedTree
    {
       
        static void Main(string[] args)
        {
            var t = new SortedTree().Sort();
            foreach (TestTreeSort item in t)
            {
                foreach (var i in item.SortedInitial)
                {
                    Console.WriteLine(i.Key.ToString() + " " + i.Value);
                }
            }
        }

        public List<TestTreeSort> Sort()
        {
            List<TestTreeSort> sorted = new List<TestTreeSort>();

            List<string> unsortedTree = new List<string>()
                {
                    "System",
                    "System.Collections",
                    "System.Math",
                    "System.Linq",
                    "System.Threading.Tasks",
                    "System.Test",
                    "System.Data.Oracle",
                    "System.Data.DataColumn",
                    "System.Data.DataException",
                    "System.Text.Unicode",
                    "Microsoft.Windows"
                };

            unsortedTree.Sort();

            List<List<string>> splitIntoSepNameSpacesTree = new List<List<string>>();
            foreach (var nameSpace in unsortedTree)
            {
                List<string> splitNames = new List<string>();
                splitNames.AddRange(nameSpace.Split("."));

                List<string> n = new List<string>();
                foreach (var name in splitNames)
                {
                    n.Add(name);
                }

                splitIntoSepNameSpacesTree.Add(n);

                var t = new TestTreeSort(splitIntoSepNameSpacesTree);

                sorted.Add(t);
            }

            return sorted;
        }
    }

    class TestTreeSort
    {
        public Dictionary<string, List<string>> SortedInitial { get; set; }

        public TestTreeSort(List<List<string>> rawItems)
        {
            Dictionary<string, List<string>> t = new Dictionary<string, List<string>>();
            foreach (List<string> item in rawItems)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    t = new Dictionary<string, List<string>>();
                    t.Add(item[0], item);
                }
            }

            SortedInitial = new Dictionary<string, List<string>>();
            SortedInitial = t;
        }
    }

}
