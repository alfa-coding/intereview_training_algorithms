using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Algorithms.Library
{
    public class LinkedNode<T>
    {
        public T Content { get; set; }
        public LinkedNode<T> Next { get; set; }
    }
    public class RegularLinkedListEnumerator<T> : IEnumerator<T>
    {
        private int Count;
        private int index;
        LinkedNode<T> tmp;
        LinkedNode<T> root;


        public RegularLinkedListEnumerator(int _count, LinkedNode<T> _root)
        {
            Count = _count;
            root = _root;
            Reset();

        }
        private bool disposedValue;

        public T Current => index == -1 ? default(T) : tmp.Content;

        object IEnumerator.Current => this.Current;

        public bool MoveNext()
        {
            if (++index < this.Count)
            {
                this.tmp = tmp.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            this.index = -1;
            tmp = new LinkedNode<T> { Next = root };

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RegularLinkedListEnumerator()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public class RegularLinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection, IDeserializationCallback, ISerializable
    {
        private LinkedNode<T> root;
        private LinkedNode<T> last;
        int currentIndex;
        public RegularLinkedList()
        {
            currentIndex = 0;
        }

        public int Count => currentIndex;

        public bool IsReadOnly => false;

        public bool IsSynchronized => false;

        public object SyncRoot => throw new NotImplementedException();

        public void Add(T item)
        {
            if (root == null)
            {
                root = new LinkedNode<T>() { Content = item };
                last = root;
            }
            else
            {
                LinkedNode<T> tmp = new LinkedNode<T> { Content = item };
                last.Next = tmp;
                last = last.Next;
            }
            this.IncreaseCounter();
        }
        private void IncreaseCounter()
        {
            this.currentIndex++;
        }

        public void Clear()
        {
            this.root = null;
            this.last = null;
        }

        public bool Contains(T item)
        {
            return this.FindNode(item).Item2;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            var posAndStatus = this.FindNode(item);
            if (!posAndStatus.Item2)
            {
                //couldnt remove element, it is not present in the list
                return false;
            }
            else
            {
                LinkedNode<T> tmp = this.root;
                int index = 0;
                while (index++ < posAndStatus.Item1 - 1)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = posAndStatus.Item3.Next;
                this.currentIndex--;
                return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            IEnumerator<T> enumerator = new RegularLinkedListEnumerator<T>(this.Count, this.root);
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void OnDeserialization(object sender)
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(T item)
        {
            LinkedNode<T> newHead = new LinkedNode<T>()
            {
                Content = item,
                Next = root
            };
            this.root = newHead;
            
            this.IncreaseCounter();
        }

        


        /*functionalities*/
        private Tuple<int, bool, LinkedNode<T>> FindNode(T item)
        {
            int index = 0;
            LinkedNode<T> tmp = this.root;

            while (tmp != null)
            {
                if (tmp.Content.Equals(item))
                {
                    return new Tuple<int, bool, LinkedNode<T>>(index, true, tmp);
                }
                index++;
                tmp = tmp.Next;
            }
            return new Tuple<int, bool, LinkedNode<T>>(-1, false, null);
        }


    }
}