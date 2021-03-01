using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace BinarySearchTree.BinaryTree
{
    public class BinaryTreeDictionary<Tkey, Tvalue> : IDictionary<Tkey, Tvalue> where Tkey : IComparable
    {
        private BinaryTree<Tkey, Tvalue> tree = new BinaryTree<Tkey, Tvalue>();


        public Tvalue this[Tkey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Tkey> Keys => throw new NotImplementedException();

        public ICollection<Tvalue> Values => throw new NotImplementedException();

        public int Count => tree.Traverse().Count();

        public bool IsReadOnly => false;

        public void Add(Tkey key, Tvalue value)
        {
            var KeyValuePair = new KeyValuePair<Tkey, Tvalue>(key, value);
            tree.Add(KeyValuePair);
        }

        public void Add(KeyValuePair<Tkey, Tvalue> item)
        {
            tree.Add(item);
        }

        public void Clear()
        {
            tree = new BinaryTree<Tkey, Tvalue>();
        }

        public bool Contains(KeyValuePair<Tkey, Tvalue> item)
        {
            return tree.Find(item.Key);
        }

        public bool ContainsKey(Tkey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Tkey, Tvalue>[] array, int arrayIndex)
        {
            foreach (var keyValuePair in tree.Traverse())
            {
                array[arrayIndex++] = keyValuePair;
            }
        }

        public IEnumerator<KeyValuePair<Tkey, Tvalue>> GetEnumerator()
        {
            return tree.Traverse()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(Tkey key)
        {
            return tree.Remove(key);
        }

        public bool Remove(KeyValuePair<Tkey, Tvalue> item)
        {
            return tree.Remove(item.Key);
        }

        public bool TryGetValue(Tkey key, out Tvalue value)
        {
            throw new NotImplementedException();
        }

        public ICollection ToDictionary<T1, T2>()
        {
            throw new NotImplementedException();
        }
    }
}
