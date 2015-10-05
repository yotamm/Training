namespace Bank_Accounts.List_Infra
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        public T Obj { get; set; }
    }
}
