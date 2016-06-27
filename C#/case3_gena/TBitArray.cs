using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class TBitArray
    {
        const int DEFAULT_SIZE = 32;
        private int[] _array;
        public int Length { get; private set; }
        public int Capacity { get; private set; }

        public TBitArray(int size = DEFAULT_SIZE)
        {         
            _array = new int[size / sizeof(int) * 2 + 1];
            Capacity = _array.Length * sizeof(int);
            Length = 0;
        }

        public void Add(bool value)
        {
            if (Length + 1 >= Capacity)
            {
                System.Array.Resize(ref _array, Capacity * 2);
            }
            SetMask(value,Length);
            Length++;
        }

        private int GetMask(bool value,int index)
        {
            int temp = 1;
            int offset = index % (sizeof (int));
            temp <<= offset;
            if (!value)
                temp = ~temp;  
            return temp;
        }

        private void SetMask(bool value, int index)
        {
            int itemIndex = index / (sizeof(int));
            int mask = GetMask(value, Length);
            if (value)
            {
                _array[itemIndex] = _array[itemIndex] | mask;
            }
            else
            {
                _array[itemIndex] = _array[itemIndex] & mask;
            }

        }

        public bool this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                    throw new Exception("out of boundary");
                int itemIndex = index/(sizeof (int));
                if ((_array[itemIndex] & GetMask(true, index)) > 0)
                {
                    return true;
                }
                return false;
            }
            set
            {
                if (!IsValidIndex(index))
                    throw new Exception("out of boundary");
                SetMask(value,index);   
            }
        }


        private bool IsValidIndex(int index)
        {
            return (index < Capacity && index >= 0);
        }

    }
}
