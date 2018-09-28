using System;

namespace DataStructures
{
    //Hash table with linked list for the same hash of keys
    class ComplexHashTable<K, V> : BaseHashTable<K, V>, IHashTable<K, V>
    {
        LinkedListH<K, V>[] bucket = new LinkedListH<K, V>[10];

        public ComplexHashTable(int _capacity)
        {
            capacity = _capacity;        
            for (int i = 0; i < capacity; i++)
            {
                bucket[i] = new LinkedListH<K, V>();
            }
        }

        public void Print()
        {
            foreach (var item in bucket)
            {
                Console.WriteLine(string.Join(" ", item.GetList()));
            }
        }
        public void Add(HashNode<K, V> node)
        {
            int index = GetIndexOfKey(node.key, capacity);
            bucket[index].Add(node);
        }
        public V Get(K _key)
        {
            int index = GetIndexOfKey(_key, capacity);
            return bucket[index].GetValue(_key);
        }

        public void Remove(K _key)
        {
            int index = GetIndexOfKey(_key, capacity);
            bucket[index].Remove(_key);
        }
    }

}
