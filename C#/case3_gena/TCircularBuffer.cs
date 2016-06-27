using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class TCircularBuffer
    {

        private byte?[] _buffer;
        public int ReadPosition { get; private set; }
        public int WritePosition { get; private set; }

        public int WrittenBytesAmount => DataAmount();

        public int Capacity { get; private set; }

        public TCircularBuffer(int capacity = 1024)
        {
            Capacity = capacity;
            ReadPosition = 0;
            WritePosition = 0;
            _buffer = new byte?[Capacity];
            InitNull();
        }

        public void ResetReadPosition()
        {
            ReadPosition = 0;
        }

        public void ResetWritePosition()
        {
            WritePosition = 0;
        }

        public void SeekReadPosition(int offset)
        {
            ReadPosition = (ReadPosition + offset)%Capacity;
        }

        public void SeekWritePosition(int offset)
        {
            WritePosition = (WritePosition + offset)%Capacity;
        }

        public void Write(byte[] data)
        {
            // вообще кольцевой буфер должен себя перезаписывать, но все по заданию
            if (WritePosition + data.Length > Capacity)
                throw new Exception("memory not enought");
            
            foreach (byte dataItem in data)
            {
                _buffer[WritePosition] = dataItem;
                WritePosition++;
            }
        }


        public byte?[] Read(int amount)
        {
            byte?[] result = new byte?[amount];
            for (int i = 0; i < amount; i++)
            {
                result[i] = _buffer[ReadPosition%Capacity];
                _buffer[ReadPosition%Capacity] = null;
                ReadPosition++;
            }
            return result;
        }



        public void Resize(int newSize)
        {
            if (newSize > Capacity)
                System.Array.Resize(ref _buffer, newSize);
        }

        private void InitNull()
        {
            for (int i = 0; i < _buffer.Length; i++)
            {
                _buffer[i] = null;
            }
        }

        private int DataAmount()
        {
            int result = 0;
            for (int i = 0; i < _buffer.Length; i++)
            {
                if (_buffer[i] != null)
                    result++;
            }
            return result;
        }


    }
}
