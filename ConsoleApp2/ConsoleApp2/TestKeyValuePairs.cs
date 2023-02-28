namespace ConsoleApp2
{
    class TestKeyValuePairs<T1, T2>
    {
        public T1 Key { get; }
        public T2 Value { get; }

        public TestKeyValuePairs(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return $"Key: {Key}, Value: {Value}";
        }
    }
}
