using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class GenericList<X> : IGenericList<X> 
    {
        private X[] _internalStorage;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initalSize)
        {
            _internalStorage = new X[initalSize];
        }




        public void Add(X item)
        {
            if (Count == _internalStorage.Length)
            {
                Array.Resize(ref _internalStorage, 2 * _internalStorage.Length);
            }
            _internalStorage[Count] = item;
            _count++;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return (RemoveAt(i));
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Count; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _count--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }
            return -1;
        }

        private int _count;
        public int Count => _count;

        public void Clear()
        {
            while (Count != 0)
            {
                RemoveAt(Count - 1);
            }
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item)) return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var element in _internalStorage)
            {
                if (element != null)
                    yield return element;
            }
            yield break;

        }
        public IEnumerator<X> GetEnumerator()
        {
            foreach (var element in _internalStorage)
            {
                if (element != null)
                    yield return element;
            }
            yield break;
        }

    }
}
