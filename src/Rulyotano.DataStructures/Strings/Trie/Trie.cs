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
        private Trie<T> _parent;
        private char? _key;

        public Trie()
        {
            Children = new Dictionary<char, Trie<T>>();
            _collisionResolverFunction = (existingValue, newItem) => newItem;
            _parent = null;
            _key = null;
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
            => AddPrivate(key, newValue);

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

        public void Delete(string key)
        {
            var trie = GetNode(key);
            if (trie == null) return;
            trie.Value = null; 
            RemoveEmptyNodes(trie);
        }

        private void AddPrivate(string key, T newValue)
        {
            if (string.IsNullOrEmpty(key)) return;
            int currentIndex = 0;
            var current = this;

            while (currentIndex < key.Length)
            {
                var currentCharacter = key[currentIndex];
                if (!current.Children.TryGetValue(currentCharacter, out var child))
                {
                    child = CreateEmptyChild(current, currentCharacter);
                    current.Children.Add(currentCharacter, child);
                }
                current = child;
                currentIndex++;
            }

            current.Value = current.IsMatch ? _collisionResolverFunction(current.Value, newValue) : newValue;
        }

        private void RemoveEmptyNodes(Trie<T> trie)
        {
            var current = trie;
            var parent = current._parent;

            while (parent != null)
            {
                if (!current.IsLeaf || current.IsMatch) break;                
                parent.Children.Remove(current._key.Value);
                current = parent;
                parent = current._parent;
            }
        }

        private Trie<T> GetNodePrivate(string key)
        {
            if (string.IsNullOrEmpty(key)) return null;

            var currentIndex = 0;
            var current = this;

            while (currentIndex < key.Length)
            {
                var currentCharacter = key[currentIndex];
                if (!current.Children.TryGetValue(currentCharacter, out var child))
                {
                    return null;
                }

                current = child;
                currentIndex++;
            }

            return current;            
        }

        private Trie<T> CreateEmptyChild(Trie<T> parent, char key) => new Trie<T>(_collisionResolverFunction) { _parent = parent, _key = key };
    }
}
