using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetDemo
{
    public class HashSet<T> : IEnumerable<T>
    {
        private T[] _set;
        private int _count;
        private EqualityComparer<T> _comparer = EqualityComparer<T>.Default;

        public HashSet()
        {
            _set = Array.Empty<T>();
            _count = 0;
        }

        public HashSet(T[] set)
        {
            _set = set;
            _count = set.Length;
        }

        public HashSet(int capacity)
        {
            _set = new T[capacity];
            _count = 0;
        }

        public HashSet(IEnumerable<T> set)
        {
            _count = set.Count();
            _set = new T[_count];

            int i = 0;
            foreach(var item in set)
            {
                _set[i] = item;
                i++;
            }
        }

        public bool Add(T value)
        {
            if (_count > 0)
            {
                foreach (var item in _set)
                {
                    if (item.Equals(value))
                    {
                        return false;
                    }
                }
            }

            if (_count != 0 && _count == _set.Length)
            {
                Array.Resize(ref _set, _count * 2);
            }

            if (_count == 0)
            {
                Array.Resize(ref _set, 1);
            }

            _set[_count] = value;
            _count++;

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var initialSet = _set;
            for (int i = 0; i < _count; i++)
            {
                if (initialSet != _set)
                {
                    throw new InvalidOperationException("Cannot change set while iterating");
                }
                yield return _set[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
