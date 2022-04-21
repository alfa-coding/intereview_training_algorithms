using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class RegularStack<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection
    {
        
        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}