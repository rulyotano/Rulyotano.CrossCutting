using System;
using System.Collections.Generic;
using System.Text;

namespace Rulyotano.DataStructures.Trees.Heaps
{
    public class BinaryHeap<T> : IHeap<T>
    {
        public BinaryHeap(Func<T, T, int> compareFunc)
        {
            CompareFunc = compareFunc;
        }

        public Func<T, T, int> CompareFunc { get; }
        public int Count { get; private set; }
        public void Add(T item)
        {
            var newItemNode = BinaryHeapNode.CreateNew(item);
            if (_heap is null)
            {
                _heap = newItemNode;
                _minNode = _heap;
                _maxNode = _heap;
                return;
            }

            _minNode.AddRightChild(newItemNode);
            newItemNode.PullUp();
            Count++;
        }

        public T Lookup()
        {
            return _heap is null ? default : _heap.Value;
        }

        public T Extract()
        {
            Count--;
        }

        private BinaryHeapNode _heap;
        private BinaryHeapNode _minNode;
        private BinaryHeapNode _maxNode;

        private sealed class BinaryHeapNode
        {
            public T Value { get; set; }
            public BinaryHeapNode Right { get; set; }
            public BinaryHeapNode Left { get; set; }
            public BinaryHeapNode Parent { get; set; }
            public Func<T, T, int> CompareFunc { get; set; }
            public static BinaryHeapNode CreateNew(T value, Func<T, T, int> compareFunc) => new() { Value = value, CompareFunc = compareFunc };

            public void AddRightChild(BinaryHeapNode newItemNode)
            {
                newItemNode.Parent = this;
                this.Right = newItemNode;
            }

            public void PullUp()
            {
                if (Parent is null || !OtherIsLower(Parent)) return;
                (Parent.Value, Value) = (Value, Parent.Value);
                Parent.PullUp();
            }

            private bool OtherIsLower(BinaryHeapNode other)
            {
                return CompareFunc(other.Value, Value) < 0;
            }
        }
    }
}
