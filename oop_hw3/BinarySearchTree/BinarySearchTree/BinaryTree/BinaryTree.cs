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

        public bool Find(Tkey key)
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
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<KeyValuePair<Tkey, Tvalue>> Traverse()
        {
            return TraverseNode(root);
        }

        private IEnumerable<KeyValuePair<Tkey, Tvalue>> TraverseNode(Node<Tkey, Tvalue> node)
        {
            if (node == null)
            {
                yield break;
            }

            foreach (var keyValuePair in TraverseNode(node.Left))
                yield return keyValuePair;

            yield return node.KeyValuePair;

            foreach (var keyValuePair in TraverseNode(node.Right))
                yield return keyValuePair;
        }

        public bool Remove(Tkey key)
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
                    break;
                }
            }

            if (currentNode == null)
                return false;

            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (currentNode.Parent == null)
                {
                    root = null;
                }
                else if (currentNode.Parent.Left == currentNode)
                {
                    currentNode.Parent.Left = null;
                }
                else
                {
                    currentNode.Parent.Right = null;
                }

                return true;
            }

            if (currentNode.Left == null)
            {
                currentNode.Right.Parent = currentNode.Parent;

                if (currentNode.Parent == null)
                {
                    root = currentNode.Right;
                }
                else if (currentNode.Parent.Left == currentNode)
                {
                    currentNode.Parent.Left = currentNode.Right;
                }
                else
                {
                    currentNode.Parent.Right = currentNode.Right;
                }

                return true;
            }

            if (currentNode.Right == null)
            {
                currentNode.Left.Parent = currentNode.Parent;

                if (currentNode.Parent == null)
                {
                    root = currentNode.Left;
                }
                else if (currentNode.Parent.Left == currentNode)
                {
                    currentNode.Parent.Left = currentNode.Left;
                }
                else
                {
                    currentNode.Parent.Right = currentNode.Left;
                }

                return true;
            }

            var leftmostNode = currentNode.Right;
            while (leftmostNode.Left != null)
            {
                leftmostNode = leftmostNode.Left;
            }

            currentNode.KeyValuePair = leftmostNode.KeyValuePair;
            if (leftmostNode.Right == null)
            {
                leftmostNode.Parent.Left = null;
            }
            else
            {
                leftmostNode.Parent.Left = leftmostNode.Right;
                leftmostNode.Right.Parent = leftmostNode.Parent;
            }

            return true;
        }
    }
}
