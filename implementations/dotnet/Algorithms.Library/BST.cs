using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class BST<T> : IEnumerable<T>, IEnumerable
    {
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