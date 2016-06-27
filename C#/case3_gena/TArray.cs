using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class TArray<T>
    {
        private const int DEFAULT_SIZE = 32;
        public int Capacity { get; private set; } 
        public int Length { get; private set; } = 0;

        private T[] _array;

        public delegate bool ComparisonFunction(T a, T b);


        public TArray(int capacity = DEFAULT_SIZE)
        {
            Capacity = capacity;
            _array = new T[Capacity];
        }

        public void Add(T item)
        {
            if (Length == Capacity)
            {
                T[] tempArray = new T[Capacity * 2];
                System.Array.Copy(_array, tempArray, Length);
                _array = tempArray;

            }
            _array[Length] = item;
            Length++;
        }

        public void RemoveAt(int index)
        {
            if ((index > Length - 1) || (index < 0))
            {
                throw new Exception("array boundary exceptoin");
            }
            for (int i = index; i < Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            Length--;
        }

        public T  this [int index]
        {
            get
            {
                if ((index > Length - 1) || (index < 0))
                {
                    throw new Exception("array boundary exceptoin");
                }
                return _array[index];
            }
            set
            {
                if ((index > Length - 1) || (index < 0))
                {
                    throw new Exception("array boundary exceptoin");
                }
                _array[index] = value;

            }
        }

        public void Sort(ComparisonFunction compare)
        {
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = 0; j < Length - i - 1; j++)
                {
                    if (compare(_array[j], _array[j + 1]))
                    {
                        T temp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = temp;
                    }
                }
            }
        }

        public void CopyFrom(TArray<T> source)
        {
            if (Capacity < source.Length)
            {
                System.Array.Resize(ref _array, source.Capacity);
            }
            System.Array.Copy(source._array,_array,source.Length);
        }




    }
}
