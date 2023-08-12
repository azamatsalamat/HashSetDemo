using System.Collections;

namespace HashSetDemo
{
    public class HashSet<T> : IEnumerable<T>
    {
        private List<T>[] _set = new List<T>[7];
        private int _count;

        public int Count { get { return _count; } }

        public HashSet()
        {
            _count = 0;
        }

        public HashSet(T[] set)
        {
            _count = set.Length;
            _set = new List<T>[_count];

            foreach (T item in set)
            {
                this.Add(item);
            }
        }

        public HashSet(int capacity)
        {
            _set = new List<T>[capacity];
            _count = 0;
        }

        public HashSet(IEnumerable<T> set) : this(set.ToArray())
        {

        }

        public bool Add(T value)
        {
            int index = Math.Abs(value.GetHashCode()) % _set.Length;

            if (_set[index] != null && _set[index].Contains(value))
            {
                return false;
            }
            
            if (_set[index] == null)
            {
                _set[index] = new List<T>();
            }
            _set[index].Add(value);
            _count++;


            if (_count * 10 >= _set.Length * 7)
            {
                Resize();
            }

            return true;
        }

        public bool Contains(T value)
        {
            int index = Math.Abs(value.GetHashCode()) % _set.Length;

            if (_set[index] != null && _set[index].Contains(value))
            {
                return true;
            }

            return false;
        }

        public bool Remove(T value)
        {
            int index = Math.Abs(value.GetHashCode()) % _set.Length;

            if (_set[index] != null && _set[index].Contains(value))
            {
                _set[index].Remove(value);
                _count--;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var initialSet = _set;
            for (int i = 0; i < _set.Length; i++)
            {
                if (initialSet != _set)
                {
                    throw new InvalidOperationException("Cannot change set while iterating");
                }
                if (_set[i] != null)
                {
                    foreach(var item in _set[i])
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Resize() 
        {
            var items = _set.SelectMany(list => (IEnumerable<T>)list);

            _set = new List<T>[(_set.Length + 1) * 2 - 1];

            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}
