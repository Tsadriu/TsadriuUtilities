// <copyright file DictionaryHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="Dictionary{TKey, TValue}"/>.
    /// </summary>
    public static class DictionaryHelper
    {
        /// <summary>
        /// Iterates through each element of the <paramref name="list"/> and splits it by <paramref name="separator"/>, assigning <typeparamref name="TKey"/> to everything that is before the <paramref name="separator"/> and <typeparamref name="TValue"/> to everything that is after the <paramref name="separator"/>.
        /// </summary>
        /// <typeparam name="TKey">Key type.</typeparam>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="list">Current list of <see cref="string"/>.</param>
        /// <param name="separator">Separator used to determine what is picked as a <typeparamref name="TKey"/> and as a <typeparamref name="TValue"/>.</param>
        /// <param name="invertKeyWithValue">Set to true to invert the <typeparamref name="TKey"/> with the <typeparamref name="TValue"/>.</param>
        /// <returns>A dictionary filled with valid data based on the elements of <paramref name="list"/>.</returns>
        public static Dictionary<TKey, TValue>ToDictionary<TKey, TValue>(this List<string> list, string separator = " ", bool invertKeyWithValue = false)
        {
            var dict = new Dictionary<TKey, TValue>();

            foreach (var element in list)
            {
                var key = element.GetBetween(string.Empty, separator);
                var value = element.GetBetween(separator, string.Empty);

                if (StringHelper.AreNotEmpty(key, value))
                {
                    TKey keyConverted = (TKey)Convert.ChangeType(invertKeyWithValue ? value : key, typeof(TKey));
                    TValue valueConverted = (TValue)Convert.ChangeType(invertKeyWithValue ? key : value, typeof(TValue));

                    dict.Add(keyConverted, valueConverted);
                }
            }

            return dict;
        }

        /// <summary>
        /// Returns the <paramref name="dictionary"/> where the <typeparamref name="TValue"/> is the key and <typeparamref name="TKey"/> is the value.
        /// </summary>
        /// <typeparam name="TKey">Key type.</typeparam>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="dictionary">Current dictionary</param>
        /// <returns>A new <see cref="Dictionary{TKey, TValue}"/> with the values swapped.</returns>
        public static Dictionary<TValue, TKey>FlipKeyWithValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            var keys = new List<TKey>(dictionary.Keys);
            var values = new List<TValue>(dictionary.Values);

            var newDictionary = new Dictionary<TValue, TKey>();
            
            for (int i = 0; i < keys.Count; i++)
            {
                newDictionary.Add(values[i], keys[i]);
            }

            return newDictionary;
        }
    }
}