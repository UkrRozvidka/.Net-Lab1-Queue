using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue<T> : ICollection, IReadOnlyCollection<T>
    {
        #region fields and properties

        private int count;
        private QueueNode<T>? _head;
        private QueueNode<T>? _tail;

        public int Count
        {
            get { return count; }
        }

        public QueueNode<T>? First
        {
            get { return _head; }
        }

        public QueueNode<T>? Last
        {
            get { return _tail; }
        }

        #endregion

        #region events

        public delegate void QueueHandler(object sender, QueueEventArgs<T> e);

        public event QueueHandler? OnAddElement;

        public event QueueHandler? OnRemoveElement;

        #endregion

        #region constructors

        public Queue() { }

        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (T item in collection)
            {
                Add(item);
            }
        }

        #endregion

        #region add and remove methods

        public void Add(QueueNode<T> newNode)
        {
            if (newNode == null)
                throw new ArgumentNullException(nameof(newNode));
            if (count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Prev = _tail;
                newNode.Next = null;
                _tail!.Next = newNode;
                _tail = newNode;
            }
            count++;
            OnAddElement?.Invoke(this, new QueueEventArgs<T>(newNode.Value, "element was added to tail"));
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            Add(new QueueNode<T>(item));
        }

        public void Remove()
        {
            if (count == 0)
                throw new InvalidOperationException("empty");

            var oldHeadValue = _head!.Value;
            if (count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head!.Next!.Prev = null;
                _head = _head.Next;
            }
            count--;
            OnRemoveElement?.Invoke(this, new QueueEventArgs<T>(oldHeadValue, "element was removed from head"));
        }

        public void Clear()
        {
            QueueNode<T>? current = _head;
            while (current is not null)
            {
                current = current.Next;
            }
            _head = null;
            count = 0;
        }

        #endregion

        #region enumerable and enumerator

        public IEnumerator<T> GetEnumerator()
        {
            QueueNode<T>? current = _head;
            while (current is not null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (index < 0 || index >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (array.Length - index < count)
                throw new ArgumentException("The destination array has not space to copy the elements.", nameof(array));
            if (array.Rank != 1)
                throw new ArgumentException("Multidimensional arrays are not supported.", nameof(array));

            var current = _head;
            while (current != null)
            {
                array.SetValue(current.Value, index++);
                current = current.Next;
            }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot => this;
    }

    public sealed class QueueNode<T>
    {
        public QueueNode(T value)
        {
            Value = value;
        }
        public QueueNode<T>? Prev { get; internal set; }
        public QueueNode<T>? Next { get; internal set; }
        public T Value { get; internal set; }
    }
}

