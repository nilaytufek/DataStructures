using System.Collections.Generic;

namespace DataStructures
{
    class HashNode<K,V>
    {
        public K key;
        public V value;
        public HashNode(K k, V v)
        {
            key = k;
            value = v;
        }


        public HashNode<K, V> NextNode = null;
    }
    class LinkedListH<K, V>
    {
        public HashNode<K, V> first = null;
        public HashNode<K, V> last = null;
        public void Add(HashNode<K, V> node)
        {
            if (first == null)
            {
                first = node;
            }
            else
            {
                last.NextNode = node;
            }
            last = node;
        }
        public LinkedListH()
        {
            first = null;
            last = first;
        }
        public V[] GetList()
        {
            V[] arr = new V[30];
            HashNode<K, V> tmp = first;
            int i = 0;
            while (tmp != null)
            {
                arr[i] = tmp.value;
                tmp = tmp.NextNode;
                i++;
            }
            return arr;

        }
        public void Remove(K _key)
        {
            HashNode<K, V> candidate = first;
            if (Comparer<K>.Default.Compare(first.key, _key) == 0)
            {
                first = first.NextNode;
                return;
            }
            while (Comparer<K>.Default.Compare(candidate.NextNode.key, _key) != 0)
            {
                candidate = candidate.NextNode;
            }
            candidate.NextNode = candidate.NextNode.NextNode;

        }

        public V GetValue(K _key)
        {
            HashNode<K, V> candidate = first;
            while (Comparer<K>.Default.Compare(candidate.key, _key) != 0)
            {
                candidate = candidate.NextNode;
            }
            return candidate.value;
        }
    }

}
