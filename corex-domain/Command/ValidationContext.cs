using System.Collections;

namespace CoreX.Domain
{
    public class ValidationContext : IEnumerable<IValidation>
    {
        public List<Exception> Exceptions { get; private set; }

        private readonly List<IValidation> _collection = new();

        public ValidationContext()
        {
            Exceptions = new();
        }

        public void Add(IValidation validation) {
            _collection.Add(validation);
        }
        public bool Remove(IValidation validation)
        {
            return _collection.Remove(validation);
        }
        public IEnumerator<IValidation> GetEnumerator()
        {
            return new ValidationEnumerator(_collection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Validate()
        {
            foreach (var validation in _collection)
                validation.Validate();

            if (Exceptions.Count > 0)
                throw new ValidationException(Exceptions);
        }

        private class ValidationEnumerator : IEnumerator<IValidation>
        {
            private List<IValidation> _collection;
            private int currentIndex = -1;

            public ValidationEnumerator(List<IValidation> collection)
            {
                _collection = collection;
            }

            IValidation Current => _collection[currentIndex];

            object IEnumerator.Current => Current;

            IValidation IEnumerator<IValidation>.Current => Current;

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