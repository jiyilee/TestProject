using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharpConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InitTest();
            foreach (var item in GetTestListItem())
            {
                item.Name += item.Name;
                //testList.TestList.Add(new TestClass() { ID="inter" });
            } 
        }

        static void InitTest()
        {
            testList = new TestClassList()
            {
                ID = "id",
                Name = "name",
                TestList = new List<TestClass>() {
                 new TestClass{ ID="interID1", Name="interName1" },
                 new TestClass{ ID="interID2", Name="interName2" },
                 new TestClass{ ID="interID3", Name="interName3" }
                }
            };
        }

        static IEnumerable<TestClass> GetTestListItem()
        {
            return testList.TestList.Where(x => x.ID.StartsWith("inter"));
        }

        static TestClassList testList;
    }



    class TestClassList
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public List<TestClass> TestList { get; set; }
    }

    class TestClass
    {
        public string ID { get; set; }

        public string Name { get; set; }
    }
}
