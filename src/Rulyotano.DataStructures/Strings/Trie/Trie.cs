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
        private readonly Func<T, T, T> _collisionResolverFunction;

        public Trie()
        {
            Children = new Dictionary<char, Trie<T>>();
            _collisionResolverFunction = (existingValue, newItem) => newItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collisionResolverFunction">Function to be used to resolve collision when adding new items to the Trie. By default take last added item.</param>
        public Trie(Func<T, T, T> collisionResolverFunction) : this()
        {
            _collisionResolverFunction = collisionResolverFunction;
        }



        /// <summary>
        /// Add item to the Trie.
        /// </summary>
        /// <param name="key">Key string to add</param>
        /// <param name="collisionResolver">Function to add value when already existed</param>
        /// <param name="newCreator">Function to add new value</param>
        public void Add(string key, T newValue)
            => AddPrivate(key, newValue, 0);

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

        public Trie<T> GetNode(char keyCharacter)
        {
            if (Children.TryGetValue(keyCharacter, out var child))
            {
                return child;
            }
            return null;
        }

        private void AddPrivate(string key, T newValue, int currentIndex = 0)
        {
            if (string.IsNullOrEmpty(key)) return;
            if (currentIndex == key.Length)
            {
                Value = IsMatch ? _collisionResolverFunction(Value, newValue) : newValue;
                return;
            }
            var currentCharacter = key[currentIndex];
            if (!Children.TryGetValue(currentCharacter, out var child))
            {
                child = CreateEmptyChild();
                Children.Add(currentCharacter, child);
            }

            child.AddPrivate(key, newValue, currentIndex + 1);
        }

        private Trie<T> GetNodePrivate(string key, int currentIndex = 0)
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

        private Trie<T> CreateEmptyChild() => new Trie<T>(_collisionResolverFunction);
    }
}
