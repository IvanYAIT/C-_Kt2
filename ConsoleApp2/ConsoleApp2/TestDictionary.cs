using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class TestDictionary<T1, T2> : IEnumerable<TestKeyValuePairs<T1, T2>>, IEnumerator<TestKeyValuePairs<T1, T2>>
    {
        private List<TestKeyValuePairs<T1, T2>> data;

        private int position = -1;

        public TestKeyValuePairs<T1, T2> Current
        {
            get
            {
                try
                {
                    return data[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                try
                {
                    return data[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public TestDictionary()
        {
            data = new List<TestKeyValuePairs<T1, T2>>();
        }

        public void Add(T1 key, T2 value)
        {
            foreach (TestKeyValuePairs<T1, T2> item in data)
            {
                if (key.Equals(item.Key))
                    throw new InvalidOperationException("Такой ключ уже имеется");
            }
            data.Add(new TestKeyValuePairs<T1, T2>(key, value));
        }
            

        public void RemoveByKey(T1 key)
        {
            List<TestKeyValuePairs<T1, T2>> newData = new List<TestKeyValuePairs<T1, T2>>();

            foreach (TestKeyValuePairs<T1,T2> item in data)
            {
                if (!key.Equals(item.Key))
                    newData.Add(item);
            }
            data = newData;
        }

        public void RemoveByValue(T2 value)
        {
            List<TestKeyValuePairs<T1, T2>> newData = new List<TestKeyValuePairs<T1, T2>>();
            bool isRemoved = false;

            foreach (TestKeyValuePairs<T1, T2> item in data)
            {
                if (isRemoved)
                    newData.Add(item);

                if (!value.Equals(item.Value) && !isRemoved)
                    newData.Add(item);
                else
                    isRemoved = true;
            }
            data = newData;
        }

        public TestKeyValuePairs<T1, T2> FindByKey(T1 key)
        {
            foreach (TestKeyValuePairs<T1, T2> item in data)
            {
                if (key.Equals(item.Key))
                    return item;
            }
            throw new ElementNotFoundException();
        }

        public TestKeyValuePairs<T1, T2> FindByValue(T2 value)
        {
            foreach (TestKeyValuePairs<T1, T2> item in data)
            {
                if (value.Equals(item.Value))
                    return item;
            }
            throw new ElementNotFoundException();
        }

        public IEnumerator<TestKeyValuePairs<T1, T2>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            Console.WriteLine("dispose");
        }

        public bool MoveNext()
        {
            position++;
            return position < data.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
