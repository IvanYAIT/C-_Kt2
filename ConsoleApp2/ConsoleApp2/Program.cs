using System;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDictionary<int, string> testDictionary = new TestDictionary<int, string>();

            testDictionary.Add(1, "a");
            testDictionary.Add(2, "b");
            testDictionary.Add(3, "c");

            foreach (TestKeyValuePairs<int,string> item in testDictionary)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            Console.WriteLine(testDictionary.FindByKey(1).ToString());

            Console.WriteLine();
            testDictionary.RemoveByValue("a");

            foreach (TestKeyValuePairs<int, string> item in testDictionary)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            testDictionary.RemoveByKey(2);
            Console.WriteLine(testDictionary.FindByValue("b").ToString());

            Console.ReadLine();
        }
    }
}
