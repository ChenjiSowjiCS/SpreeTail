using System;
using System.Collections.Generic;
using System.Linq;

namespace SpreeTrail
{
    /// <summary>
    /// Generic Multi-Value dictionary class 
    /// Contains all methods to perform basic dictionary operations
    /// </summary>
    public class MultiValueDictionary<Tkey, TValue>
    {
        Dictionary<Tkey, List<TValue>> dictionary = new Dictionary<Tkey, List<TValue>>();

        /// <summary>
        /// Adds the specified key and val to the dictionary.
        /// </summary>
        public void Add(Tkey key, TValue val)
        {
            List<TValue> list;

            if (dictionary.ContainsKey(key))
            {
                list = dictionary[key];
                if (list.Contains(val))
                {
                    throw new Exception("ERROR, value already exists");
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

        /// <summary>
        /// Removes the val with the specified key from the dictionary.
        /// </summary>
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
                    throw new Exception("ERROR, value does not exist");
                }
            }
            else
            {
                throw new Exception("ERROR, key does not exist");
            }
        }

        /// <summary>
        /// Checks whether the val exists within a key.
        /// </summary>
        /// <returns>
        /// true if the val is successfully found within the key; otherwise, false. 
        /// </returns>
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

        /// <summary>
        /// Gets the collection of string of values for the given key.
        /// </summary>
        /// <returns>
        /// List of string if given key exists; Otherwise, an error.
        /// </returns>
        public List<TValue> GetMembers(Tkey key)
        {
            if (dictionary.ContainsKey(key))
            {
                return new List<TValue>(dictionary[key]);
            }
            else
            {
                throw new Exception("ERROR, key Does not exist");
            }
        }

        /// <summary>
        /// Removes all the values of the specified key from the dictionary.
        /// </summary>
        public void RemoveAll(Tkey key)
        {

            if (dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
            }
            else
            {
                throw new Exception("ERROR, key does not exist");
            }
        }

        /// <summary>
        /// Checks whether the key exists within the dictionary.
        /// </summary>
        /// <returns>
        /// true if the key is successfully found; otherwise, false. 
        /// </returns>
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

        /// <summary>
        /// Removes all keys and values from the dictionary.
        /// </summary>
        public void Clear()
        {
            dictionary.Clear();
        }

        /// <summary>
        /// Gets all the keys into a new list.
        /// </summary>
        /// <returns>
        /// List of strings with all keys available in the dictionary.
        /// </returns>
        public List<Tkey> GetKeys()
        {
            return dictionary.Keys.ToList<Tkey>();
        }

        /// <summary>
        /// Gets the collection of strings with values of all the keys in the dictionary.
        /// </summary>
        /// <returns>
        /// List of string of values of all the keys in the dictionary.
        /// </returns>
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

        /// <summary>
        /// Gets all the keys and  values in the dictionary
        /// </summary>
        /// <returns>
        /// A new reference to the dictionary
        /// </returns>
        public Dictionary<Tkey, List<TValue>> GetItems()
        {
            return new Dictionary<Tkey, List<TValue>>(dictionary);
        }
    }
}