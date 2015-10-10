using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Super_List.List_Infra;

namespace Super_List
{
    public delegate void SuperListChangeEventHandler(object sender, SuperListChangeEventArgs e);

    public class SuperListChangeEventArgs
    {
        public int Index { get; private set; }
        public AddRemove ActionPerformed { get; private set; }

        public SuperListChangeEventArgs(int index, AddRemove action)
        {
            Index = index;
            ActionPerformed = action;
        }

    }

    public class SuperList<T> : List_Infra.IList<T>
    {
        public event SuperListChangeEventHandler SuperListChange;
        private Node<T> First { get; set; }
        

        public void Add(T obj)
        {
            SuperListChangeEventArgs e = new SuperListChangeEventArgs(0, AddRemove.Add);
            SuperListChange?.Invoke(this, e);

            Node<T> temp = First;
            First = new Node<T>() { Obj = obj, Previous = null, Next = temp };
            temp.Previous = First;
        }

        public void Remove(T obj)
        {
            Node<T> currentNode = First;
            
            for (int j = 0; currentNode!=null; j++)
            {
                if (obj.Equals(currentNode.Obj))
                {
                    SuperListChangeEventArgs e = new SuperListChangeEventArgs(j, AddRemove.Remove);
                    SuperListChange?.Invoke(this, e);
                    removeNode(currentNode);
                    break;
                }
                currentNode = currentNode.Next;
            }
        }
        private void removeNode(Node<T> toRemove)
        {
            toRemove.Next.Previous = toRemove.Previous;
            toRemove.Previous.Next = toRemove.Next;
        }

        /// <summary>
        /// Zero-based index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T ItemAt(int index)
        {
            Node<T> currentNode = First;
            for (int i = 1; i <= index; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Obj;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = First;
            while (currentNode != null)
            {
                yield return currentNode.Obj;
                currentNode = currentNode.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PerformOnSingleItem(int index, Action<T> action)
        {
            T item = ItemAt(index);
            action(item);
        }

        public void PerformOnAllItems(Action<T> action)
        {
            foreach (T item in this)
            {
                action(item);
            }
        }

        public void PerformOnCertainItems(Action<T> action, Func<T, bool> selector)
        {
            foreach (T item in this)
            {
                if (selector(item))
                {
                    action(item);
                }//how can i use this in remove?? im iterating T ojects not nodes
            }
        }
    }
}