using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrayasdasd
{
    class TList<T>
    {
        public class TListItem
        {
            public T Data { get; set; }
            public TListItem Next { get; set; }

            public TListItem(T data)
            {
                Data = data;
                Next = null;
            }
        }

        public class TListEventArgs
        {
            // something here
        }

        public int Length { get; private set; }
        public TListItem Head { get; private set; } 
        public TListItem Tail { get; private set; }

        public delegate void TListChangedHandler(object sender, TListEventArgs eventArgs);
        public event TListChangedHandler ListChanged;

        public TList()
        {
            Length = 0;
            Head = null;
            Tail = null;
        }

        public void InsertInList(TList<T> destList, int position)
        {
            if (!destList.IsValidIndex(position))
                throw new Exception("index out boundary in dest list");
            if (position == 0)
            {
                Tail.Next = destList.Head;
                destList.Head = Head;
            }
            else if (position == Length - 1)
            {
                destList.Tail.Next = Head;
                destList.Tail = Tail;
            }
            else
            {
                TListItem previousItem = destList.GetItem(position - 1);
                TListItem currentItem = destList.GetItem(position);
                previousItem.Next = Head;
                Tail.Next = currentItem;
            }
            destList.Length += Length;

        }
        public void Add(T item)
        {
            TListItem tempItem = new TListItem(item);
            if (Length == 0)
            {
                Head = tempItem;
                Tail = tempItem;
            }
            Length++;
        }

        public void AddAt(T item, int index)
        {
            if (!IsValidIndex(index))
                throw new Exception("array boundary exception");
            TListItem tempItem = new TListItem(item);
            if (index == 0)
            {
                tempItem.Next = Head;
                Head = tempItem;
            }
            else if (index == Length - 1)
            {
                Tail.Next = tempItem;
                Tail = tempItem;
            }
            else
            {
                TListItem previousItem = GetItem(index - 1);
                TListItem currentItem = GetItem(index);
                tempItem.Next = currentItem;
                previousItem.Next = currentItem;
            }
            Length++;
        }

        public int GetItemIndex(TListItem item)
        {
            int result = -1;
            TListItem currentItem = Head;
            for (int i = 0; i < Length; i++)
            {
                if (currentItem.Equals(item))
                    return i;
            }
            return result;
        }

        public void RemoveAt(int index)
        {
            if (!IsValidIndex(index))
                throw new Exception("array boundary exception");
            if (Length == 1)
            {
                Head = null;
                Tail = null;
            }
            else if (index == 0)
            {
                Head = Head.Next;
            }
            else
            {
                TListItem previousItem = GetItem(index - 1);
                TListItem currentItem = GetItem(index);
                previousItem.Next = currentItem.Next;
                currentItem.Next = null;
            }
            Length--;
        }

        public T this [int index]
        {
            get { return GetItem(index).Data; }
            set { GetItem(index).Data = value; }
            
        }

        private TListItem GetItem(int index)
        {
            if (!IsValidIndex(index)) 
                throw new Exception("array boundary exception");
            TListItem tempItem = Head;
            for (int i = 0; i < index; i++)
            {
                tempItem = tempItem.Next;
            }
            return tempItem;
        }

        private bool IsValidIndex(int index)
        {
            return (index < Length || index >= 0);
        }

        protected virtual void OnListChanged(TListEventArgs eventargs)
        {
            ListChanged?.Invoke(this, eventargs);
        }
    }
}
