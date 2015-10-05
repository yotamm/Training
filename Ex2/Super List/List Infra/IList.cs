using System.Collections.Generic;

namespace Super_List.List_Infra
{
    public interface IList<T> : IEnumerable<T>
    {
        void Add(T obj);
        void Remove(T obj);
        T ItemAt(int index);

    }
}