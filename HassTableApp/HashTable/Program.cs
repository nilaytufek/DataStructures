using System;


/**
 * @author Nilay Tufek
 * @contact ntufek@gmail.com 
 * 
 * This is a C# implementation of Hash Tables.
 * You can use for all types. It is written in "generic" types.
 * Here you will find basic and complex type of hash tables.
 * Basic type hash table has only one hash for each key
 * while complex type holds values in liked list for the same hashes.
 * complex is the more 
 * 
 */
namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Need to give a default hash table size
            int capacity = 10;
            //IHashTable<string, string> ht = new BasicHashTable<string, string>(capacity); 
            IHashTable<string, string> ht = new ComplexHashTable<string, string>(capacity);
            

            long[] numbers = { 1000, 2000, 3000, 4000, 5000, 6000, 7000 };
            Helper<string,string>.TestAddTime(numbers);

            Helper<string, string>.TestAllPurposes(ht);

            Console.WriteLine("---");
        }
        
        class Helper<K,V>
        {
            //test for time complexity for add function O(n)
            static public void TestAddTime(long[] numbers)
            {                
                //TestTime
                long[] times = new long[7];
                int i = 0;
                foreach (var num in numbers)
                {
                    Console.WriteLine(num);
                    IHashTable<K, V> ht = new ComplexHashTable<K, V>(10);
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    AddAll(ht, num);
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    times[i] = elapsedMs;
                    Console.WriteLine(elapsedMs);
                    i++;
                }
                times = null;

            }
            //test for basic functionality
            static public void TestAllPurposes(IHashTable<K, V> ht)
            {
                AddAll(ht, 50);
                ht.Print();
                Console.WriteLine("----------------------------------------");
                Remove(ht, (K)Convert.ChangeType("4", typeof(K)));
                ht.Print();
                Console.WriteLine("----------------------------------------");
                Add(ht, new HashNode<K,V>((K)Convert.ChangeType("4", typeof(K)), (V)Convert.ChangeType("104", typeof(V))));
                ht.Print();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(Search(ht, (K)Convert.ChangeType("4", typeof(K))));
                Console.WriteLine(Search(ht, (K)Convert.ChangeType("5", typeof(K))));
                Console.WriteLine("----------------------------------------");
                RemoveAll(ref ht, 50);
                ht.Print();
            }

            private static void AddAll(IHashTable<K, V> ht, long number)
            {
                for (int i = 0; i < number; i++)
                {
                    K k = (K)Convert.ChangeType(i.ToString(), typeof(K));
                    V v = (V)Convert.ChangeType((i+100).ToString(), typeof(V));
                    HashNode<K,V> node = new HashNode<K,V>(k, v);
                    ht.Add(node);
                }
            }

            static public V Search(IHashTable<K, V> ht, K key)
            {
                return ht.Get(key);
            }

            static public void Add(IHashTable<K, V> ht, HashNode<K, V> node)
            {
                ht.Add(node);
            }

            static public void RemoveAll(ref IHashTable<K, V> ht, int number)
            {
                for (int i = 0; i < number; i++)
                {
                    K key = (K)Convert.ChangeType(i.ToString(), typeof(K));
                    ht.Remove(key);
                }
            }

            static public void Remove(IHashTable<K, V> ht, K key)
            {
                ht.Remove(key);
            }
        }


    }  
    
}
