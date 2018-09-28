using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace DataStructures
{
    abstract class BaseHashTable<K, V>
    { 
        protected int capacity;        
        virtual protected int GetIndexOfKey(K _key, int capacity)
        {
            int hash = AnyHashfunction(_key);
            int index = Mod(hash, capacity);
            return index;
        }
        virtual protected int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }
        virtual protected int AnyHashfunction(K _key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(ObjectToByteArray(_key));
            int hash = BitConverter.ToInt32(bytes, 0);
            return hash;
        }
        private byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }


    interface IHashTable<K,V>
    {
        void Print();
        void Add(HashNode<K, V> node);
        V Get(K _key);
        void Remove(K _key);
    }
}
