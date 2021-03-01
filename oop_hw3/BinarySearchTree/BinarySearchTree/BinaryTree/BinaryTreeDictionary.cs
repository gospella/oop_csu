using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTree.BinaryTree
{
    public class BinaryTreeDictionary<Tkey, Tvalue> : IDictionary<Tkey, Tvalue> where Tkey : IComparable
    {
        private BinaryTree<Tkey, Tvalue> tree = new BinaryTree<Tkey, Tvalue>();


        public Tvalue this[Tkey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Tkey> Keys => throw new NotImplementedException();

        public ICollection<Tvalue> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

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
            var currentKeyValuePair = tree.Find(item.Key);
            return !currentKeyValuePair.Equals(new KeyValuePair<Tkey, Tvalue>()) && currentKeyValuePair.Value.Equals(item.Value); //todo 
        }

        public bool ContainsKey(Tkey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Tkey, Tvalue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Tkey, Tvalue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Tkey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Tkey, Tvalue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Tkey key, out Tvalue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
