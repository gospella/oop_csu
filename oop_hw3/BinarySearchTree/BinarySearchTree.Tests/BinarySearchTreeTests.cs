using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;
using BinarySearchTree.BinaryTree;

namespace BinarySearchTree.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void TestAddAndGet() 
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");

            Assert.IsTrue(dict.Contains(new KeyValuePair<int, string>(1, "first value")));
        }

        [TestMethod]
        public void TestAddMultipleAndGet()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");
            dict.Add(3, "third value");
            dict.Add(7, "seventh value");


            Assert.IsTrue(dict.Contains(new KeyValuePair<int, string>(7, "seventh value")));
            Assert.IsTrue(dict.Contains(new KeyValuePair<int, string>(1, "first value")));
            Assert.IsTrue(dict.Contains(new KeyValuePair<int, string>(3, "third value")));
        }

        [TestMethod]
        public void TestDontAddAndDontGet()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            Assert.IsFalse(dictionary.Contains(new KeyValuePair<int, string>(7, "seventh value")));
        }
    }
}
 