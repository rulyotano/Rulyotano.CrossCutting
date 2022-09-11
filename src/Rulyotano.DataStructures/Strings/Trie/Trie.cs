using System;
using System.Collections.Generic;

namespace Rulyotano.DataStructures.Strings.Trie
{
    public class Trie<T> where T : class
    {
        public T Value { get; private set; }
        public IDictionary<char, Trie<T>> Children { get; }
        public bool IsLeaf => Children.Count == 0;
        public bool IsMatch => Value is not null;

        public Trie()
        {
            Children = new Dictionary<char, Trie<T>>();
        }

        /// <summary>
        /// Add item to the Trie.
        /// </summary>
        /// <param name="key">Key string to add</param>
        /// <param name="collisionResolver">Function to add value when already existed</param>
        /// <param name="newCreator">Function to add new value</param>
        public void Add(string key, Func<T, T> collisionResolver, Func<T> newCreator)
            => AddPrivate(key, collisionResolver, newCreator, 0);

        /// <summary>
        /// Get value matching key, null if not found
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get(string key)
        {
            var node = GetNode(key);
            return node?.Value;
        }

        /// <summary>
        /// Get note matching key
        /// </summary>
        /// <param name="key">key string to match</param>
        /// <returns></returns>
        public Trie<T> GetNode(string key)
            => GetNodePrivate(key);
        
        private void AddPrivate(string key, Func<T, T> collisionResolver, Func<T> newCreator, int currentIndex = 0)
        {
            if (string.IsNullOrEmpty(key)) return;
            if (currentIndex == key.Length)
            {
                Value = IsMatch ? collisionResolver(Value) : newCreator();
                return;
            }
            var currentCharacter = key[currentIndex];
            if (!Children.TryGetValue(currentCharacter, out var child))
            {
                child = new Trie<T>();
                Children.Add(currentCharacter, child);
            }

            child.AddPrivate(key, collisionResolver, newCreator, currentIndex + 1);
        }

        public Trie<T> GetNodePrivate(string key, int currentIndex = 0)
        {
            if (string.IsNullOrEmpty(key)) return null;
            if (currentIndex == key.Length)
            {
                return this;
            }
            var currentCharacter = key[currentIndex];
            if (!Children.TryGetValue(currentCharacter, out var child))
            {
                return null;
            }

            return child.GetNodePrivate(key, currentIndex + 1);
        }
    }
}
