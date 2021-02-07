using System;
using System.Collections.Generic;
using System.Linq;

namespace SpreeTrail
{
    public class MultiValueDictionary<Tkey, TValue>
    {
        Dictionary<Tkey, List<TValue>> dictionary = new Dictionary<Tkey, List<TValue>>();

        public void Add(Tkey key, TValue val)
        {
            List<TValue> list;

            if (dictionary.ContainsKey(key))
            {
                list = dictionary[key];
                if (list.Contains(val))
                {
                    throw new Exception("ERROR, value already exists\n");
                }
                else
                {
                    list.Add(val);
                }
            }
            else
            {
                list = new List<TValue>();
                list.Add(val);
                dictionary[key] = list;
            }
        }

        public void Remove(Tkey key, TValue val)
        {
            if (dictionary.ContainsKey(key))
            {
                List<TValue> list = dictionary[key];
                if (list.Contains(val))
                {
                    list.Remove(val);

                    if (!list.Any()) dictionary.Remove(key);
                }
                else
                {
                    throw new Exception("ERROR, value does not exist\n");
                }
            }
            else
            {
                throw new Exception("ERROR, key does not exist\n");
            }
        }

        public bool CheckValueExists(Tkey key, TValue val)
        {

            if (dictionary.ContainsKey(key))
            {
                List<TValue> list = dictionary[key];
                if (list.Contains(val)) return true;
                return false;
            }
            else
            {
                return false;
            }
        }

        public List<TValue> GetMembers(Tkey key)
        {
            if (dictionary.ContainsKey(key))
            {
                return new List<TValue>(dictionary[key]);
            }
            else
            {
                throw new Exception("ERROR, key Does not exist\n");
            }
        }

        public void RemoveAll(Tkey key)
        {

            if (dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
            }
            else
            {
                throw new Exception("ERROR, key does not exist\n");
            }
        }

        public bool CheckKeyExists(Tkey key)
        {

            if (dictionary.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            dictionary.Clear();
        }

        public List<Tkey> GetKeys()
        {
            return dictionary.Keys.ToList<Tkey>();
        }

        public List<TValue> GetAllMembers()
        {
            List<TValue> result = new List<TValue>();
            foreach (KeyValuePair<Tkey, List<TValue>> kvp in dictionary)
            {
                List<TValue> list = dictionary[kvp.Key];
                foreach (TValue s in list)
                {
                    result.Add(s);
                }
            }
            return result;
        }

        public Dictionary<Tkey, List<TValue>> GetItems()
        {
            return new Dictionary<Tkey, List<TValue>>(dictionary);
        }
    }
}