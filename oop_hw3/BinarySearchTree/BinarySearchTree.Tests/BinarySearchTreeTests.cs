﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var dict = new BinaryTreeDictionary<int, string>();

            Assert.IsFalse(dict.ContainsKey(7));
        }

        [TestMethod]
        public void TestCountEmpty()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            Assert.AreEqual(0, dict.Count);
        }

        [TestMethod]
        public void TestCount()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");
            dict.Add(3, "third value");
            dict.Add(7, "seventh value");

            Assert.AreEqual(3, dict.Count);
        }

        [TestMethod]
        public void TestDontCountTwice()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");
            dict.Add(1, "first value");

            Assert.AreEqual(1, dict.Count);
        }

        [TestMethod]
        public void TestReturnCollection()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");
            dict.Add(3, "third value");

            var defaultDict = new Dictionary<int, string>()
            {
                { 1, "first value" },
                { 3, "third value" }
            };
            CollectionAssert.AreEqual(defaultDict, dict.ToList());
        }

        [TestMethod]
        public void TestRemoveNotAdded()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            Assert.IsFalse(dict.Remove(1));
        }

        [TestMethod]
        public void TestRemoves()
        {
            var dict = new BinaryTreeDictionary<int, string>();
            
            dict.Add(1, "first value");

            Assert.IsTrue(dict.Remove(1));
            Assert.AreEqual(0, dict.Count);
        }

        [TestMethod]
        public void TestRemovesWihDeepTree()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");
            dict.Add(3, "third value");
            dict.Add(7, "seventh value");
            dict.Add(11, "eleventh value");

            Assert.IsTrue(dict.Remove(3));
            Assert.IsTrue(dict.Remove(11));
            Assert.AreEqual(2, dict.Count);
        }

        [TestMethod]
        public void TestCopyTo()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");
            dict.Add(3, "third value");
            dict.Add(7, "seventh value");
            dict.Add(11, "eleventh value");

            KeyValuePair<int, string>[] array = new KeyValuePair<int, string>[4];

            dict.CopyTo(array, 0);

            Assert.IsNotNull(array);
            Assert.AreEqual(array[0], new KeyValuePair<int, string>(1, "first value"));
        }

        [TestMethod]
        public void TestClear()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");
            dict.Add(3, "third value");
            dict.Clear();

            Assert.AreEqual(0, dict.Count);
        }

        [TestMethod]
        public void TestTryGetValue()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");
            var value = "default value";

            Assert.IsTrue(dict.TryGetValue(1, out value));
        }

        [TestMethod]
        public void TestAddAndResetValue()
        {
            var dict = new BinaryTreeDictionary<int, string>();

            dict.Add(1, "first value");
            dict[1] = "default value";

            Assert.IsFalse(dict.Contains(new KeyValuePair<int, string>(1, "first value")));
            Assert.IsTrue(dict.Contains(new KeyValuePair<int, string>(1, "default value")));
        }
    }
}
 