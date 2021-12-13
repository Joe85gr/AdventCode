using System.Collections.Generic;

namespace Library
{
    public static class Extensions
    {
        public static void AddRange<T, TY>(this IDictionary<T, TY> dictionary, Dictionary<T, TY> rangeToAdd)
        {
            foreach (var (key, value) in rangeToAdd)
            {
                dictionary.Add(key, value);
            }
        }
    }
}