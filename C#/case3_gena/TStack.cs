using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class TStack<T>
    {
        private readonly T[] _stack;
        public int Top { get; private set; }

        public int StackCapacity { get; private set; }

        public TStack(int capacity = 128)
        {
            _stack = new T[capacity];
            StackCapacity = capacity;
        }

        public T Pop()
        {
            if (Top == 0)
                throw new Exception("stack is empty");
            Top--;
            return _stack[Top];
        }

        public void Push(T item)
        {
            if (Top == StackCapacity)
                throw new Exception("stack overflow");
            _stack[Top] = item;
        }

        public T GetLast()
        {
            return _stack[Top];
        }

        public bool IsEmpty()
        {
            return (Top == 0);
        }

        public void Clear()
        {
            Top = 0;
        }
    }
}
