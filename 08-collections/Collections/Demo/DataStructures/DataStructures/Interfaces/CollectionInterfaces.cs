using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
	class CollectionInterfaces
	{
		public interface IEnumerator<T>
		{
			bool MoveNext();
			void Reset();
			T Current { get; }
		}

		public interface IEnumerable<T>
		{
			IEnumerator<T> GetEnumerator();
		}

		public interface ICollection<T> : IEnumerable<T>
		{
			int Count { get; }
			bool IsReadOnly { get; }

			void Add(T item);
			void Clear();
			bool Contains(T item);
			void CopyTo(T[] array, int arrayIndex);
			bool Remove(T item);
		}

		public interface IList<T> : ICollection<T>
		{
			T this[int index] { get; set; }

			int IndexOf(T item);
			void Insert(int index, T item);
			void RemoveAt(int index);
		}

		public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>
		{
			TValue this[TKey key] { get; set; }

			bool ContainsKey(TKey key);
			void Add(TKey key, TValue value);
			bool Remove(TKey key);
			bool TryGetValue(TKey key, out TValue value);

			ICollection<TKey> Keys { get; }
			ICollection<TValue> Values { get; }
		}
	}
}
