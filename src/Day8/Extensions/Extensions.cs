using System.Collections.Generic;

namespace Day8.Extensions
{
    public static class Extensions
    {
        public static Dictionary<TValue, TKey> ReverseDictionary<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            var dictionary = new Dictionary<TValue, TKey>();
            foreach (var (key, value) in source)
            {
                if(!dictionary.ContainsKey(value))
                    dictionary.Add(value, key);
            }
            return dictionary;
        } 
    }
}