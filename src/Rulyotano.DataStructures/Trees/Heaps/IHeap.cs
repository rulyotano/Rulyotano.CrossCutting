using System;

namespace Rulyotano.DataStructures.Trees.Heaps
{
    public interface IHeap<T>
    {
        Func<T, T, int> CompareFunc { get; }
        int Count { get; }
        void Add(T item);
        T Lookup();
        T Extract();
    }
}
