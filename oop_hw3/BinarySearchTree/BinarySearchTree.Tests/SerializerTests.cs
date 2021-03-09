using BinarySearchTree.BinaryTree;
using BinarySearchTree.SerializationConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    class SerializerTests
    {
        [TestClass]
        public class BinaryTree DictionarySerializerTest
        {
            [TestMethod]
            public void TestSerializeAndDeserialize()
            {
                var dict = new BinaryTreeDictionary<int, string>();

                dict.Add(1, "first value");
                dict.Add(3, "third value");
                dict.Add(7, "seventh value");

                var name = "testFile";
                var stream = new MemoryStream();

                var storageMock = new Mock<IStorage>();
                storageMock.Setup(s => s.GetWriteStream(name))
                    .Returns(stream);
                storageMock.Setup(s => s.GetReadStream(name))
                    .Returns(stream);

                var serializer = new BinarySearchTreeSerializer(storageMock.Object);
                serializer.Save(name, dict, closeStream: false);
                stream.Position = 0;
                var newDict = serializer.Load<int, string>(name);

                CollectionAssert.AreEquivalent(dict.ToList(), newDict.ToList());
            }

            [TestMethod]
            public void TestSerialize()
            {
                var dict = new BinaryTreeDictionary<int, string>();

                dict.Add(1, "first value");
                dict.Add(3, "third value");
                dict.Add(7, "seventh value");

                var name = "testFile";   
                var stream = new MemoryStream();

                var storageMock = new Mock<IStorage>();
                storageMock.Setup(s => s.GetWriteStream(name))
                    .Returns(stream);

                var serializer = new BinarySearchTreeSerializer(storageMock.Object);

                serializer.Save(name, dict, closeStream: false);
                stream.Position = 0;

                var serialized = Encoding.ASCII.GetString(stream.ToArray());

                Assert.AreEqual(@"[{""Key"":1,""Value"":""first value""},{""Key"":3,""Value"":""third value""},{""Key"":7,""Value"":""seventh value""}]", serialized);
            }
        }
    }
}
