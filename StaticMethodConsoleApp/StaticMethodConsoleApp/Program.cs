using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMethodConsoleApp
{
    class Program
    {
        static Test test;
        static void Main(string[] args)
        {
            while (true)
            {
                User user = new User();
                user.Age = 5;
                Test1(ref user);
                Console.WriteLine(user.Age);
                Test1(user);
                Console.WriteLine(user.Age);
                Console.ReadLine();

                test = new Helper().GetTest;
                Console.WriteLine(test.GetTestString());
                Console.WriteLine(test.GetTestString());
                Console.WriteLine(test.GetTestString());
                if (Console.ReadLine() == "Y")
                    break;
            }
        }

        static void Test1(User user)
        {
            user.Age = 10;
            user = new User();
        }
        static void Test1(ref User user)
        {
            user.Age = 100;
            user = new User();
        }
    }
    class Helper
    {
        static Test test;
        public Test GetTest
        {
            get
            {
                if (test == null)
                {
                    test = new Test();
                }
                return test.GetTest;
            }
        }
    }

    class Test
    {
        delegate void DoEventTestHandler(ref Test test);
        Test test;

        public Test GetTest
        {
            get
            {
                if (test == null)
                {
                    test = new Test();
                }
                return test;
            }
        }

        string testString;
        event DoEventTestHandler EventTestErrorHandler;
        public Test()
        {
            EventTestErrorHandler += Test_EventTestHandler;
        }

        void Test_EventTestHandler(ref Test test)
        {
            if (test == null || string.IsNullOrWhiteSpace(test.testString))
            {
                test = new Test("Y");
            }
            else
            {
                test = new Test();
            }
            //test.testString = "N";
        }

        public Test(string testStr)
        {
            this.testString = testStr;
        }

        public string GetTestString()
        {
            EventTestErrorHandler(ref test);
            return "testString" + GetTest.testString;
        }
    }
}
