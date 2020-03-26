using Contracts.Core.Patterns;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Core.Patterns
{
    public class FactoryContainer<TKey, TValue> : IFactoryContainer<TKey, TValue>
    {
        #region Fields

        private readonly ConcurrentBag<IAbstractFactory<TKey, TValue>> container;

        #endregion

        #region Properties

        public TKey[] Keys => container
            .SelectMany(f => f.Keys)
            .ToArray();

        #endregion

        #region Constructors

        public FactoryContainer()
        {
            container = new ConcurrentBag<IAbstractFactory<TKey, TValue>>();
        }

        public FactoryContainer(IAbstractFactory<TKey, TValue> factory)
        {
            container = new ConcurrentBag<IAbstractFactory<TKey, TValue>> { factory };
        }

        public FactoryContainer(IEnumerable<IAbstractFactory<TKey, TValue>> factories)
        {
            container = new ConcurrentBag<IAbstractFactory<TKey, TValue>>(factories);
        }

        #endregion

        #region Methods

        public void AddFactory(IAbstractFactory<TKey, TValue> factory)
        {
            if (factory != null)
                container.Add(factory);
        }

        public TValue CreateInstance(TKey key)
        {
            if (key == null)
                return default(TValue);

            foreach (var factory in container)
            {
                var item = factory.CreateInstance(key);
                if (item != null)
                    return item;
            }

            return default(TValue);
        }

        #endregion
    }
}