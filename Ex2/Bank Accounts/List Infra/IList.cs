using System.Collections.Generic;

namespace Bank_Accounts.List_Infra
{
    public interface IList<T> : IEnumerable<T>
    {
        void Add(T obj);
        void Remove(T obj);
        T ItemAt(int index);

    }
}