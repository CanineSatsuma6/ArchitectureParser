using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArchitectureParser.Architecture.NullObjects
{
    public class NullSet<T> : ISet<T>
    {
        public int Count => 0;

        public bool IsReadOnly => false;

        public bool Add(T item)
        {
            return false;
        }

        public void Clear()
        {
            return;
        }

        public bool Contains(T item)
        {
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            return;
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            return;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            return;
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return other.Any();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return false;
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return true;
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return !other.Any();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return false;
        }

        public bool Remove(T item)
        {
            return false;
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return !other.Any();
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            return;
        }

        public void UnionWith(IEnumerable<T> other)
        {
            return;
        }

        void ICollection<T>.Add(T item)
        {
            return;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator();
        }

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            public T Current => default(T);

            object IEnumerator.Current => default(T);

            public void Dispose()
            {
                return;
            }

            public bool MoveNext()
            {
                return false;
            }

            public void Reset()
            {
                return;
            }
        }
    }
}
