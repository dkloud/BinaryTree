using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Study.BinaryTree.UnitTests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void Constructor_InsertCollection_TreeIsNotNull()
        {
            // Arrange
            BinaryTree<int> binaryTree;
            int[] arrayToInsert = { 1, 43, 44, 55, 66, 77};
            int counter = 0, expectedItem;

            // Act
            binaryTree = new BinaryTree<int>(arrayToInsert);
            Array.Sort(arrayToInsert);

            // Assert
            foreach (var actualItem in binaryTree)
            {
                expectedItem = arrayToInsert[counter];
                Assert.AreEqual(expectedItem, actualItem);
                counter++;
            }
        }

        [DataTestMethod]
        [DataRow(50)]
        [DataRow(-12321321)]
        public void Insert_ValidValue_ValueInserted(int valueToInsert)
        {
            // Arrange
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            // Act
            binaryTree.Insert(valueToInsert);

            // Assert
            foreach (var actualItem in binaryTree)
            {
                int expectedItem = valueToInsert;
                Assert.AreEqual(expectedItem, actualItem);
            }
        }

        [TestMethod]
        public void Maximum_FindMaxValue_ReturnsMaximumValue()
        {
            // Arrange
            int[] arrayToInsert = { -232, 1, 121, 444, 55, 66, 77 };
            int expectedMaxValue = 444;
            BinaryTree<int> binaryTree = new BinaryTree<int>(arrayToInsert);

            // Act
            int actualMaxValue = binaryTree.GetMaxValue();

            // Assert
            Assert.AreEqual(expectedMaxValue, actualMaxValue);
        }

        [TestMethod]
        public void Minimum_FindMinValue_ReturnsMinimumValue()
        {
            // Arrange
            int[] arrayToInsert = { 1, -32, 121, 444, 55, 66, 77 };
            int expectedMinValue = -32;
            BinaryTree<int> binaryTree = new BinaryTree<int>(arrayToInsert);

            // Act
            int actualMinValue = binaryTree.GetMinValue();

            // Assert
            Assert.AreEqual(expectedMinValue, actualMinValue);
        }

        [TestMethod]
        public void Remove_RemovingRoot_RootRemoved()
        {
            // Arrange
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            int valueToRemove = 69;
            binaryTree.Insert(valueToRemove);

            // Act
            binaryTree.Remove(valueToRemove);
            bool removedValueIsExist = binaryTree.Contains(valueToRemove);

            // Assert
            Assert.IsFalse(removedValueIsExist);
        }

        [TestMethod]
        [ExpectedException(typeof(BinaryTreeException))]
        public void Remove_RootIsNull_ExpectedException()
        {
            // Arrange
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            // Act
            binaryTree.Remove(21);

            // Assert
        }

        [TestMethod]
        public void Remove_NodeIsLeaf_NodeRemoved()
        {
            // Arrange
            int[] arrayToInsert = { 1, -32, 121, 444, 55, 66, 77 };
            int valueToRemove = 77;
            BinaryTree<int> binaryTree = new BinaryTree<int>(arrayToInsert);

            // Act
            binaryTree.Remove(valueToRemove);
            bool removedValueExists = binaryTree.Contains(valueToRemove);

            // Assert
            Assert.IsFalse(removedValueExists);
        }

        [TestMethod]
        public void Remove_NodeHasOneChild_NodeRemoved()
        {
            // Arrange
            int[] arrayToInsert = { 1, -32, 121, 444, 55, 66, 77 };
            int valueToRemove = 66;
            BinaryTree<int> binaryTree = new BinaryTree<int>(arrayToInsert);

            // Act
            binaryTree.Remove(valueToRemove);
            bool removedValueExists = binaryTree.Contains(valueToRemove);

            // Assert
            Assert.IsFalse(removedValueExists);
        }

        [TestMethod]
        public void Remove_NodeHasTwoChilds_NodeRemoved()
        {
            // Arrange
            int[] arrayToInsert = { 1, -32, 121, 444, 55, 66, 77 };
            int valueToRemove = 121;
            BinaryTree<int> binaryTree = new BinaryTree<int>(arrayToInsert);

            // Act
            binaryTree.Remove(valueToRemove);
            bool removedValueExists = binaryTree.Contains(valueToRemove);

            // Assert
            Assert.IsFalse(removedValueExists);
        }

        [TestMethod]
        public void Contains_ValueExists_ReturnsTrue()
        {
            // Arrange
            int[] arrayToInsert = { 1, -32, 121, 444, 55, 66, 77 };
            int valueToSearch = 77;
            BinaryTree<int> binaryTree = new BinaryTree<int>(arrayToInsert);

            // Act
            bool valueExists = binaryTree.Contains(valueToSearch);

            // Assert
            Assert.IsTrue(valueExists);
        }

        [TestMethod]
        public void Contains_ValueDoesNotExist_ReturnsFalse()
        {
            // Arrange
            int[] arrayToInsert = { 1, -32, 121, 444, 55, 66, 77 };
            int valueToSearch = 99;
            BinaryTree<int> binaryTree = new BinaryTree<int>(arrayToInsert);

            // Act
            bool valueExists = binaryTree.Contains(valueToSearch);

            // Assert
            Assert.IsFalse(valueExists);
        }

        public void Template()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
