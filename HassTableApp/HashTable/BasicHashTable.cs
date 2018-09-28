using System;

namespace DataStructures
{
    //this hash table has no linked list. for the same key, it gives warning.
    //it is easier one to start of hash tables
    class BasicHashTable<K, V> : BaseHashTable<K, V>, IHashTable<K, V>
    {
        V[] values = new V[10];

        public BasicHashTable(int _capacity)
        {
            capacity = _capacity;
        }

        public void Print()
        {
            Console.WriteLine(string.Join(" ", values));
        }

        public void Add(HashNode<K, V> node)
        {
            int index = GetIndexOfKey(node.key, capacity);
            if (values[index] != null)
            {
                Console.WriteLine("the <{0},{1}> is not added. Please change the key", node.key, node.value);
            }
            else
            {
                values[index] = node.value;
            }
        }

        public V Get(K _key)
        {
            int index = GetIndexOfKey(_key, capacity);
            return values[index];
        }

        public void Remove(K _key)
        {
            int index = GetIndexOfKey(_key, capacity);
            values[index] = default(V);
        }
    }
}
