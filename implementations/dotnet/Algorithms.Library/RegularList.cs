using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Library
{
    public class RegularListEnumerator<T> : IEnumerator<T>
    {
        private RegularList<T> InternalList;
        int index;

        public RegularListEnumerator(RegularList<T> _internalList)
        {
            this.InternalList = _internalList;
            Reset();
        }

        public T Current => this.InternalList[index];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            return ++index < this.InternalList.Count;
        }

        public void Reset()
        {
            this.index = -1;
        }
    }

    public class RegularList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        public T[] elements;
        int growingFactor;
        int currentIndex;
        public RegularList()
        {
            currentIndex = 0;
            growingFactor = 5;
            elements = new T[growingFactor];
        }


        /*visibilty return_type functionName(params)*/

        public T this[int index] { get => this.elements[index]; set => this.elements[index] = value; }
        object IList.this[int index] { get => this[index]; set => this[index] = (T)value; }

        public int Count => currentIndex;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public bool IsSynchronized => false;

        public object SyncRoot => throw new NotImplementedException();

        public void Add(T value)
        {
            //si hay espacio en el array, coloco al final y ya
            if (hasSpace())
            {
                AddOneElement(value);
            }

            //que hacer cuando no hay espacio
            else
            {

                GrowArray();

                AddOneElement(value);
            }
        }



        public int Add(object value)
        {
            this.Add(value);
            return 1;
        }

        public void Clear()
        {
            this.elements = new T[5];
        }

        public bool Contains(T item)
        {
            return this.Find(item).Value;
        }

        public bool Contains(object value)
        {
            return this.Contains((T)value);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            IEnumerator<T> regularEnumerator = new RegularListEnumerator<T>(this);
            while (regularEnumerator.MoveNext())
            {
                yield return (T)regularEnumerator.Current;
            }
        }

        public int IndexOf(T item)
        {
            return this.Find(item).Key;
        }

        public int IndexOf(object value)
        {
            return this.IndexOf(value);
        }

        public void Insert(int index, T item)
        {
            if (hasSpace())
            {
                ShiftAndInsert(index, item);
            }
            else
            {
                GrowArray();
                ShiftAndInsert(index, item);

            }
        }

        public void Insert(int index, object value)
        {
            this.Insert(index, value);
        }

        public bool Remove(T item)
        {
            var itemPosAndStatus = this.Find(item);
            if (!itemPosAndStatus.Value)
            {
                //couldnt remove element, it is not present in the list
                return false;
            }
            this.RemoveAt(itemPosAndStatus.Key);
            return true;
        }

        public void Remove(object value)
        {
            this.Remove(value);
        }

        public void RemoveAt(int index)
        {
            if (currentIndex > 0)
            {
                ShiftToTheLeft(index);
                currentIndex--;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        /*Helper private functions*/
        private KeyValuePair<int, bool> Find(T item)
        {
            int index = 0;
            foreach (var element in this.elements)
            {
                if (element.Equals(item))
                {
                    return new KeyValuePair<int, bool>(index, true);
                }
                index++;
            }
            return new KeyValuePair<int, bool>(-1, false); ;
        }

        private void ShiftAndInsert(int position, T value)
        {
            //shifts the array one position foward
            this.ShiftToTheRight(position);

            elements[position] = value;
            currentIndex++;
        }

        private void ShiftToTheLeft(int from)
        {
            int times = from+1;
            while (times < currentIndex)
            {
                elements[times - 1] = elements[times];
                times++;
            }
        }
        private void ShiftToTheRight(int from)
        {
            int times = currentIndex;
            while (times > from)
            {
                elements[times] = elements[times-1];
                times--;
            }

        }

        private bool hasSpace()
        {
            return currentIndex < elements.Length;
        }


        private void GrowArray()
        {
            growingFactor *= 2;
            T[] tmp = new T[growingFactor];

            //copy the preexisting elements from the old array
            this.CopyArray(elements, tmp, elements.Length, 0);

            //update old reference to point to the new one
            elements = tmp;
        }

        private void AddOneElement(T value)
        {
            elements[currentIndex] = value;
            currentIndex++;
        }

        private void CopyArray(T[] source, T[] destination, int amount, int from)
        {
            for (int i = from; i < amount; i++)
            {
                destination[i] = source[i];
            }
        }
    }
}
