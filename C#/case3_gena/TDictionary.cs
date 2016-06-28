using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{


    class TItem<TKey, TValue> where TKey: IComparable<TKey>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }     
        public TItem(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        } 
    }
    class TDictionary <TKey, TValue> where TKey: IComparable<TKey>
    {
        const int DEFAULT_SIZE = 32;
        private TItem<TKey, TValue>[] _items;
        public int ItemsCount { get; private set; }
        public int Capacity { get; private set; }

        public delegate void DictionaryEventHandler(object sender, EventArgs args);

        public event DictionaryEventHandler ItemAdded;
        public event DictionaryEventHandler ItemRemoved;
        public event DictionaryEventHandler DictionarySorted;

        public void OnDictionarySorted(EventArgs args)
        {
            DictionarySorted?.Invoke(this, args);
        }

        public void OnItemAdded(EventArgs args)
        {
            DictionarySorted?.Invoke(this, args);
        }
        public void OnItemRemoved(EventArgs args)
        {
            DictionarySorted?.Invoke(this, args);
        }

        public bool IsSorted { get; private set; }
        public TDictionary(int size = DEFAULT_SIZE)
        {
            _items = new TItem<TKey, TValue>[size];
            Capacity = size;
        }

        public int GetKeyIndex(TKey key)
        {
            bool result = false;
            int i = 0;
            while (i < ItemsCount)
            {
                if (key.CompareTo(_items[i].Key) == 0)
                    break;

            }
            return (i == ItemsCount) ? -1 : i;
        }

        public TValue GetValue(TKey key)
        {
            int keyIndex = GetKeyIndex(key);
            if (keyIndex != -1)
            {
                return _items[keyIndex].Value;
            }
            return default(TValue);
        }

        public void AddItem(TKey key, TValue value)
        {
            if (GetKeyIndex(key) != -1)
                throw new Exception("key is already exist");
            if (ItemsCount >= Capacity)
                System.Array.Resize(ref _items, Capacity * 2);
            _items[ItemsCount] = new TItem<TKey, TValue>(key,value);
            ItemsCount++;
            IsSorted = false;
            EventArgs e  = new EventArgs();
            OnItemAdded(e);
            //the same way in other methotds
        }

        public void DeleteItem(TKey key)
        {
            int keyIndex = GetKeyIndex(key);
            if (keyIndex != -1)
            {
                TItem<TKey, TValue> temp = _items[keyIndex];
                _items[keyIndex] = _items[ItemsCount - 1];
                _items[ItemsCount - 1] = temp;
                IsSorted = false;
                ItemsCount--;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < _items.Length - 1; i++)
            {
                for (int j = 0; j < _items.Length - i - 1; j++)
                {
                    if (_items[j].Key.CompareTo(_items[j + 1].Key) > 0)
                    {
                        TItem<TKey,TValue> temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }

                }
            }
            IsSorted = true; 
        }
    }
}
