using System.Collections;

namespace CoreX.Domain.Entity
{
    public class InvariantContext<TEntity> : IEnumerable<IInvariant<TEntity>> where TEntity : BaseEntity
    {
        private readonly List<IInvariant<TEntity>> _collection = new();

        public void Add(IInvariant<TEntity> invariant)
        {
            _collection.Add(invariant);
        }
        public bool Remove(IInvariant<TEntity> invariant)
        {
            return _collection.Remove(invariant);
        }

        public IEnumerator<IInvariant<TEntity>> GetEnumerator()
        {
            return new InvariantEnumerator<TEntity>(_collection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Assess()
        {
 
        }

        private class InvariantEnumerator<TEntityIn> : IEnumerator<IInvariant<TEntityIn>> where TEntityIn : BaseEntity
        {
            private List<IInvariant<TEntityIn>> _collection;
            private int currentIndex = -1;

            public InvariantEnumerator(List<IInvariant<TEntityIn>> collection)
            {
                _collection = collection;
            }

            IInvariant<TEntityIn> Current => _collection[currentIndex];

            object IEnumerator.Current => Current;

            IInvariant<TEntityIn> IEnumerator<IInvariant<TEntityIn>>.Current => Current;

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < _collection.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
