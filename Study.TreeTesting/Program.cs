using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentTests;
using Study.BinaryTree;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Study.TreeTesting.MenuCommands;

namespace Study.TreeTesting
{
    class Program
    {
        //For Tests
        static BinaryTree<int> tree = new BinaryTree<int>();
        static List<StudentTest> stList = new List<StudentTest>();
        static BinaryTree<StudentTest> studTree;
        //********************* end For Tests
        static void Main(string[] args)
        {

            Run();
            Console.ReadLine();
        }

        static CommandInfo[] commandInfoArray = {
            new CommandInfo("Exit", null),
            new CommandInfo("Add Test Data", Commands.FillTestData),
            new CommandInfo("Add value", Commands.Add),
            new CommandInfo("Remove value", Commands.Remove),
            new CommandInfo("Sort by Name", Commands.SortByName),
            new CommandInfo("Sort by Test Name", Commands.SortByTestName),
            new CommandInfo("Sort by Rating", Commands.SortByRating),
            new CommandInfo("Sort by Date", Commands.SortByTestDate),
            new CommandInfo("Page View", Commands.PagePresentation)
        };

        static void ShowCommandsMenu()
        {
            Console.WriteLine("\nList of Menu Commands:");
            for (int i = 0; i < commandInfoArray.Length; i++)
            {
                Console.WriteLine("\t{0,2} - {1}", i, commandInfoArray[i].name);
            }
        }

        static Command EnterCommand()
        {
            Console.Write("\nEnter the number of the command from menu: ");
            string s = Console.ReadLine();
            int number = Convert.ToInt32(s);
            return commandInfoArray[number].command;
        }

        static void Run()
        {
            while (true)
            {
                Console.Clear();
                Commands.OutDataLINQ();
                ShowCommandsMenu();
                Command command = EnterCommand();
                if (command == null)
                {
                    return;
                }
                command();
            }
        }

        #region TestingStuff
        static void TreeFill()
        {
            tree.Insert(50);
            tree.Insert(45);
            tree.Insert(57);
            tree.Insert(23);
            tree.Insert(34);
            tree.Insert(75);
            tree.Insert(20);
            tree.Insert(55);
        }

        static void StudentsListFill()
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
        }

        static void TraversalTest()
        {
            tree.TraversalOrder = TraversalMode.InorderTraversal;
            Console.WriteLine("Inorder traversal");
            foreach (int item in tree)
            {
                Console.Write($"{item} ");
            }

            tree.TraversalOrder = TraversalMode.PostorderTraversal;
            Console.WriteLine("\nPostorder traversal");
            foreach (int item in tree)
            {
                Console.Write($"{item} ");
            }

            tree.TraversalOrder = TraversalMode.PreorderTraversal;
            Console.WriteLine("\nPreorder traversal");
            foreach (int item in tree)
            {
                Console.Write($"{item} ");
            }

        }

        static void ShowTreeInorder()
        {
            tree.TraversalOrder = TraversalMode.InorderTraversal;
            Console.WriteLine("Inorder traversal");
            foreach (int item in tree)
            {
                Console.Write($"{item} ");
            }
        }

        static void DeleteTest()
        {
            int valueToRemove = 45;
            Console.WriteLine($"Removing {valueToRemove}");
            Console.WriteLine($"Count before remove {tree.Count}");
            Console.WriteLine(tree.Remove(valueToRemove));
            Console.WriteLine(tree.Contains(valueToRemove));
            tree.InorderTraversal((x) => Console.Write($"{x} "));
            Console.WriteLine($"\nCount after remove {tree.Count}");
            //ShowTreeInorder();
            //Console.WriteLine("\nRemoving 50");
            //tree.Remove(50);
            //ShowTreeInorder();
        }

        static void FindTest()
        {
            int value = 20;
            Console.WriteLine($"Searching for element {value}");
            Console.WriteLine(tree.Contains(value) ? "Найдено" :"Не найдено");
        }

        static void ExceptionTest()
        {
            try
            {
                tree.Remove(20);
            }
            catch (BinaryTreeException treeEX)
            {
                Console.WriteLine(treeEX.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void StudentTestsWriteFile()
        {
            StudentsListFill();
            studTree = new BinaryTree<StudentTest>(stList);
            IEnumerable<StudentTest> treeArray = studTree.ToArray();
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<StudentTest>));

            using (FileStream fs = new FileStream("StudentTests.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, treeArray);
            }

            using (FileStream fs = new FileStream("StudentTests.json", FileMode.OpenOrCreate))
            {
                IEnumerable<StudentTest> testsFromJson = (IEnumerable<StudentTest>)jsonSerializer.ReadObject(fs);

                foreach (var item in testsFromJson)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        #endregion
    }
}
