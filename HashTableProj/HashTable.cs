using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProj
{
    public class HashTable<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValuePair<K, V>>[] buckets;

        public HashTable(int size)
        {
            this.size = size;
            buckets = new LinkedList<KeyValuePair<K, V>>[size];
        }

        private int GetBucketIndex(K key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }

        public void Add(K key, V value)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] == null)
                buckets[index] = new LinkedList<KeyValuePair<K, V>>();

            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                    throw new ArgumentException("Key already exists in the hash table.");
            }

            buckets[index].AddLast(new KeyValuePair<K, V>(key, value));
        }

        public bool TryGetValue(K key, out V value)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] != null)
            {
                foreach (var pair in buckets[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }

        public bool Remove(K key)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] != null)
            {
                var current = buckets[index].First;
                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        buckets[index].Remove(current);
                        return true;
                    }
                    current = current.Next;
                }
            }

            return false;
        }

        public bool Update(K key, V newValue)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] != null)
            {
                var current = buckets[index].First;
                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        var newPair = new KeyValuePair<K, V>(key, newValue);
                        buckets[index].AddBefore(current, newPair);
                        buckets[index].Remove(current);
                        return true;
                    }
                    current = current.Next;
                }
            }

            return false;
        }
    }

}
