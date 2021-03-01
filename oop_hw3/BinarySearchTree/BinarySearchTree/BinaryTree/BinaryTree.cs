using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree.BinaryTree
{
    class BinaryTree<Tkey, Tvalue> where Tkey : IComparable
    {
        private Node<Tkey, Tvalue> root;

        public bool Add(KeyValuePair<Tkey, Tvalue> keyValuePair)
        {
            var currentNode = root;
            while (currentNode != null)
            {
                var compareResult = keyValuePair.Key.CompareTo(currentNode.KeyValuePair.Key);
                if (compareResult < 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new Node<Tkey, Tvalue>
                        {
                            KeyValuePair = keyValuePair,
                            Parent = currentNode
                        };
                        return true;
                    }

                    currentNode = currentNode.Left;
                }
                else if (compareResult > 0)
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new Node<Tkey, Tvalue>
                        {
                            KeyValuePair = keyValuePair,
                            Parent = currentNode
                        };
                        return true;
                    }

                    currentNode = currentNode.Right;
                }
                else
                {
                    return false;
                }
            }

            root = new Node<Tkey, Tvalue>()
            {
                KeyValuePair = keyValuePair
            };
            return true;
        }

        public KeyValuePair<Tkey, Tvalue> Find(Tkey key)
        {
            var currentNode = root;
            while (currentNode != null)
            {
                var compareResult = key.CompareTo(currentNode.KeyValuePair.Key);
                if (compareResult < 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (compareResult > 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    return currentNode.KeyValuePair;
                }
            }

            return new KeyValuePair<Tkey, Tvalue>();
        }
    }
}
