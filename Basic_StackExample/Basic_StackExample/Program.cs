using System;

namespace Basic_StackExample
{
    public class Stack<T>
    {
        private Entry _top;

        public void Push(T data)
        {
            _top = new Entry(_top, data);
        }

        public T Pop()
        {
            if (_top == null)
                throw new Exception("Stack is null");
            T value = _top.Data;
            _top = _top.Pre;
            return value;
        }

        private class Entry
        {
            public Entry Pre { get; set; }
            public T Data { get; set; }

            public Entry(Entry pre, T data) => (Pre, Data) = (pre, data);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            
        }
    }
}