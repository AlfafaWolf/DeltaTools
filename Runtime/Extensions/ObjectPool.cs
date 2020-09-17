using System;
using System.Collections.Generic;

namespace DeltaTools.Extensions
{
    /// <summary>
    /// Implementation of object pooling using Queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T>
    {
        private readonly Queue<T> _objects;
        private readonly Func<T> _factoryMethod;
        private int _maxSize;

        public int Count => _objects.Count;
    
        public ObjectPool(Func<T> factory, int initialSize = 0, int maxSize = Int32.MaxValue)
        {
            _factoryMethod = factory ?? throw new ArgumentNullException(nameof(_factoryMethod));
            _maxSize = maxSize > 0 ? maxSize : throw new ArgumentOutOfRangeException(nameof(_maxSize), "Max size cannot be lower or equals to zero.");
            _objects = new Queue<T>();
            if (initialSize < 0)
                throw new ArgumentOutOfRangeException(nameof(initialSize), "Initial size cannot be lower than zero.");
            GrowPool(initialSize);
        }

        /// <summary>
        /// Returns an item from the pool, if the pool is empty, then it will create a new item.
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            if (Count == 0)
                Generate();
            return _objects.Dequeue();
        }
        
        /// <summary>
        /// Return an item to the pool.
        /// </summary>
        /// <param name="item"></param>
        public void Return(T item)
        {
            _objects.Enqueue(item);
        }

        /// <summary>
        /// Return a collection to the pool.
        /// </summary>
        /// <param name="collection"></param>
        public void Return(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Return(item);
            }
        }

        /// <summary>
        /// Adds N elements to the pool.
        /// </summary>
        /// <param name="size"></param>
        public void GrowPool(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Generate();
            }
        }

        /// <summary>
        /// Create and add a new item to the pool, if it is not at maximum capacity.
        /// </summary>
        private void Generate()
        {
            if (Count < _maxSize)
                _objects.Enqueue(_factoryMethod());
        }
    }
}