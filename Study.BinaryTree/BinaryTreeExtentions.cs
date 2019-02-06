using System;
using System.Collections.Generic;
using System.Text;

namespace Study.BinaryTree
{
    public static class BinaryTreeExtentions
    {
        public static void OutConsole<T>(this BinaryTree<T> binaryTree, string collectionName) where T :IComparable<T>
        {
            Console.WriteLine(binaryTree.TraversalOrder);
            foreach (var item in binaryTree)
            {
                Console.Write($"{item.ToString()}");
            }
        }
    }
}
