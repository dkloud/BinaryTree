using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.BinaryTree;
using StudentTests;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Study.TreeTesting.MenuCommands
{
    public static class Commands
    {
        static BinaryTree<StudentTest> binaryTree = new BinaryTree<StudentTest>();
        //static IEnumerable<StudentTest> collection;
        static List<StudentTest> stList = new List<StudentTest>();
        static int PageElements { get; set; } = 4;

        static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(BinaryTree<StudentTest>));

        public static void FillTestData()
        {
            stList.Add(new StudentTest("Bob", "state exam", 2, DateTime.Now));
            stList.Add(new StudentTest("Tom", "state exam", 3, DateTime.Now));
            stList.Add(new StudentTest("Sam", "state exam", 4, DateTime.Now));
            stList.Add(new StudentTest("Dick", "state exam", 3, DateTime.Now));
            stList.Add(new StudentTest("Jack", "state exam", 4, DateTime.Now));
            stList.Add(new StudentTest("Marley", "state exam", 2, DateTime.Now));
            stList.Add(new StudentTest("Flam", "state exam", 1, DateTime.Now));

            stList.Add(new StudentTest("Resley", "final exam", 3, DateTime.Now));
            stList.Add(new StudentTest("Clon", "final exam", 2, DateTime.Now));
            stList.Add(new StudentTest("Diurk", "final exam", 5, DateTime.Now));
            stList.Add(new StudentTest("Arthur", "final exam", 4, DateTime.Now));
            stList.Add(new StudentTest("Ilon", "final exam", 4, DateTime.Now));
            stList.Add(new StudentTest("Bukon", "final exam", 5, DateTime.Now));

            binaryTree = new BinaryTree<StudentTest>(stList);
        }

        public static void OutData()
        {
            binaryTree.OutConsole("Binary Tree Collection");
        }

        public static void OutDataLINQ()
        {
            var query = binaryTree.ToList();
            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void OutCollection(IEnumerable<StudentTest> collection)
        {
            Console.Clear();
            if (collection == null)
                return;
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }

        //public static void Clear()
        //{
        //    foreach (var item in binaryTree)
        //    {
        //        binaryTree.Remove(item);
        //    }
        //}

        public static void Add()
        {
            Console.Clear();
            Console.Write("Input Student Name: ");
            string stName = Console.ReadLine();
            Console.Write("Input Test Name: ");
            string testName = Console.ReadLine();
            Console.Write("Input Rating: ");
            int rating = Int32.Parse(Console.ReadLine());
            StudentTest value = new StudentTest(stName,testName,rating, DateTime.Now);
            binaryTree.Insert(value);
        }

        public static void Remove()
        {
            Console.Clear();
            Console.Write("Input Student Name: ");//Only name just for example
            string stName = Console.ReadLine();
            StudentTest value = binaryTree.Where(st => st.StudentName == stName).FirstOrDefault();
            binaryTree.Remove(value);
        }

        public static void ReadFromFile()
        {
            using (FileStream fs = new FileStream("StudentTests.json", FileMode.OpenOrCreate))
            {
                BinaryTree<StudentTest> testsFromJson = (BinaryTree<StudentTest>)jsonSerializer.ReadObject(fs);
                testsFromJson.OutConsole("Info from json file");
            }
        }

        public static void WriteToFile()
        {
            using (FileStream fs = new FileStream("StudentTests.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, binaryTree);

            }
        }

        public static void SortByName()
        {
            var query = binaryTree.OrderBy(st => st.StudentName);
            OutCollection(query);        
        }

        public static void SortByRating()
        {
            var query = binaryTree.OrderBy(st => st.Rating);
            OutCollection(query);
        }

        public static void SortByTestName()
        {
            var query = binaryTree.OrderBy(st => st.TestName);
            OutCollection(query);
        }

        public static void SortByTestDate()
        {
            var query = binaryTree.OrderBy(st => st.TestDate);
            OutCollection(query);
        }

        public static void PagePresentation()
        {
            int pageNumber = 0;
            int maxPageNumber;
            if (binaryTree.Count / PageElements == 0)
                maxPageNumber = (binaryTree.Count / PageElements);
            else
                maxPageNumber = (binaryTree.Count / PageElements) + 1;
            while (pageNumber != maxPageNumber)
            {
                var q1 = binaryTree.Skip(PageElements * pageNumber).Take(PageElements);
                OutCollection(q1);
                pageNumber++;
            }
        }
    }
}
